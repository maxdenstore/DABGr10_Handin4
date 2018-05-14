using System.Collections.Generic;
using VillageSqlDB.Models;

namespace VillageSqlDB.Interfaces
{
    public interface IVillageRepository
    {
        IEnumerable<Village> GetVillage();
        Village GetVillageByID(int villageId);
        void InsertVillage(Village village);
        void DeleteVillage(int villageID);
        void UpdateVillage(Village village);
        void Save();
    }
}