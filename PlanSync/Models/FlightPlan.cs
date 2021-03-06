using ReactiveUI;
using System.Xml.Serialization;

namespace PlanSync.Models
{
    [XmlRoot(ElementName = "AppVersion")]
    public class AppVersion
    {
        [XmlElement(ElementName = "AppVersionBuild")]
        public string AppVersionBuild { get; set; }

        [XmlElement(ElementName = "AppVersionMajor")]
        public string AppVersionMajor { get; set; }
    }

    [XmlRoot(ElementName = "ATCWaypoint")]
    public class ATCWaypoint 
    {
        [XmlElement(ElementName = "ATCAirway")]
        public string ATCAirway { get; set; }

        [XmlElement(ElementName = "ATCWaypointType")]
        public string ATCWaypointType { get; set; }

        [XmlElement(ElementName = "DepartureFP")]
        public string DepartureFP { get; set; }

        [XmlElement(ElementName = "ICAO")]
        public ICAO ICAO { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "RunwayDesignatorFP")]
        public string RunwayDesignatorFP { get; set; }

        [XmlElement(ElementName = "RunwayNumberFP")]
        public string RunwayNumberFP { get; set; }

        [XmlElement(ElementName = "WorldPosition")]
        public string WorldPosition { get; set; }
    }

    [XmlRoot(ElementName = "FlightPlan.FlightPlan")]
    public class FlightPlan
    {
        public string FilePath { get; set; }

        [XmlElement(ElementName = "AppVersion")]
        public AppVersion AppVersion { get; set; }

        [XmlElement(ElementName = "ATCWaypoint")]
        public List<ATCWaypoint> ATCWaypoint { get; set; }

        [XmlElement(ElementName = "CruisingAlt")]
        public string CruisingAlt { get; set; }

        [XmlElement(ElementName = "DepartureID")]
        public string DepartureID { get; set; }

        [XmlElement(ElementName = "DepartureLLA")]
        public string DepartureLLA { get; set; }

        [XmlElement(ElementName = "DepartureName")]
        public string DepartureName { get; set; }

        [XmlElement(ElementName = "Descr")]
        public string Descr { get; set; }

        [XmlElement(ElementName = "DestinationID")]
        public string DestinationID { get; set; }

        [XmlElement(ElementName = "DestinationLLA")]
        public string DestinationLLA { get; set; }

        [XmlElement(ElementName = "DestinationName")]
        public string DestinationName { get; set; }

        [XmlElement(ElementName = "FPType")]
        public string FPType { get; set; }

        [XmlElement(ElementName = "RouteType")]
        public string RouteType { get; set; }

        [XmlElement(ElementName = "Title")]
        public string Title { get; set; }
    }

    [XmlRoot(ElementName = "ICAO")]
    public class ICAO
    {
        [XmlElement(ElementName = "ICAOIdent")]
        public string ICAOIdent { get; set; }

        [XmlElement(ElementName = "ICAORegion")]
        public string ICAORegion { get; set; }
    }

    [XmlRoot(ElementName = "SimBase.Document")]
    public class SimBaseDocument
    {
        [XmlElement(ElementName = "Descr")]
        public string Descr { get; set; }

        [XmlElement(ElementName = "FlightPlan.FlightPlan")]
        public FlightPlan FlightPlan { get; set; }

        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }
    }
}