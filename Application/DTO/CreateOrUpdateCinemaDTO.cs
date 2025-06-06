using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class CreateOrUpdateCinemaDTO
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public List<MovieDTO>? Movies { get; set; }
        [Required]
        public AddressDTO Address { get; set; }
    }
}
