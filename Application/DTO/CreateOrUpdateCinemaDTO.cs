using System;
using System.Collections.Generic;

namespace Application.DTO
{
    public class CreateOrUpdateCinemaDTO
    {
        public string Name { get; set; }
        public List<MovieDTO>? Movies { get; set; }
        public AddressDTO Address { get; set; }
    }
}
