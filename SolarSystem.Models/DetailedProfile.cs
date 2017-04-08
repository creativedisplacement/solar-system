using SolarSystem.Core;

namespace SolarSystem.Models
{
    public class DetailedProfile
    {
        public int Id { get; set; }
        public string LargeImage { get; set; }
        public string Introduction { get; set; }
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
        public int TypeId { get; set; }
        public string TypeName { get; set; }
    }
}
