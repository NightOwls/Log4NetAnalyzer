using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Model
{
    public class LogAggregate
    {
        public string GroupItem { get; set; }
        public int Count { get; set; }
    }
}
