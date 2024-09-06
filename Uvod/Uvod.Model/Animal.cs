namespace Uvod.Model
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }  
        public string? Specise { get; set; }

        public int Age { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public Owner? Owner { get; set; }
        public Guid OwnerId { get; set; }
    }
}
