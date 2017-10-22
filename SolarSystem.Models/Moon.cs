using SolarSystem.Core;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarSystem.Models
{
    public partial class Moon : Base
    {
        [ForeignKey("PlanetId")]
        public virtual Planet Planet { get; set; }

        [Required]
        public int PlanetId { get; set; }
    }
}
