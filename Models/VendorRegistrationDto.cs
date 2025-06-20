using System;
using System.ComponentModel.DataAnnotations;
using VendorRegistration.API.Models;

namespace VendorRegistration.API.Models
{
    
public class VendorRegistrationDto
{
    [Required]
    [StringLength(100)]
    public string BusinessName { get; set; }

    [Required]
    public BusinessType BusinessType { get; set; }

    [Required]
    [RegularExpression(@"[A-Z0-9\-]+$", ErrorMessage = "Invalid Tax ID format")]
    public string TaxId { get; set; }

    [Range(1800, 2100)]
    public int YearEstablished { get; set; }

    public EmployeeRange NumberOfEmployees { get; set; }

    [Url]
    public string? Website { get; set; }

    [Required]
    [StringLength(500)]
    public string BusinessDescription { get; set; }
        public object Status { get; internal set; }
    }

}
