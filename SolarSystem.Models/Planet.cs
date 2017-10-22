using SolarSystem.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolarSystem.Models
{
    public partial class Planet : Base
    {
        [ForeignKey("StarId")]
        public virtual Star Star { get; set; }

        [Required]
        public int StarId { get; set; }
        public virtual ICollection<Moon> Moons { get; set; } = new HashSet<Moon>();
    }
}
