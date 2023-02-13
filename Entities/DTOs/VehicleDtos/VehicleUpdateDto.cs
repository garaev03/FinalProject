using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.VehicleDtos
{
    public class VehicleUpdateDto
    {
        public VehicleGetDto getDto { get; set; }
        public VehiclePostDto postDto { get; set; }
    }
}
