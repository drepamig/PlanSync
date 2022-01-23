using PlanSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            return doc.FlightPlan;
        }
    }
}
