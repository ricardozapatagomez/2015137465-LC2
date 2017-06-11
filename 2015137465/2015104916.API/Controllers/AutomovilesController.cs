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
    public class AutomovilesController : ApiController
    {
        private _2015137465DbContext db = new _2015137465DbContext();

        // GET: api/Automoviles
        public IQueryable<Automovil> GetCarros()
        {
            return db.Automoviles;
        }

        // GET: api/Automoviles/5
        [ResponseType(typeof(Automovil))]
        public IHttpActionResult GetAutomovil(int id)
        {
            Automovil automovil = db.Automoviles.Find(id);
            if (automovil == null)
            {
                return NotFound();
            }

            return Ok(automovil);
        }

        // PUT: api/Automoviles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAutomovil(int id, Automovil automovil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != automovil.CodigoCarro)
            {
                return BadRequest();
            }

            db.Entry(automovil).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutomovilExists(id))
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

        // POST: api/Automoviles
        [ResponseType(typeof(Automovil))]
        public IHttpActionResult PostAutomovil(Automovil automovil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carros.Add(automovil);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (AutomovilExists(automovil.CodigoCarro))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = automovil.CodigoCarro }, automovil);
        }

        // DELETE: api/Automoviles/5
        [ResponseType(typeof(Automovil))]
        public IHttpActionResult DeleteAutomovil(int id)
        {
            Automovil automovil = db.Automoviles.Find(id);
            if (automovil == null)
            {
                return NotFound();
            }

            db.Carros.Remove(automovil);
            db.SaveChanges();

            return Ok(automovil);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AutomovilExists(int id)
        {
            return db.Carros.Count(e => e.CodigoCarro == id) > 0;
        }
    }
}