﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageSqlDB.Interfaces;
using VillageSqlDB.Models;

namespace VillageSqlDB
{
    public class VillageDbContext : System.Data.Entity.DbContext
    {
        public DbSet<IVillage> Villages { get; set; }
       

        public VillageDbContext():base("name")
        {

        }



    }
}
