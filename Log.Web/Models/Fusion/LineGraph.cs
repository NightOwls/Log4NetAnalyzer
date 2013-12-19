using System.Collections.Generic;
using System.Xml.Serialization;

namespace Log.Web.Mvc.Models.Fusion
{
    [XmlType("graph")]
    public class LineGraph : BaseFusion
    {
        [XmlAttribute("caption")]
        public string Caption { get; set; }

        [XmlAttribute("showValues")]
        public int ShowValues { get; set; }

        [XmlAttribute("numVDivLines")]
        public int NumVDivLines { get; set; }

        [XmlAttribute("numberPrefix")]
        public string NumberPrefix { get; set; }

        [XmlAttribute("showAnchors")]
        public int ShowAnchors { get; set; }

        [XmlAttribute("divlinecolor")]
        public string DivLineColor { get; set; }

        [XmlAttribute("divLineAlpha")]
        public int DivLineAlpha { get; set; }

        [XmlAttribute("showAlternateHGridColor")]
        public int ShowAlternateHGridColor { get; set; }

        [XmlAttribute("alternateHGridColor")]
        public string AlternateHGridColor { get; set; }

        [XmlAttribute("alternateHGridAlpha")]
        public int AlternateHGridAlpha { get; set; }

        [XmlAttribute("bgColor")]
        public string BgColor { get; set; }

        [XmlAttribute("bgAlpha")]
        public int BgAlpha { get; set; }

        [XmlAttribute("baseFont")]
        public string BaseFont { get; set; }

        [XmlAttribute("baseFontSize")]
        public string BaseFontSize { get; set; }

        [XmlAttribute("baseFontColor")]
        public string BaseFontColor { get; set; }

        [XmlAttribute("canvasBorderThickness")]
        public int CanvasBorderThickness { get; set; }

        [XmlAttribute("decimalPrecision")]
        public int DecimalPrecision { get; set; }

        [XmlAttribute("yAxisMinValue")]
        public int YAxisMinValue { get; set; }

        [XmlArray("categories")]
        public List<Category> Categories { get; set; }

        [XmlElement("dataset")]
        public List<Dataset> Datasets { get; set; }
    }

    [XmlType("category")]
    public class Category
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }

    [XmlType("dataset")]
    public class Dataset
    {
        [XmlAttribute("seriesName")]
        public string SeriesName { get; set; }

        [XmlAttribute("color")]
        public string Color { get; set; }

        [XmlElement("set")]
        public List<LineGraphSet> Sets { get; set; }
    }

    [XmlType("set")]
    public class LineGraphSet
    {
        [XmlAttribute("value")]
        public int Value { get; set; }
    }
}