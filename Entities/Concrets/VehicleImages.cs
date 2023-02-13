using Core.Entities.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrets
{
    public class VehicleImage : Entity
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public bool isMain { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
