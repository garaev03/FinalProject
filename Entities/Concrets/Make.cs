using Core.Entities.Concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrets
{
    public class Make : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<Model> Models { get; set; }
        public Make()
        {
            Models= new List<Model>();
        }
    }
}
