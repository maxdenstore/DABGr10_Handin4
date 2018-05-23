using System;
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
    public class NationalsController : ApiController
    {
        private VillageSqlDB_APIContext db = new VillageSqlDB_APIContext();

        // GET: api/Nationals
        public IQueryable<National> GetNationals()
        {
            return db.Nationals;
        }

        // GET: api/Nationals/5
        [ResponseType(typeof(National))]
        public async Task<IHttpActionResult> GetNational(int id)
        {
            National national = await db.Nationals.FindAsync(id);
            if (national == null)
            {
                return NotFound();
            }

            return Ok(national);
        }

        // PUT: api/Nationals/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNational(int id, National national)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != national.NationalID)
            {
                return BadRequest();
            }

            db.Entry(national).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NationalExists(id))
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

        // POST: api/Nationals
        [ResponseType(typeof(National))]
        public async Task<IHttpActionResult> PostNational(National national)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Nationals.Add(national);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = national.NationalID }, national);
        }

        // DELETE: api/Nationals/5
        [ResponseType(typeof(National))]
        public async Task<IHttpActionResult> DeleteNational(int id)
        {
            National national = await db.Nationals.FindAsync(id);
            if (national == null)
            {
                return NotFound();
            }

            db.Nationals.Remove(national);
            await db.SaveChangesAsync();

            return Ok(national);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NationalExists(int id)
        {
            return db.Nationals.Count(e => e.NationalID == id) > 0;
        }
    }
}