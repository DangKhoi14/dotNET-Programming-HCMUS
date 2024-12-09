using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTicketManagement
{
    public class User
    {
        private string CustomerId { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }

        public User(string username, string password, string id)
        {
            Username = username;
            Password = password;
            CustomerId = id;
        }
    }
}
