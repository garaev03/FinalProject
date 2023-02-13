using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CityDtos
{
    public class CityUpdateDto
    {
        public CityGetDto getDto { get; set; }
        public CityPostDto postDto { get; set; }
    }
}
