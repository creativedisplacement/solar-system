using SolarSystem.Core;

namespace SolarSystem.Models
{
    public class Moon : Base
    {
        public virtual Planet Planet { get; set; }
        public int PlanetId { get; set; }
    }
}
