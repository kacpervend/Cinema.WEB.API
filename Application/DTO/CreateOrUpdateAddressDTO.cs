using System;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class CreateOrUpdateAddressDTO
    {
        [Required]
        [MaxLength(50)]
        public string City { get; set; }
        [Required]
        [MaxLength(100)]
        public string Street { get; set; }
        [Required]
        [MaxLength(10)]
        public string BuildingNumber { get; set; }
        [MaxLength(10)]
        public string? ApartmentNumber { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string PostalCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
    }
}
