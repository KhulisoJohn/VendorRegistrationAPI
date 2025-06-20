using System;
using System.ComponentModel.DataAnnotations;
using VendorRegistrationAPI.Models;

namespace VendorRegistrationAPI.Models
{
    
public class VendorRegistrationDto
{
    [Required]
    [StringLength(100)]
    public string BusinessName { get; set; } = string.Empty;

    [Required]
    public BusinessType BusinessType { get; set; }

        [Required]
        [RegularExpression(@"[A-Z0-9\-]+$", ErrorMessage = "Invalid Tax ID format")]
        public string TaxId { get; set; } = string.Empty;

    [Range(1800, 2100)]
    public int YearEstablished { get; set; }

    public EmployeeRange NumberOfEmployees { get; set; }

    [Url]
    public string? Website { get; set; }

        [Required]
        [StringLength(500)]
        public string BusinessDescription { get; set; } = string.Empty;
        public object Status { get; internal set; } = string.Empty;
    }

}
