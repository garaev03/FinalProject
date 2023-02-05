using Core.Entities.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrets
{
    public class Year : Entity
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
}
