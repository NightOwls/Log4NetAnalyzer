using Log.Web.Mvc.Models.Fusion;

namespace Log.Web.Mvc.Models
{
    public class Widget
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public BaseFusion Chart { get; set; }
    }
}