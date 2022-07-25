namespace sponapp.Entities
{
    public class BaseEntity
    {
        public BaseEntity(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime dateOf { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool Enable { get; set; } = true;
    }
}
