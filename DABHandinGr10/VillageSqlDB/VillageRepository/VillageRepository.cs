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


namespace VillageSqlDB.VillageRepository
{
    public class VillageRepository : IVillageRepository, IDisposable
    {
        private VillageDbContext context;

        public VillageRepository(VillageDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<IVillage> GetAll()
        {
            return context.Villages;
        }

        public IEnumerable<IVillage> Find(Expression<Func<IVillage,bool>> prediExpression)
        {
            return context.Villages.Where(prediExpression);
        }

        public IVillage SingleOrDefault(Expression<Func<IVillage, bool>> prediExpression)
        {
            return context.Villages.SingleOrDefault(prediExpression);
        }


        public IVillage First(Expression<Func<IVillage, bool>> prediExpression)
        {
            return context.Villages.First(prediExpression);
        }

        public IVillage GetVillageByID(int villageId)
        {
            return context.Villages.Find(villageId);
        }

        public void InsertVillage(IVillage village)
        {
            context.Villages.Add(village);
        }

        public void DeleteVillage(int villageID)
        {
            IVillage student = context.Villages.Find(villageID);
            context.Villages.Remove(student);
        }

        public void UpdateVillage(IVillage village)
        {
            context.Entry(village).State = EntityState.Modified; 
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
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
