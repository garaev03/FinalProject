namespace Entities.DTOs.MakeDtos{
    public class MakeGetDto{
        public int Id{get; set;}
        public string? Name {get; set;}
        public string? Image {get; set;}
        public List<Model> Models { get; set; }
        public MakeGetDto()
        {
            Models = new List<Model>();
        }
    }
}