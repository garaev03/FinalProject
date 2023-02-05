using Entities.DTOs.ColorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CountryDtos
{
    public class CountryUpdateDto
    {
        public CountryGetDto getDto { get; set; }
        public CountryPostDto postDto { get; set; }
    }
}
