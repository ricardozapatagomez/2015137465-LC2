using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using _2015104916.Entities.Entities;
using _2015104916.Persistence;

namespace _2015104916.API.Controllers
{
    public class AsientosController : ApiController
    {
        private _2015137465DbContext db = new _2015137465DbContext();

        // GET: api/Asientos
        public IQueryable<Asiento> GetAsientos()
        {
            return db.Asientos;
        }

        // GET: api/Asientos/5
        [ResponseType(typeof(Asiento))]
        public IHttpActionResult GetAsiento(int id)
        {
            Asiento asiento = db.Asientos.Find(id);
            if (asiento == null)
            {
                return NotFound();
            }

            return Ok(asiento);
        }

        // PUT: api/Asientos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsiento(int id, Asiento asiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asiento.CodigoAsiento)
            {
                return BadRequest();
            }

            db.Entry(asiento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsientoExists(id))
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

        // POST: api/Asientos
        [ResponseType(typeof(Asiento))]
        public IHttpActionResult PostAsiento(Asiento asiento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Asientos.Add(asiento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = asiento.CodigoAsiento }, asiento);
        }

        // DELETE: api/Asientos/5
        [ResponseType(typeof(Asiento))]
        public IHttpActionResult DeleteAsiento(int id)
        {
            Asiento asiento = db.Asientos.Find(id);
            if (asiento == null)
            {
                return NotFound();
            }

            db.Asientos.Remove(asiento);
            db.SaveChanges();

            return Ok(asiento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AsientoExists(int id)
        {
            return db.Asientos.Count(e => e.CodigoAsiento == id) > 0;
        }
    }
}