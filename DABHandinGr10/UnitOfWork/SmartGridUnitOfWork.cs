

using System;
<<<<<<< HEAD
=======
using System.Collections.Generic;
using System.Linq.Expressions;
>>>>>>> 5456c6dbd5fc55bba7b67be788c6aafc090bb5ca
using System.Threading.Tasks;
using UnitOfWork.Interfaces;
using System.Linq;
using VillageSqlDB;
using VillageSqlDB.Models;
using VillageSqlDB.Repositories;


namespace UnitOfWork
{
    public class SmartGridUnitOfWork : ISmartGridUnitOfWork
    {
        #region Setup
        VillageRepository villageRepo = new VillageRepository(new VillageDbContext());
        NationalRepository nationalRepo = new NationalRepository(new VillageDbContext());
        #endregion


        #region Create
        /// <summary>
        /// Creates a nation
        /// </summary>
        /// <param name="nation">The Nation to create</param>
        /// <returns>the created nation if its valid, else null</returns>
        public National CreateNational(National nation)
        {
           
            if (nation != null)
            {

                try
                {
                    var exsist = nationalRepo.FirstAsync(x => x.NationName == nation.NationName).Result;
                    return exsist;
                }
                catch (Exception e)
                {
                    nationalRepo.InsertNational(nation);
                    nationalRepo.Save();

                    var returner = nationalRepo.FirstAsync(n => n.NationName == nation.NationName).Result;
                    return returner;
                }


            }

            return null;

        }
        /// <summary>
        /// Creates a viillage
        /// </summary>
        /// <param name="village">the village to create</param>
        /// <returns>created village if valid, else null</returns>
        public Village CreateVillage(Village village, string nationName)
        {
            //get the nation where village belongs
            var tempNation = nationalRepo.FirstAsync(name => name.NationName == nationName).Result;

            if (village != null && tempNation != null)
            {
                try
                {
                    //returns the village because its there already
                    var exsist = villageRepo.FirstAsync(x => x.VillageName == village.VillageName).Result;
                    return exsist;
                }
                catch (Exception e)
                {

                    //add the village to the nation
                    tempNation.Villages.Add(village);

                    //update nation
                    //nationalRepo.UpdateNational(tempNation);
                    nationalRepo.Save();

                    var returner = villageRepo.FirstAsync(v => v.VillageName == village.VillageName).Result;

                    return returner;
                }
            }

            return null;
        }
        #endregion


        #region Read
        public National ReadNational(string nationName)
        {

            var nation = new National();
            nationalRepo.Find(national => nation.NationName == nationName);
            return nation;
        }

        public Village ReadVillage(string VillageNamed)
        {
            var village = new Village();
            villageRepo.FindAsync(x => x.VillageName == VillageNamed);
            return village;
        }

        #endregion


        #region Update
        public National UpdateNational(National updated)
        {

            nationalRepo.UpdateNational(updated);

            return updated;
        }

        public Village UpdateVillage(Village Updated)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Delete
        public National DeleteNational(string nationName)
        {
            throw new System.NotImplementedException();
        }

        public Village DeleteVillage(string VillageName)
        {
            throw new System.NotImplementedException();
        }
        #endregion






    }
}
