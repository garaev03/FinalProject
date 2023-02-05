using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.BanDtos
{
    public class BanPostDto
    {
        public string? Name { get; set; }
        public IFormFile? formFile { get; set; }
    }
}
