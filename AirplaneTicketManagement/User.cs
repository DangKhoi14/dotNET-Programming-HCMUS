using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTicketManagement
{
    public class User
    {
        private string CustomerId;
        private string Username;
        private string Password;

        public User(string username, string password, string id)
        {
            Username = username;
            Password = password;
            CustomerId = id;
        }

        public string getUsername()
        {
            return Username;
        }

        public string getPassword()
        {
            return Password;
        }
    }
}
