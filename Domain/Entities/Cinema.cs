namespace Domain.Entities
{
    public class Cinema : Entity
    {
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
        public Address Address { get; set; }

        public Cinema(int id, DateTime createdDate, int createdById, string name, List<Movie> movies, Address address) : base(id, createdDate, createdById)
        {
            Name = name;
            Movies = movies;
            Address = address;
        }

        public Cinema()
        {

        }
    }
}
