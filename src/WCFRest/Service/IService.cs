using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using WCFRest.Model;

namespace WCFRest.Service
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/users?firstName={firstname}&lastName={lastName}",
            ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        User HelloUser(string firstName, string lastName);

        [OperationContract]
        [WebInvoke(UriTemplate = "/users", Method = "POST", ResponseFormat = WebMessageFormat.Json,
            RequestFormat = WebMessageFormat.Json)]
        User CreateUser(User user);

        [WebGet(UriTemplate = "/users", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<User> GetUsers();

        [WebInvoke(UriTemplate = "/errors/{code}", Method = "GET", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        User GetError(string code);

        //Same as WebApi
        [WebInvoke(UriTemplate = "/values", Method = "GET", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        IEnumerable<string> Get();
    }
}