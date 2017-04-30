using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.API
{
    public class User
    {
        public string ID { get; set; }
        public string GroupID { get; set; }
        public Auth Auth { get; set; }
        public UserInfo Info { get; set; }
    }

    public class Auth
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
