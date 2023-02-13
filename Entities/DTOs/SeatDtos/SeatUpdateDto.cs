using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.SeatDtos
{
    public class SeatUpdateDto
    {
        public SeatGetDto getDto { get; set; }
        public SeatPostDto postDto { get; set; }
    }
}
