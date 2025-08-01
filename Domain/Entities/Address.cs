﻿namespace Domain.Entities
{
    public class Address : Entity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
}
