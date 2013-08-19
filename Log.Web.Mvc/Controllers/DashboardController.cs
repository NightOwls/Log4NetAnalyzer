using System.Collections.Generic;
using System.Web.Mvc;
using Log.Web.Mvc.Models;
using Log.Web.Mvc.Models.Fusion;

namespace Log.Web.Mvc.Controllers
{
    public class DashboardController : Controller
    {
        public ActionResult Index()
        {
            var widgets = new List<Widget>();
            var widget = new Widget {Id = 1, Title = "Test Widget"};

            var chart = new LineGraph();
            widget.Chart = chart;

            widgets.Add(widget);

            return View(widgets);
        }

        public LineGraph BuildLineGraph(string caption, List<Category> categories, List<Dataset> datasets)
        {
            return new LineGraph
            {
                Caption = caption,
                Categories = categories,
                Datasets = datasets,
                NumVDivLines = 10,
                BaseFontSize = "10",
                DivLineColor = "D7D8D3",
                DivLineAlpha = 80,
            };
        }

    }
}
