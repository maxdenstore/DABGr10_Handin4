using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageSqlDB.Models;

namespace VillageSqlDB.DbContext
{
    class NationalsDbContext: DbContext
    {
        public DbSet<National> Nationals { get; set; }

        public NationalsDbContext():base("name")
        {
            
        }
    }
}
