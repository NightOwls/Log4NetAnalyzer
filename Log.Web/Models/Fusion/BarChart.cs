using System.Collections.Generic;
using System.Xml.Serialization;

namespace Log.Web.Mvc.Models.Fusion
{
    [XmlType("graph")]
    public class BarChart : BaseFusion
    {
        [XmlAttribute("bgColor")]
        public string BgColor { get; set; }

        [XmlAttribute("bgAlpha")]
        public int BgAlpha { get; set; }

        [XmlAttribute("bgSWF")]
        public string BgSWF { get; set; }

        [XmlAttribute("canvasBgColor")]
        public string CanvasBgColor { get; set; }

        [XmlAttribute("canvasBgAlpha")]
        public int CanvasBgAlpha { get; set; }

        [XmlAttribute("canvasBorderColor")]
        public string CanvasBorderColor { get; set; }

        [XmlAttribute("canvasBorderThickness")]
        public int CanvasBorderThickness { get; set; }

        [XmlAttribute("caption")]
        public string Caption { get; set; }

        [XmlAttribute("xAxisName")]
        public string XAxisName { get; set; }

        [XmlAttribute("yAxisName")]
        public string YAxisName { get; set; }

        [XmlAttribute("subCaption")]
        public string SubCaption { get; set; }

        [XmlAttribute("showNames")]
        public int ShowNames { get; set; }

        [XmlAttribute("showValues")]
        public int ShowValues { get; set; }

        [XmlAttribute("animation")]
        public int Animation { get; set; }

        [XmlAttribute("showBarShadow")]
        public int ShowBarShadow { get; set; }

        [XmlAttribute("baseFont")]
        public string BaseFont { get; set; }

        [XmlAttribute("baseFontSize")]
        public string BaseFontSize { get; set; }

        [XmlAttribute("baseFontColor")]
        public string BaseFontColor { get; set; }

        [XmlAttribute("numberPrefix")]
        public string NumberPrefix { get; set; }

        [XmlAttribute("numberSuffix")]
        public string NumberSuffix { get; set; }

        [XmlAttribute("formatNumber")]
        public int FormatNumber { get; set; }

        [XmlAttribute("formatNumberScale")]
        public int FormatNumberScale { get; set; }

        [XmlAttribute("decimalSeparator")]
        public string DecimalSeparator { get; set; }

        [XmlAttribute("thousandSeparator")]
        public string ThousandSeparator { get; set; }

        [XmlAttribute("decimalPrecision")]
        public int DecimalPrecision { get; set; }

        [XmlAttribute("showhovercap")]
        public int ShowHoverCap { get; set; }

        [XmlAttribute("hoverCapBgColor")]
        public string HoverCapBgColor { get; set; }

        [XmlAttribute("hoverCapBorderColor")]
        public string HoverCapBorderColor { get; set; }

        [XmlAttribute("hoverCapSepChar")]
        public string HoverCapSepChar { get; set; }

        [XmlElement("set")]
        public List<ChartSet> Sets { get; set; }
    }
}