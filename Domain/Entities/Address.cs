namespace Domain.Entities
{
    public class Address : Entity
    {
        public string City { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string? ApartmentNumber { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public Address(int id, DateTime createdDate, int createdById, string city, string street, string buildingNumber, string? apartmentNumber, string postalCode, string country) : base(id, createdDate, createdById)
        {
            City = city;
            Street = street;
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
            PostalCode = postalCode;
            Country = country;
        }
    }
}
