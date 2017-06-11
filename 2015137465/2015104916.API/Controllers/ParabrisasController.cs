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
    public class ParabrisasController : ApiController
    {
        private _2015137465DbContext db = new _2015137465DbContext();

        // GET: api/Parabrisas
        public IQueryable<Parabrisas> GetParabrisas()
        {
            return db.Parabrisas;
        }

        // GET: api/Parabrisas/5
        [ResponseType(typeof(Parabrisas))]
        public IHttpActionResult GetParabrisas(int id)
        {
            Parabrisas parabrisas = db.Parabrisas.Find(id);
            if (parabrisas == null)
            {
                return NotFound();
            }

            return Ok(parabrisas);
        }

        // PUT: api/Parabrisas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParabrisas(int id, Parabrisas parabrisas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parabrisas.CodigoParabrisas)
            {
                return BadRequest();
            }

            db.Entry(parabrisas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParabrisasExists(id))
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

        // POST: api/Parabrisas
        [ResponseType(typeof(Parabrisas))]
        public IHttpActionResult PostParabrisas(Parabrisas parabrisas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Parabrisas.Add(parabrisas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = parabrisas.CodigoParabrisas }, parabrisas);
        }

        // DELETE: api/Parabrisas/5
        [ResponseType(typeof(Parabrisas))]
        public IHttpActionResult DeleteParabrisas(int id)
        {
            Parabrisas parabrisas = db.Parabrisas.Find(id);
            if (parabrisas == null)
            {
                return NotFound();
            }

            db.Parabrisas.Remove(parabrisas);
            db.SaveChanges();

            return Ok(parabrisas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParabrisasExists(int id)
        {
            return db.Parabrisas.Count(e => e.CodigoParabrisas == id) > 0;
        }
    }
}