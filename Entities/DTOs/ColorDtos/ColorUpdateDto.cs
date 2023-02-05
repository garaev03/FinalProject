using Entities.DTOs.BanDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ColorDtos
{
    public class ColorUpdateDto
    {
        public ColorGetDto getDto { get; set; }
        public ColorPostDto postDto { get; set; }
    }
}
