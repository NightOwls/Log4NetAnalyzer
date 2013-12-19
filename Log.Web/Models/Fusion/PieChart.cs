using System.Collections.Generic;
using System.Xml.Serialization;

namespace Log.Web.Mvc.Models.Fusion
{
    [XmlType("graph")]
    public class PieChart : BaseFusion
    {
        [XmlAttribute("bgColor")]
        public string BgColor { get; set; }

        [XmlAttribute("bgAlpha")]
        public int BgAlpha { get; set; }

        [XmlAttribute("bgSWF")]
        public string BgSWF { get; set; }

        [XmlAttribute("caption")]
        public string Caption { get; set; }

        [XmlAttribute("subCaption")]
        public string SubCaption { get; set; }

        [XmlAttribute("showNames")]
        public int ShowNames { get; set; }

        [XmlAttribute("showValues")]
        public int ShowValues { get; set; }

        [XmlAttribute("showPercentageValues")]
        public int ShowPercentageValues { get; set; }

        [XmlAttribute("showPercentageInLabel")]
        public int ShowPercentageInLabel { get; set; }

        [XmlAttribute("animation")]
        public int Animation { get; set; }

        [XmlAttribute("pieRadius")]
        public int PieRadius { get; set; }

        [XmlAttribute("pieBorderThickness")]
        public int PieBorderThickness { get; set; }

        [XmlAttribute("pieBorderAlpha")]
        public int PieBorderAlpha { get; set; }

        [XmlAttribute("pieFillAlpha")]
        public int PieFillAlpha { get; set; }

        [XmlAttribute("pieBorderColor")]
        public string PieBorderColor { get; set; }

        [XmlAttribute("slicingDistance")]
        public int SlicingDistance { get; set; }

        [XmlAttribute("nameTBDistance")]
        public int NameTbDistance { get; set; }

        [XmlAttribute("showShadow")]
        public int ShowShadow { get; set; }

        [XmlAttribute("shadowColor")]
        public string ShadowColor { get; set; }

        [XmlAttribute("shadowAlpha")]
        public int ShadowAlpha { get; set; }

        [XmlAttribute("shadowXShift")]
        public int ShadowXShift { get; set; }

        [XmlAttribute("shadowYShift")]
        public int ShadowYShift { get; set; }

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
        public string FormatNumber { get; set; }

        [XmlAttribute("formatNumberScale")]
        public string FormatNumberScale { get; set; }

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