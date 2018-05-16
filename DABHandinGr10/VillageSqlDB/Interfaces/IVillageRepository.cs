using System.Collections.Generic;
using VillageSqlDB.Models;

namespace VillageSqlDB.Interfaces
{
    public interface IVillageRepository
    {
        IVillage GetVillageByID(int villageId);
        void InsertVillage(IVillage village);
        void DeleteVillage(int villageID);
        void UpdateVillage(IVillage village);
        void Save();
    }
}