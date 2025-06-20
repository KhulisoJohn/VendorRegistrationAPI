using System;
using VendorRegistrationAPI.Models;

namespace VendorRegistrationAPI.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string BusinessName { get; set; } = string.Empty;
        public BusinessType businessType { get; set; }
        public string TaxId { get; set; } = string.Empty;
        public int YearEstablished { get; set; }
        public EmployeeRange NumberOfEmployees { get; set; }
        public string Website { get; set; } = string.Empty;
        public string BusinessDescription { get; set; } = string.Empty;

        public VendorStatus Status { get; set; } = VendorStatus.Pending;
        
    }
}


