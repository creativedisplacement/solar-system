using System;

namespace SolarSystem.Core
{
    public abstract class Base
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SmallImage { get; set; }
        public int? Ordinal { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
    }
}
