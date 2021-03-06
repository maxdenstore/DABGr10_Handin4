﻿

using System;

using System.Collections.Generic;
using System.Linq.Expressions;

using System.Threading.Tasks;
using UnitOfWork.Interfaces;
using System.Linq;
using VillageSqlDB;
using VillageSqlDB.Models;
using VillageSqlDB.Repositories;
using System.Data.Entity;
using ProsumerDocDB.DbContext;
using ProsumerDocDB.Models;
using ProsumerDocDB.Repository;

namespace UnitOfWork
{
    public class SmartGridUnitOfWork : ISmartGridUnitOfWork 
    {
        #region Setup
        VillageRepository villageRepo = new VillageRepository(new VillageDbContext());
        NationalRepository nationalRepo = new NationalRepository(new VillageDbContext());
        ProsumerRepository prosumerRepo = new ProsumerRepository(new ProsumerDbContext());

        #endregion


        #region Create

        public Prosumer CreateProsumer(Prosumer prosumer)
        {
            if (prosumer != null)
            {
                prosumerRepo.AddProsumer(prosumer).Wait();
                return prosumerRepo.GetProsumerByCopperID(prosumer.CopperID);
            }

            return null;
        }

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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nationName"></param>
        /// <returns></returns>
        public National ReadNational(string nationName)
        {
            return nationalRepo.FirstAsync(national => national.NationName == nationName).Result;
        }

        /// <summary>
        /// find a village from its name
        /// </summary>
        /// <param name="VillageNamed">the name to search</param>
        /// <returns>if any, returns village, otherwise returns 0</returns>
        public Village ReadVillage(string VillageNamed)
        {
            //first get the village
            var village = villageRepo.FirstAsync(v => v.VillageName == VillageNamed).Result;


            //now get all prosumers that matches the name of village!
            var prosumers = prosumerRepo.GetALL(VillageNamed);


            if (prosumers != null)
            {
                //build together
                foreach (var VARIABLE in prosumers)
                {
                    village.Villages.Add(VARIABLE);
                }
            }


            // return the village
            return village;
        }

        public Prosumer ReadProsumer(string CopperID)
        {
            var prosumer = prosumerRepo.GetProsumerByCopperID(CopperID);
            return prosumer;
        }

        #endregion


        #region Update
        /// <summary>
        /// Update an exsisting nation, or adds the nation if it dosent exsist
        /// </summary>
        /// <param name="updated">the updated nation</param>
        /// <returns></returns>
        public National UpdateNational(National updated)
        {

            nationalRepo.UpdateNational(updated);

            //update prosumers too in villages DOCDB
    
            return updated;
        }

        /// <summary>
        /// updates an exsisting village, or adds the village if it dosent exsist
        /// </summary>
        /// <param name="Updated">the updated village</param>
        /// <returns></returns>
        public Village UpdateVillage(Village Updated)
        {

            villageRepo.UpdateVillage(Updated);

            //update prosumers in village too docDB

            return Updated;
        }

        public Prosumer UpdateProsumer(Prosumer updated)
        {
            prosumerRepo.DeleteProsumer(updated.CopperID);
            prosumerRepo.AddProsumer(updated).Wait();

            return prosumerRepo.GetProsumerByCopperID(updated.CopperID);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Deletes all nations with the specified name
        /// </summary>
        /// <param name="nationName">name to delete</param>
        public void DeleteNational(string nationName)
        {

            var tempNations = nationalRepo.FindAsync(x => x.NationName == nationName).Result.ToList();
            
            if (tempNations.Count > 0)
            {
                foreach (var VARIABLE in tempNations)
                {
                    nationalRepo.DeleteNational(VARIABLE.NationalID);
                }

                nationalRepo.Save();
            }
        }

        public void DeleteVillage(string VillageName)
        {
            throw new System.NotImplementedException();
        }
        #endregion


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
