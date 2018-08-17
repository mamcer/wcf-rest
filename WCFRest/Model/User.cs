using System.Collections.Generic;
using System.Runtime.Serialization;

namespace WCFRest.Model
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "id")]
        public int Id { get; set; }

        [DataMember(Name = "firstName")]
        public string FirstName { get; set; }

        [DataMember(Name = "lastName")]
        public string LastName { get; set; }

        [DataMember(Name = "age")]
        public int Age { get; set; }

        [DataMember(Name = "nickName")]
        public string NickName { get; set; }
    }
}