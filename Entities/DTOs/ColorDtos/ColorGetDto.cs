using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ColorDtos
{
    public class ColorGetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Image { get; set; }
    }
}
