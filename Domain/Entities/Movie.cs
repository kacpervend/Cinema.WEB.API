namespace Domain.Entities
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public Movie(int id, DateTime createdDate, int createdById, string title, string description) : base(id, createdDate, createdById)
        {
            Title = title;
            Description = description;
        }

        public Movie()
        {

        }
    }
}
