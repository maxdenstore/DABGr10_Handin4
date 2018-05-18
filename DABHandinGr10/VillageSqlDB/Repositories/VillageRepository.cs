﻿using System;
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

        public IEnumerable<Village> GetAll()
        {
            return context.Villages;
        }

        public IEnumerable<Village> Find(Expression<Func<Village,bool>> prediExpression)
        {
            return context.Villages.Where(prediExpression);
        }

        public Village SingleOrDefault(Expression<Func<Village, bool>> prediExpression)
        {
            return context.Villages.SingleOrDefault(prediExpression);
        }


        public Village First(Expression<Func<Village, bool>> prediExpression)
        {
            return context.Villages.First(prediExpression);
        }

        public Village GetVillageByID(int villageId)
        {
            return context.Villages.Find(villageId);
        }

        public void InsertVillage(Village village)
        {
            context.Villages.Add(village);
        }

        public void DeleteVillage(int villageID)
        {
            Village village = context.Villages.Find(villageID);
            context.Villages.Remove(village);
        }

        public void UpdateVillage(Village village)
        {
            context.Entry(village).State = EntityState.Modified; 
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
