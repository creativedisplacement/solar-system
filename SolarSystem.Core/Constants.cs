using System;
using System.Configuration;

namespace SolarSystem.Core
{
    public static class Constants
    {
        public static class API
        {
            public static int FAILURE_THRESHOLD = Convert.ToInt32(ConfigurationManager.AppSettings["API.FailureThreshold"]);
            public static int OPEN_CIRCUIT_TIMEOUT = Convert.ToInt32(ConfigurationManager.AppSettings["API.OpenCircuitTimeout"]);
        }
    }
}
