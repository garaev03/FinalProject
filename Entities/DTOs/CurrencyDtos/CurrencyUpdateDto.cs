using Entities.DTOs.CountryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CurrencyDtos
{
    public class CurrencyUpdateDto
    {
        public CurrencyGetDto getDto { get; set; }
        public CurrencyPostDto postDto { get; set; }
    }
}
