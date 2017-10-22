using SolarSystem.Core;
using System.Collections.Generic;

namespace SolarSystem.Models
{
    public partial class Star : Base
    {
        public virtual ICollection<Planet> Planets { get; set; } = new HashSet<Planet>();
    }
}
