using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Text;
using System.Xml.Linq;

namespace C__Basic_to_Advance.Models
{
    public class Supplier
    {
        //SupplierId, Name, ContactEmail, PhoneNumber, Country

        public string SupplierId { get; init; }
        public string Name { get; set; }

        public string ContactEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; init; }

        public string DisplayContact => $"{Name} | {ContactEmail} | {PhoneNumber}";

        public Supplier(string supplierId, string name, string country)
        {
            SupplierId = supplierId;
            Name = name;
            Country = country;
        }

        public Supplier(string supplierId, string name, string country, string email, string phone)
            : this(supplierId, name, country)
        {
            ContactEmail = email;
            PhoneNumber = phone;
        }
    }
}
