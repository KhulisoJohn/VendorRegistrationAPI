using System;
using VendorRegistration.API.Models;

namespace VendorRegistration.API.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }
        public BusinessType businessType { get; set; }
        public string TaxId { get; set; }
        public int YearEstablished { get; set; }
        public EmployeeRange NumberOfEmployees { get; set; }
        public string Website { get; set; }
        public string BusinessDescription { get; set; }

        public VendorStatus Status { get; set; } = VendorStatus.Pending;
        
    }
}


