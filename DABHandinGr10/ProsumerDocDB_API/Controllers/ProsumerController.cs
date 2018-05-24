using ProsumerDocDB.DbContext;
using ProsumerDocDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace ProsumerDocDB_API.Controllers
{
    public class ProsumerController : ApiController
    {
        private ProsumerDocumentDBUnitOfWork db = new ProsumerDocumentDBUnitOfWork(new ProsumerDbContext());

        // GET: api/Prosumer/5
        [ResponseType(typeof(Prosumer))]
        public async Task<IHttpActionResult> Get(string id)
        {
            Prosumer prosumer = db._prosumerRepository.GetProsumerByCopperID(id);

            if (prosumer == null)
            {
                return NotFound();
            }

            return Ok(prosumer);
        }

        // POST: api/Prosumer
        [ResponseType(typeof(Prosumer))]
        public async Task<IHttpActionResult> Post(Prosumer prosumer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db._prosumerRepository.AddProsumer(prosumer).Wait();
                
            return CreatedAtRoute("DefaultApi", new { id = prosumer.CopperID }, prosumer);
        }

        // PUT: api/Prosumer/5
        //[ResponseType(typeof(Prosumer))]
        //public async Task<IHttpActionResult> Put(string id, Prosumer prosumer)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != prosumer.CopperID)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(prosumer).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (db._prosumerRepository.GetProsumerByCopperID(id) != null)
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        // DELETE: api/Prosumer/5
        [ResponseType(typeof(Prosumer))]
        public async Task<IHttpActionResult> Delete(string id)
        {
            Prosumer prosumer = db._prosumerRepository.GetProsumerByCopperID(id);

            if (prosumer == null)
            {
                return NotFound();
            }

            db._prosumerRepository.DeleteProsumer(prosumer.CopperID);

            return Ok(prosumer);
        }
    }
}
