using SolarSystem.Core;
using System.Collections.Generic;

namespace SolarSystem.Models
{
    public class Star : Base
    {
        public virtual ICollection<Planet> Planets { get; set; }
    }
}
