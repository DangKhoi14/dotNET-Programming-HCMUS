using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomerCompany
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testestetste");
            Console.ReadKey();
        }
    }
}

namespace MainData
{
    public enum customertype { TrungThanh, TiemNang, CanQuanTam, KhachHangKhac };

    public class Customer
    {
        public string CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public customertype CustomerType = customertype.KhachHangKhac;

        public static readonly Dictionary<customertype, string> CustomerTypeDescriptions = new Dictionary<customertype, string>
        {
            { customertype.TrungThanh, "Khach hang trung thanh" },
            { customertype.TiemNang, "Khach hang tiem nang" },
            { customertype.CanQuanTam, "Khach hang can quan tam" },
            { customertype.KhachHangKhac, "Khach hang khac" }
        };

        public Customer() { }
        public Customer(string id, string name, string address, string phone, customertype type)
        {
            CustomerID = id;
            CustomerName = name;
            CustomerAddress = address;
            CustomerPhone = phone;
            CustomerType = type;
        }

        public void CustomerInfo()
        {
            string typeDescription = CustomerTypeDescriptions.ContainsKey(CustomerType)
                                     ? CustomerTypeDescriptions[CustomerType]
                                     : "Khong xac dinh";
            Console.WriteLine($"Info of Customer ID: {CustomerID}\n" +
                              $"Name: {CustomerName}\n" +
                              $"Address: {CustomerAddress}\n" +
                              $"Phone: {CustomerPhone}\n" +
                              $"Type: ({typeDescription})");
        }
    }

    public static class CustomerExtensions
    {
        public static string ConvertToString(this Customer customer)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Customer ID: {customer.CustomerID}");
            sb.AppendLine($"Name: {customer.CustomerName}");
            sb.AppendLine($"Address: {customer.CustomerAddress}");
            sb.AppendLine($"Phone: {customer.CustomerPhone}");
            sb.AppendLine($"Type: {customer.CustomerType}");
            return sb.ToString();
        }
    }

    public class Company
    {
        public string CompanyName { get; set; }
        public List<Customer> ListOfCustomers { get; set; }

        public Company() { }
        public Company(string CompanyName)
        {
            this.CompanyName = CompanyName;
        }

        public void CompanyInfo()
        {
            Console.WriteLine($"Company: {CompanyName}");
            Console.WriteLine("Customers: ");

            int count = Math.Min(ListOfCustomers.Count, 5);
            for (int i = 0; i < count; i++)
            {
                ListOfCustomers[i].CustomerInfo();
                Console.WriteLine();
            }

            if (ListOfCustomers.Count > 5)
            {
                Console.WriteLine("...and more.");
            }
        }

        public dynamic SearchCustomer<T>(T searchTerm)
        {
            List<Customer> foundCustomers = new List<Customer>();

            if (searchTerm is string name)
            {
                // Search by name
                foundCustomers = ListOfCustomers
                    .Where(customer => customer.CustomerName.Equals(name, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }
            else if (searchTerm is int index)
            {
                // Search by index
                if (index >= 0 && index < ListOfCustomers.Count)
                {
                    foundCustomers.Add(ListOfCustomers[index]);
                }
            }

            // Return the appropriate type based on the number of results
            if (foundCustomers.Count == 1)
            {
                return foundCustomers[0];
            }
            else if (foundCustomers.Count > 1)
            {
                return foundCustomers;
            }

            return null;
        }
    }
}