using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace Tests
{
    [TestClass]
    public class LoginMicroservicesTests
    {
        [TestMethod]
        public async Task LoginSucceedsOnCorrectCredentials()
        {
            HttpClient client = new HttpClient();
            LoginMicroService.Mappings.login.LoginException? e = null;
            try
            {
                LoginMicroService.Model.LoginMicroServiceModelContext context = new();
                StringContent postData = new StringContent("{\"username\":\"davide\", \"password\":\"hehehe\"}", Encoding.UTF8, "application/json");
                HttpResponseMessage result = await (client.PostAsync("http://127.0.0.1:49153/login", postData));

                result.EnsureSuccessStatusCode();
            }
            catch(LoginMicroService.Mappings.login.LoginException ex)
            {
                e = ex;
            }
            catch (Exception jay)
            {
                e = (LoginMicroService.Mappings.login.LoginException)jay;
            }
            finally
            {
                client.Dispose();
            }

            Assert.IsNull(e);
        }

        [TestMethod]
        public async Task LoginFailsOnInvalidCredentials()
        {
            HttpClient client = new HttpClient();
            LoginMicroService.Mappings.login.LoginException? e = null;
            try
            {
                LoginMicroService.Model.LoginMicroServiceModelContext context = new();
                StringContent postData = new StringContent("{\"username\":\"davidonzolo\", \"password\":\"hehehe\"}", Encoding.UTF8, "application/json");
                HttpResponseMessage result = await (client.PostAsync("loacalhost:49157/login", postData));

                result.EnsureSuccessStatusCode();
            }
            catch (LoginMicroService.Mappings.login.LoginException ex)
            {
                e = ex;
            }
            catch (Exception jay)
            {
                e = (LoginMicroService.Mappings.login.LoginException)jay;
            }
            finally
            {
                client.Dispose();
            }

            Assert.IsNotNull(e);
        }

        [TestMethod]
        public async Task TokenIsGeneratedUponCorrectCredentials()
        {
            HttpClient client = new HttpClient();
            string? token = null;
            LoginMicroService.Mappings.login.LoginException? e = null;
            try
            {
                LoginMicroService.Model.LoginMicroServiceModelContext context = new();
                StringContent postData = new StringContent("{\"username\":\"davidonzolo\", \"password\":\"hehehe\"}", Encoding.UTF8, "application/json");
                HttpResponseMessage result = await(client.PostAsync("loacalhost:49157/login", postData));

                result.EnsureSuccessStatusCode();

                token = result.Content.ToString();
            }
            catch (LoginMicroService.Mappings.login.LoginException ex)
            {
                e = ex;
            }
            catch (Exception jay)
            {
                e = (LoginMicroService.Mappings.login.LoginException)jay;
            }
            finally
            {
                client.Dispose();
            }

            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void AdministratorIsAddesSuccessfully()
        {
            //TODO: implement
        }
    }
}