namespace Entities.Concrets
{
    public class City:Entity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public City()
        {
            Vehicles = new();
        }
    }
}
