using Microsoft.AspNetCore.Http;

namespace Entities.DTOs.MakeDtos{
    public class MakePostDto{
        public string? Name {get; set;}
        public IFormFile? formFile {get; set;}
    }
}