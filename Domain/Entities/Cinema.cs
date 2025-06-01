namespace Domain.Entities
{
    public class Cinema : Entity
    {
        public string Name { get; set; }
        public List<Movie> Movies { get; set; }
        public Address Address { get; set; }
    }
}
