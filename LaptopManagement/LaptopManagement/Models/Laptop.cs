using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopManagement.Models
{
    internal class Laptop
    {
        public Guid LaptopID { get; set; }
        public string LaptopName { get; set; }
        public string LaptopType { get; set; } 
        public DateTime ProductDate { get; set; }
        public string Processor { get; set; }
        public string HDD { get; set; }
        public string RAM { get; set; }
        public int Price { get; set; }
        public string ImageName => $"{LaptopName}.png";

        public Laptop()
        {
            LaptopID = Guid.NewGuid();
        }

        public Laptop(string laptopName, string laptopType, DateTime productDate, string processor, string hdd, string ram, int price)
        {
            LaptopID = Guid.NewGuid();
            LaptopName = laptopName;
            LaptopType = laptopType;
            ProductDate = productDate;
            Processor = processor;
            HDD = hdd;
            RAM = ram;
            Price = price;
        }

        public override string ToString()
        {
            return $"LaptopID: {LaptopID}\nLaptopName: {LaptopName}\nLaptopType: {LaptopType}\nProductDate: {ProductDate.ToShortDateString()}\nProcessor: {Processor}\nHDD: {HDD}\nRAM: {RAM}\nPrice: {Price}\nImageName: {ImageName}";
        }
    }
}
