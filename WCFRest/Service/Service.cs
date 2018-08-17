using System.Collections.Generic;
using System.Net;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using WCFRest.Model;

namespace WCFRest.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service : IService
    {
        private static WebOperationContext CurrentContext
        {
            get
            {
                return WebOperationContext.Current;
            }
        }

        public User HelloUser(string firstName, string lastName)
        {
            return new User { Id = 99, FirstName  = firstName, LastName = lastName, Age = 33, NickName = firstName + " " + lastName };
        }

        public User CreateUser(User user)
        {
            user.Id = 1;
            SetCurrentContentStatus(HttpStatusCode.Created, "user created...");
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            var list = new List<User> 
            { 
                new User 
                { 
                    Id = 1, 
                    FirstName = "Jim", 
                    LastName = "Raynor", 
                    Age = 40, 
                    NickName = "JR", 
                }, 
                new User 
                { 
                    Id = 2, 
                    FirstName = "Sarah", 
                    LastName = "Kerrigan", 
                    Age = 32, 
                    NickName = "SK", 
                }
            };

            return list;
        }

        public User GetError(string code)
        {
            int httpStatusCode;
            if (int.TryParse(code, out httpStatusCode))
            {
                switch (httpStatusCode)
                {
                    case 400:
                        {
                            SetCurrentContentStatus(HttpStatusCode.BadRequest, "This was a bad request...");
                            break;
                        }
                    case 401:
                        {
                            SetCurrentContentStatus(HttpStatusCode.Unauthorized, "Denied...");
                            break;
                        }
                    case 404:
                        {
                            SetCurrentContentStatus(HttpStatusCode.NotFound, "Not Found...");
                            break;
                        }
                    default:
                        {
                            SetCurrentContentStatus(HttpStatusCode.OK, "OK!");
                            break;
                        }
                }

                return null;
            }

            SetCurrentContentStatus(HttpStatusCode.BadRequest, "Bad Request...");
            return new User
                {
                    FirstName = "User",
                    LastName = "Fake",
                    Age = 100,
                    NickName = "Shadow"
                };
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        private void SetCurrentContentStatus(HttpStatusCode statusCode, string description)
        {
            if (CurrentContext == null)
            {
                return;
            }

            CurrentContext.OutgoingResponse.StatusCode = statusCode;
            CurrentContext.OutgoingResponse.StatusDescription = description;
        }
    }
}