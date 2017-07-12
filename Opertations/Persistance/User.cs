using System;
using System.Collections.Generic;
using System.Text;
using Incoding.Data;

namespace Operations.Persistance
{
   public class User : EntityBase
    {
        public virtual string Name { get; set; }

        public class Map : NHibernateEntityMap<User>
        {
            protected Map()
            {
                Id(r => r.Id).GeneratedBy.Assigned();
                MapEscaping(r => r.Name);
            }
        }
    }
}
