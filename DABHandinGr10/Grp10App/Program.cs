﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ProsumerDocDB.Models;
using UnitOfWork;
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
            /*
              VillageRepository villageRepo = new VillageRepository(new VillageDbContext());
              NationalRepository nationalRepo = new NationalRepository(new VillageDbContext());

              //try add a village



              var villages = villageRepo.GetAllAsync().Result.ToList();

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



      */

            #endregion


            #region UnitofWork
            /*
            SmartGridUnitOfWork unit = new SmartGridUnitOfWork();
            
            National unitofWorkNation = new National();
            unitofWorkNation.NationName = "NationThroughUnitOFWORK";

            Village unitofworkVillage = new Village();
            unitofworkVillage.VillageName = "unitofwrokvillage2";
            unitofworkVillage.CookerAmount = 200;
            unitofworkVillage.CookerCapacity = 300;
            unitofworkVillage.CookerConsumption = 400;


            

            //unit.CreateNational(unitofWorkNation);
            //unit.CreateVillage(unitofworkVillage, unitofWorkNation.NationName);


            unit.UpdateVillage(unitofworkVillage);

             */
            #endregion

            #region TestingProsumerInUnitOfWork
            /*
            SmartGridUnitOfWork unit = new SmartGridUnitOfWork();
            
            Prosumer testingProsumer = new Prosumer();
            testingProsumer.CopperID = "testingProsumerID1";
            testingProsumer.prosumerType = "testingtypeProsumer";
            testingProsumer.smartmeter = 0;
            testingProsumer.wallet = 1337;


            var result = unit.CreateProsumer(testingProsumer);

            Console.WriteLine(result.prosumerType);
            */
            #endregion


            #region TestingUnitOfWork

            
            SmartGridUnitOfWork unit = new SmartGridUnitOfWork();

            National danmark = new National();
            danmark.NationName = "Danmark";

            National Sverige = new National();
            Sverige.NationName = "sverige";

            unit.CreateNational(Sverige);
            unit.CreateNational(danmark);

            unit.DeleteNational(Sverige.NationName); //bye bye

            Village Aros = new Village();
            Aros.CookerAmount = 200;
            Aros.CookerCapacity = 200;
            Aros.CookerConsumption = 200;
            Aros.VillageMeter = 0;
            Aros.VillageName = "Aros";

            danmark.Villages.Add(Aros);

            unit.CreateVillage(Aros,danmark.NationName);

            unit.UpdateNational(danmark);

            Console.WriteLine(unit.ReadVillage(Aros.VillageName).VillageName);
            
            Console.WriteLine("adding prosumers to aros");

            Prosumer testingProsumer = new Prosumer();
            testingProsumer.CopperID = "testingProsumerID3";
            testingProsumer.prosumerType = "testingtypeProsumer";
            testingProsumer.smartmeter = 0;
            testingProsumer.wallet = 1337;
            testingProsumer.villageName = Aros.VillageName;


            var result = unit.CreateProsumer(testingProsumer);

            Console.WriteLine("added prosumer to db: " + result.prosumerType);

            //now get village where prosumer should be there!

            var updatedvillage = unit.ReadVillage(Aros.VillageName);

            foreach (var VARIABLE in updatedvillage.Villages)
            {
                Console.WriteLine("prosumers in aros smartmeters: "+ VARIABLE.smartmeter);
            }

            #endregion
        }
    }
}
