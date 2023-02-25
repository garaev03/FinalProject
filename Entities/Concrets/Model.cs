
namespace Entities.Concrets
{
    public class Model : Entity
    {
        public string Name { get; set; }
        public int MakeId { get; set; }
        public Make Make { get; set; }
        public List<Vehicle> Cars { get; set; }
        public Model()
        {
            Cars= new List<Vehicle>();
        }
    }
}
