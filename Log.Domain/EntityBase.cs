using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log.Domain
{
    public abstract class EntityBase : IEntity
    {
        public virtual int Id { get; private set; }
    }
}
