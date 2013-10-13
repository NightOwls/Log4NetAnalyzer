using System;
using System.Collections.Generic;
using System.Linq;
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

            var categories = SetupCategories();
            var datasets = SetupDatasets();

            var chart = BuildLineGraph("My Graph", categories, datasets);
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

        public List<Category> SetupCategories()
        {
            var listOfHours = GetHoursForEvent(DateTime.Now.AddDays(-1), DateTime.Now);
            var categories = listOfHours.Select(x => new Category {Name = x.Hour.ToString()}).ToList();
            return categories;
        }

        public List<Dataset> SetupDatasets()
        {
            var dataset = new Dataset
            {
                Color = "D7D8D3",
                SeriesName = "Test",
                Sets = new List<LineGraphSet>
                {
                    new LineGraphSet {Value = 1},
                    new LineGraphSet {Value = 2},
                    new LineGraphSet {Value = 3},
                    new LineGraphSet {Value = 4},
                    new LineGraphSet {Value = 5},
                    new LineGraphSet {Value = 6},
                    new LineGraphSet {Value = 7},
                    new LineGraphSet {Value = 8},
                    new LineGraphSet {Value = 9},
                    new LineGraphSet {Value = 10},
                    new LineGraphSet {Value = 11},
                    new LineGraphSet {Value = 12},
                    new LineGraphSet {Value = 13},
                    new LineGraphSet {Value = 14},
                    new LineGraphSet {Value = 15},
                    new LineGraphSet {Value = 16},
                    new LineGraphSet {Value = 17},
                    new LineGraphSet {Value = 18},
                    new LineGraphSet {Value = 19},
                    new LineGraphSet {Value = 20},
                    new LineGraphSet {Value = 21},
                    new LineGraphSet {Value = 22},
                    new LineGraphSet {Value = 23},
                    new LineGraphSet {Value = 24},
                }
            };

            return new List<Dataset>{dataset};
        } 

        private IEnumerable<DateTime> GetHoursForEvent(DateTime start, DateTime end)
        {
            var hours = new List<DateTime>();
            var current = new DateTime(start.Year, start.Month, start.Day, start.Hour, 0, 0);
            while (current <= end)
            {
                hours.Add(current);
                current = current.AddHours(1);
            }
            return hours;
        }
    }
}
