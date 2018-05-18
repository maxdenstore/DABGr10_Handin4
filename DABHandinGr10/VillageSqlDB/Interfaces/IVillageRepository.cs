using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VillageSqlDB.Models;

namespace VillageSqlDB.Interfaces
{
    public interface IVillageRepository
    {

        Task<List<Village>> GetAllAsync();


        Task<List<Village>> FindAsync(Expression<Func<Village, bool>> prediExpression);


        Task<Village> SingleOrDefaultAsync(Expression<Func<Village, bool>> prediExpression);

        Task<Village> FirstAsync(Expression<Func<Village, bool>> prediExpression);


        Task<Village> GetVillageByIDAsync(int villageId);
    

        void InsertVillage(Village village);


        void DeleteVillage(int villageID);


        void UpdateVillage(Village village);


        void Save();


        void Dispose(bool disposing);

        void Dispose();

    }
}