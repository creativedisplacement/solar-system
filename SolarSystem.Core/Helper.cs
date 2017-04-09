using System;
using System.Data.Entity.Core.Objects;

namespace SolarSystem.Core
{
    public class Helper
    {
        public static string GetModelName(Object o)
        {
            try
            {
                return ObjectContext.GetObjectType(o.GetType()).Name;
            }
            catch
            {
                throw new Exception("Cannot derive model name from type");
            }
        }
    }
}
