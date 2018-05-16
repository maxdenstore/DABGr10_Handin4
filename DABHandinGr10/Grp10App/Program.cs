using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageSqlDB;
using VillageSqlDB.VillageRepository;

namespace Grp10App
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SQL local setup Village ( goes to unit of work )

            VillageDbContext villageContext = new VillageDbContext();
            VillageRepository villageRepo = new VillageRepository(villageContext); 




            #endregion

            #region SQL local setup National ( goes to unit of work )



            #endregion
        }
    }
}
