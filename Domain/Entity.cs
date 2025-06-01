namespace Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedById { get; set; }

        public Entity(int id, DateTime createdDate, int createdById)
        {
            Id = id;
            CreatedDate = createdDate;
            CreatedById = createdById;
        }
    }
}
