using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageSqlDB.DbContext
{
    class DbContext
    {

        private VillageDbContext context;



        public DbContext(VillageDbContext context)
        {
            this.context = context;
        }
    }
}
