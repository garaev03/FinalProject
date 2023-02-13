using Entities.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CityDtos
{
    public class CityGetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Code { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public CityGetDto()
        {
            Vehicles = new();
        }
    }
}
