using PlanSync.Models;
using System.Xml.Serialization;

namespace PlanSync
{
    public static class Utilities
    {
        public static FlightPlan ReadFlightPlan(string path)
        {
            var reader = new XmlSerializer(typeof(SimBaseDocument));
            using StreamReader file = new(path);

            var doc = reader.Deserialize(file) as SimBaseDocument;

            var fpl = doc.FlightPlan;

            fpl.FilePath = path;
            return fpl;
        }
    }
}