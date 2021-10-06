#nullable enable
using System;
using System.Collections.Generic;
using System.Text;

namespace OctopusParadise.CompanyApp.Data.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Mobile { get; set; }
        
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

    }
}
