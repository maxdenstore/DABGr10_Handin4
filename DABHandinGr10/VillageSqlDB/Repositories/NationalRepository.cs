using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
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
        public Task<List<National>> GetAll()
        {
            return context.Nationals.ToListAsync();
        }

        public Task<List<National>> FindAsync(Expression<Func<National, bool>> prediExpression)
        {
            return context.Nationals.Where(prediExpression).ToListAsync();
        }

        public Task<National> SingleOrDefaultAsync(Expression<Func<National, bool>> prediExpression)
        {
            return context.Nationals.SingleOrDefaultAsync(prediExpression);
        }

        public Task<National> FirstAsync(Expression<Func<National, bool>> prediExpression)
        {
            return context.Nationals.FirstAsync(prediExpression);
        }

        public Task<National> GetNationalByIDAsync(int NationalId)
        {
            return context.Nationals.FindAsync(NationalId);
        }

        public  void InsertNational(National National)
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
            var temp = context.Nationals.FirstAsync(x => x.NationName == National.NationName).Result;
            National.NationalID = temp.NationalID;


            context.Nationals.AddOrUpdate(National);
            Save();


        }

        public  void Save()
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
