using Entities.Concrets;

namespace Entities.DTOs.ModelDtos
{
    public class ModelGetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int MakeId { get; set; }
        public Make? Make { get; set; }
        public List<Vehicle> Cars { get; set; }
        public ModelGetDto()
        {
            Cars = new();
        }
    }
}