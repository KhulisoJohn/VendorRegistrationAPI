using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using VendorRegistration.API.Data;
using VendorRegistration.API.Models;


namespace VendorRegistrationApi.Services
{
    public class VendorService
    {
        private readonly VendorDbContext _dbContext;

        public VendorService(VendorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<(bool IsValid, List<ValidationResult> Errors, Vendor Vendor)> RegisterVendorStep1Async(VendorRegistrationDto dto)
        {
            // Manual validation in addition to DataAnnotations
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(dto);
            if (!Validator.TryValidateObject(dto, validationContext, validationResults, true))
            {
                #pragma warning disable CS8619 
                return (false, validationResults, null);
                #pragma warning restore CS8619 
            }

           
            var vendor = new Vendor
            {
                BusinessName = dto.BusinessName,
                businessType = dto.BusinessType,
                TaxId = dto.TaxId,
                YearEstablished = dto.YearEstablished,
                NumberOfEmployees = dto.NumberOfEmployees,
                Website = dto.Website,
                BusinessDescription = dto.BusinessDescription,
                Status = VendorStatus.Pending
            };

            _dbContext.Vendors.Add(vendor);
            await _dbContext.SaveChangesAsync();

            #pragma warning disable CS8619 
            return (true, null, vendor);
            #pragma warning restore CS8619 
        }
    }
}

