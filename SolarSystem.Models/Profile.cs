using SolarSystem.Core;
using System.ComponentModel.DataAnnotations;

namespace SolarSystem.Models
{
    public partial class Profile
    {
        [Key]
        public int Id { get; set; }
        public string LargeImage { get; set; }

        [Required]
        public string Introduction { get; set; }
        [Required]
        public string Content { get; set; }
        public string EffectiveTemperature { get; set; }
        public string Diameter { get; set; }
        public string FirstRecorded { get; set; }
        public string RecordedBy { get; set; }
        public string Mass { get; set; }
        public string DayLength { get; set; }
        public string YearLength { get; set; }
        public string OrbitalDistance { get; set; }
        public bool HasRings { get; set; }
        [Required]
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        [Timestamp]
        public byte[] Timestamp { get; set; }
    }
}
