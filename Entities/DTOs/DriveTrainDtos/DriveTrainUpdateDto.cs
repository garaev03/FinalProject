using Entities.DTOs.CurrencyDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.DriveTrainDtos
{
    public class DriveTrainUpdateDto
    {
        public DriveTrainGetDto getDto { get; set; }
        public DriveTrainPostDto postDto { get; set; }
    }
}
