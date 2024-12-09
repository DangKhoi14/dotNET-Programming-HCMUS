using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirplaneTicketManagement
{
    public class Customer
    {
        private string CustomerId { get; }
        private string CustomerName { get; set; }
        private DateOnly Birthday { get; set; }
        private String PassportNbr { get; set; }
        private String Nationality { get; set; }
        private Image Avatar { get; set; }

        public Customer(string customerName, DateOnly birthday, string passportNbr, string nationality, Image avatar)
        {
            CustomerName = customerName;
            Birthday = birthday;
            PassportNbr = passportNbr;
            Nationality = nationality;
            Avatar = avatar;

            // Generate CustomerId in constructor
            string initials = string.Join("", customerName.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(word => word[0])).ToUpper();
            string birthDate = birthday.ToString("yyyyMMdd"); // Format as YYYYMMDD
            CustomerId = $"{initials}-{birthDate}";
        }
    }


}
