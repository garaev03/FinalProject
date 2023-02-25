namespace Entities.Concrets
{
    public class Make : Entity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Model> Models { get; set; }
        public Make()
        {
            Models= new List<Model>();
        }
    }
}
