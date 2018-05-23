﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using VillageSqlDB.Models;
using VillageSqlDB_API.Models;

namespace VillageSqlDB_API.Controllers
{
    public class VillagesController : ApiController
    {
        private VillageSqlDB_APIContext db = new VillageSqlDB_APIContext();

        // GET: api/Villages
        public IQueryable<Village> GetVillages()
        {
            return db.Villages;
        }

        // GET: api/Villages/5
        [ResponseType(typeof(Village))]
        public async Task<IHttpActionResult> GetVillage(int id)
        {
            Village village = await db.Villages.FindAsync(id);
            if (village == null)
            {
                return NotFound();
            }

            return Ok(village);
        }

        // PUT: api/Villages/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVillage(int id, Village village)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != village.VillageID)
            {
                return BadRequest();
            }

            db.Entry(village).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VillageExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Villages
        [ResponseType(typeof(Village))]
        public async Task<IHttpActionResult> PostVillage(Village village)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Villages.Add(village);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = village.VillageID }, village);
        }

        // DELETE: api/Villages/5
        [ResponseType(typeof(Village))]
        public async Task<IHttpActionResult> DeleteVillage(int id)
        {
            Village village = await db.Villages.FindAsync(id);
            if (village == null)
            {
                return NotFound();
            }

            db.Villages.Remove(village);
            await db.SaveChangesAsync();

            return Ok(village);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VillageExists(int id)
        {
            return db.Villages.Count(e => e.VillageID == id) > 0;
        }
    }
}