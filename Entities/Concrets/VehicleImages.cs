namespace Entities.Concrets
{
    public class VehicleImage : Entity
    {
        public string Path { get; set; }
        public bool isMain { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
