using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Threading.Tasks;
using VillageSqlDB.Interfaces;
using VillageSqlDB.Models;


namespace VillageSqlDB.Repositories
{
    public class VillageRepository : IVillageRepository, IDisposable
    {
        private VillageDbContext context;

        public VillageRepository(VillageDbContext context)
        {
            this.context = context;
        }

        public Task<List<Village>> GetAllAsync()
        {
            return context.Villages.ToListAsync();
        }

        public Task<List<Village>> FindAsync(Expression<Func<Village, bool>> prediExpression)
        {
            return context.Villages.Where(prediExpression).ToListAsync();
        }

        public Task<Village> SingleOrDefaultAsync(Expression<Func<Village, bool>> prediExpression)
        {
            return context.Villages.SingleOrDefaultAsync(prediExpression);
        }

        public Task<Village> FirstAsync(Expression<Func<Village, bool>> prediExpression)
        {
            return context.Villages.FirstAsync(prediExpression);
        }

        public Task<Village> GetVillageByIDAsync(int villageId)
        {
            return context.Villages.FindAsync(villageId);
        }

        public async void InsertVillage(Village village)
        {
             context.Villages.Add(village);

        }

        public async void DeleteVillage(int villageID)
        {
            Task<Village> village = context.Villages.FindAsync(villageID);
;
            context.Villages.Remove(village.Result);

        }

        public async void UpdateVillage(Village village)
        {
            context.Entry(village).State = EntityState.Modified;

        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
