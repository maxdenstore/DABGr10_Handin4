using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VillageSqlDB.DbContext;
using VillageSqlDB.Interfaces;
using VillageSqlDB.Models;

namespace VillageSqlDB.Repositories
{
    public class NationalRepository : INationalRepository, IDisposable
    {

        private VillageDbContext context;

        public NationalRepository(VillageDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<National> GetAll()
        {
            return context.Nationals;
        }

        public IEnumerable<National> Find(Expression<Func<National, bool>> prediExpression)
        {
            return context.Nationals.Where(prediExpression);
        }

        public National SingleOrDefault(Expression<Func<National, bool>> prediExpression)
        {
            return context.Nationals.SingleOrDefault(prediExpression);
        }

        public National First(Expression<Func<National, bool>> prediExpression)
        {
            return context.Nationals.First(prediExpression);
        }

        public National GetNationalByID(int NationalId)
        {
            return context.Nationals.Find(NationalId);
        }

        public void InsertNational(National National)
        {
            context.Nationals.Add(National);
        }

        public void DeleteNational(int NationalID)
        {
            National national = context.Nationals.Find(NationalID);
            context.Nationals.Remove(national);
        }

        public void UpdateNational(National National)
        {
            context.Entry(National).State = EntityState.Modified;
        }

        public async void Save()
        {
            await context.SaveChangesAsync();

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
