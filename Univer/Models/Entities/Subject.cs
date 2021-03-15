namespace Univer.Models.Entities
{
    public class Subject : Entity
    {
        public string Name { get; set; }

        public Professor Professor { get; set; }
    }
}
