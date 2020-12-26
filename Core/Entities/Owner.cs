namespace Core.Entities
{
    public class Owner : EntitiesBase
    {
        public string Name { get; set; }
        public string Profile { get; set; }
        public string Picture { get; set; }
        public Address address { get; set; }
    }
}
