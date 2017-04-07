using SolarSystem.Core;
using System.Collections.Generic;

namespace SolarSystem.Models
{
    public class Planet : Base
    {
        public virtual Star Star { get; set; }
        public int StarId { get; set; }
        public virtual ICollection<Moon> Moons { get; set; }
    }
}
