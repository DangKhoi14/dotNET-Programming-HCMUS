using System;
using System.Globalization;
using AttributeData;

namespace MilkManagement
{
    using MainData;

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}

namespace MainData
{
    public class Milk
    {
        private string MilkName;
        private string MilkID;
        private DateTime ProductionDate;
        private DateTime ExpiredDate;
        private int Quantity;

        public Milk(string milkName = "N/A", string productionDate = "", string expiredDate = "", int quantity = 0)
        {
            this.MilkName = milkName;
            this.ProductionDate = DateTime.ParseExact(productionDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            this.ExpiredDate = DateTime.ParseExact(expiredDate, "dd/MM/yyyy", CultureInfo.InvariantCulture) ;
            this.MilkID = String.Format("MILK{0}", this.ProductionDate.ToString("ddMMyyyy"));
            this.Quantity = quantity;
        }

        public string ValMilkID
        {
            get { return MilkID; }
        }

        public string ValMilkName
        {
            get { return MilkName; }
            set { MilkName = value; }
        }

        public string ValProductionDate
        {
            get { return ProductionDate.ToString("dd/MM/yyyy"); }
            set { 
                ProductionDate = ParseDate(value);
                MilkID = String.Format("MILK{0}", ProductionDate.ToString()); 
            }
        }

        public string ValExpiredDate
        {
            get { return ExpiredDate.ToString("dd/MM/yyyy"); }
            set { ExpiredDate = ParseDate(value); }
        }

        public int ValQuantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }

        private DateTime ParseDate(string dateStr)
        {
            DateTime result;
            string[] formats = { "dd/MM/yyyy" };
            if (DateTime.TryParseExact(dateStr, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return result;
            }
            else
            {
                throw new FormatException($"'{dateStr}' is invalid.");
            }
        }
    }
}

namespace AttributeData
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class MilkMoreInfo : System.Attribute
    {
        public string Manufacturer { get; set; }
        public string CompanyName { get; set; }

        public MilkMoreInfo(string manuFacturer = "", string companyName = "")
        {
            this.Manufacturer = manuFacturer;
            this.CompanyName = companyName;
        }
    }
}