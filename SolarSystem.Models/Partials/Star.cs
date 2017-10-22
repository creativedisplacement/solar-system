using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarSystem.Models
{
    public partial class Star
    {
        public override string ToString()
        {
            return $"{this.Name} has {this.Planets.Count} planets";
        }
    }
}
