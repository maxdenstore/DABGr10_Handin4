

using System.Threading.Tasks;
using UnitOfWork.Interfaces;
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
                nationalRepo.InsertNational(nation);
                nationalRepo.Save();

                return nationalRepo.GetNationalByID(nation.NationalID);
            }

            return null;

        }
        /// <summary>
        /// Creates a viillage
        /// </summary>
        /// <param name="village">the village to create</param>
        /// <returns>created village if valid, else null</returns>
        public Village CreateVillage(Village village)
        {
            if (village != null)
            {
                villageRepo.InsertVillage(village);
                villageRepo.Save();

                return villageRepo.GetVillageByIDAsync(village.VillageID).Result;
            }

            return null;
        }
        #endregion


        #region Read
        public National ReadNational(string nationName)
        {
            throw new System.NotImplementedException();
        }

        public Village ReadVillage(string VillageName)
        {
            throw new System.NotImplementedException();
        }
        #endregion


        #region Update
        public National UpdateNational(National updated)
        {
            throw new System.NotImplementedException();
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
