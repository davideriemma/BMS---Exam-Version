namespace LoginMicroService.Ports
{
    /// <summary>
    /// This is the port which allows coupling between the LoginAPI and the core application
    /// </summary>
    public interface IAPI
    { 
        /// <summary>
        /// The delegate needed by the mapGet/mapPost/mapPut/mapDelete methods. 
        /// The idea is to have one single delegate for all the functionalities offered by the microservice
        /// </summary>
        /// <typeparam name="T">could be an int or a string, but they must be of the same type</typeparam>
        /// <param name="values">the variable argument list of request values</param>
        /// <returns>a string containing the JSON map of the response</returns>
        public delegate IResult RESTHandler<T>(params T[] values);
    }
}
