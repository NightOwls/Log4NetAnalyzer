using System.Collections.Generic;
using Log.Enum;

namespace Log.Model
{
    public class ApplicationErrorAggregate
    {
        #region Public Properties 

        public string Application { get; set; }
        public Dictionary<LogLevel ,int> Errors { get; set; }

        #endregion

        #region Constructors 

        public ApplicationErrorAggregate()
        {
            Errors = new Dictionary<LogLevel, int>();
        }

        #endregion
    }
}
