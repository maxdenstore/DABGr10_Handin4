using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using VillageSqlDB.Models;

namespace VillageSqlDB.Interfaces
{
    public interface IVillageRepository
    {
        IEnumerable<Village> GetAll();

        IEnumerable<Village> Find(Expression<Func<Village, bool>> prediExpression);

        Village SingleOrDefault(Expression<Func<Village, bool>> prediExpression);

        Village First(Expression<Func<Village, bool>> prediExpression);

        Village GetVillageByID(int villageId);

        void InsertVillage(Village village);

        void DeleteVillage(int villageID);

        void UpdateVillage(Village village);

        void Save();

        void Dispose(bool disposing);

        void Dispose();

    }
}