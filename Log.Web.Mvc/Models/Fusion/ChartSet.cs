using System.Xml.Serialization;

namespace Log.Web.Mvc.Models.Fusion
{
    [XmlType("set")]
    public class ChartSet
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("value")]
        public int Value { get; set; }

        [XmlAttribute("color")]
        public string Color { get; set; }

        [XmlAttribute("hoverText")]
        public string HoverText { get; set; }

        [XmlAttribute("link")]
        public string Link { get; set; }

        [XmlAttribute("showName")]
        public int ShowName { get; set; }
    }
}