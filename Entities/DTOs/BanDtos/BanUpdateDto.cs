using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.BanDtos
{
    public class BanUpdateDto
    {
        public BanGetDto getDto { get; set; }
        public BanPostDto postDto { get; set; }
    }
}
