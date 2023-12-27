using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZSProject
{
    public static class UserInfoProvider
    {
        private static User _loggedUser { get; set; }
        public static string GetPhoneNumber()
        {
            return _loggedUser.PhoneNumber;
        }
        public static void SetUser(User user)
        {
            _loggedUser = user;
        }
        public static bool IsClient()
        {
            return _loggedUser.IsClient;
        }
    }
}
