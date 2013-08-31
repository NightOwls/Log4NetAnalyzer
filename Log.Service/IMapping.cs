using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Service
{
    public interface IMapping
    {
        TK Map<T, TK>(T obj);
    }
}
