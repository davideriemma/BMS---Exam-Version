using LoginMicroService.Ports;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace LoginMicroService.Mappings.login
{
    /// <summary>
    /// The Login class handles the core logic and its ancillary utilities wich
    /// </summary>
    public class Login : Ports.IPersistance, Ports.IAPI
    {
        /// <summary>
        /// Database context, as needed to implement the InitializeContext() function from the IPersistance interface
        /// </summary>
        private static Model.LoginMicroServiceModelContext? dbContext;
        /// <summary>
        /// Performs the actual login operation. Only two parameters are needed: username and password, both strings
        /// </summary>
        /// <param name="p">Needed to comply with the HTTPHandler delegate. The only two parameters are as follows:
        /// <ol>
        ///     <li>Username: the username</li>
        ///     <li>Password: the password</li>
        /// </ol>   
        /// </param>
        /// <returns>The token in the structure, as well as true in the Result field, indicating success</returns>
        /// <exception cref="LoginException"></exception>
        public static IResult doLogin(params string[] p)
        {
            //indexes used to parse the variable param argument
            const int username = 0;
            const int password = 1;

            /*---Activity: Prepare Login DTO and search for Login Infos in the database---*/

            //initialize the context
            Login login = new Login();
            login.InitializeContext();

            //generate the return token
            Model.Token token = new();
            LoginMicroService.Model.LoginMicroServiceModelContext context = new();
            string hasedPassword = BitConverter.ToString(SHA256.HashData(Encoding.UTF8.GetBytes(p[password]))).Replace("-", "");
            Console.WriteLine(hasedPassword);

            Console.WriteLine("Performing User Authentication");
            var queryResult = from data in context.Logins where data.Username.Equals(p[username]) && data.Hashed.Equals(hasedPassword) select new Login();
            
            if (dbContext != null && queryResult != null)
            /*-- End of Activity: Prepare Login DTO and search for Login Infos in the database--*/
            
            {
                /*---Activity: Token String Enctyption----*/

                //generate token
                //generate string to encrypt

                Console.WriteLine("User authenticated, generating token");
                string toEncrypt = $"username={p[username]},password={hasedPassword},salt={DateTime.Now}";
                Console.WriteLine("Token Generated");
                byte[] data = Encoding.UTF8.GetBytes(toEncrypt);

                StreamReader privateKeyStream = new StreamReader(context.Keys.First().Private);

                Console.WriteLine("Encripting with RSA");
                
                using (RSACryptoServiceProvider k = new(2048))
                {
                    XmlSerializer serializer = new(typeof(RSAParameters));
                    k.ImportParameters((RSAParameters)serializer.Deserialize(privateKeyStream));
                    Console.WriteLine("Enctypting Data");
                    token.Token1 = Encoding.UTF8.GetString(k.Encrypt(data, true));
                    token.Username = string.Empty;
                    Console.WriteLine("Data Succesfully Encrypted");
                    Console.WriteLine($"Result: {token.Token1}");
                    /*---End Activity: Token String Enctyption----*/

                    Console.WriteLine("Saving Token Information to database");
                    context.Tokens.Add(token);
                    
                    context.SaveChanges();

                    Console.WriteLine("Token Information saved to database. All Done");
                }
            }
            else
            {
                throw new LoginException("404: Invalid Username or Password");
            }

            return Results.Ok(token.Token1);
        }

        public void InitializeContext()
        {
            dbContext = new Model.LoginMicroServiceModelContext();
        }

    }

    /// <summary>
    /// Rapresents an exception, which is generated when the login fails and allow
    /// </summary>
    public class LoginException : Exception
    {
        public LoginException(string message) : base(message) { }
    }
}
