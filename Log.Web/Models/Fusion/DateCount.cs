using System.Globalization;

namespace Log.Web.Mvc.Models.Fusion
{
    public class DateCount
    {
        #region Public Properties

        public int Count { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        public string MonthYearLabel
        {
            get
            {
                return string.Format("{0} {1}", CultureInfo.CurrentCulture.DateTimeFormat.GetAbbreviatedMonthName(Month), Year);
            }
        }

        #endregion
    }
}