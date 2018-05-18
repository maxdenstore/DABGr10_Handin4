using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsumerDocDB.Models;
using VillageSqlDB;

using VillageSqlDB.Interfaces;
using VillageSqlDB.Models;
using VillageSqlDB.Repositories;


namespace Grp10App
{
    class Program
    {
        static void Main(string[] args)
        {
            #region SQL local setup Village ( goes to unit of work )

            VillageDbContext villageContext = new VillageDbContext();
            VillageRepository villageRepo = new VillageRepository(villageContext);
            NationalRepository nationalRepo = new NationalRepository(new VillageDbContext());

            //try add a village

            var villages = villageRepo.GetAll().ToList();

            if (villages.Count < 1) //make sure i dont over populate db
            {
                //make national
                National danmark = new National();
        




                Village village = new Village();
                village.CookerAmount = 5;
                village.CookerCapacity = 5;
                village.VillageMeter = 100;

                

                Prosumer firstProsumer = new Prosumer();
                firstProsumer.prosumerType = "Prosumer";
                firstProsumer.smartmeter = 10;


                village.Villages.Add(firstProsumer);
                danmark.Villages.Add(village);



                nationalRepo.InsertNational(danmark);
                villageRepo.InsertVillage(village);

               

                nationalRepo.Save();
                villageRepo.Save();
            }

            



            #endregion

            #region SQL local setup National ( goes to unit of work )



            #endregion
        }
    }
}
