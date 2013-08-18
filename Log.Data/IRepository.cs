using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log.Domain;

namespace Log.Data
{
    public interface IRepository<T, TK> 
        where T : IEntity
        where TK : class, T
    {

    }
}
