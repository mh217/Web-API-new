using Uvod.Model;

namespace UvodWEBAPI.Models
{
    public class GetAnimalData
    {
        public string Name { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Owner? Owner { get; set; }
    }
}
