namespace Entities.DTOs.EngineCapacityDtos
{
    public class EngineCapacityGetDto
    {
        public int Id { get; set; }
        public float Value { get; set; }
        public string ConvertedValue { get; set; } = "";
    }
}
