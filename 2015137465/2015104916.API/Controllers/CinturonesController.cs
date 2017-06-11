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
    public class CinturonesController : ApiController
    {
        private _2015137465DbContext db = new _2015137465DbContext();

        // GET: api/Cinturones
        public IQueryable<Cinturon> GetCinturones()
        {
            return db.Cinturones;
        }

        // GET: api/Cinturones/5
        [ResponseType(typeof(Cinturon))]
        public IHttpActionResult GetCinturon(int id)
        {
            Cinturon cinturon = db.Cinturones.Find(id);
            if (cinturon == null)
            {
                return NotFound();
            }

            return Ok(cinturon);
        }

        // PUT: api/Cinturones/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCinturon(int id, Cinturon cinturon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cinturon.CodigoCinturon)
            {
                return BadRequest();
            }

            db.Entry(cinturon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CinturonExists(id))
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

        // POST: api/Cinturones
        [ResponseType(typeof(Cinturon))]
        public IHttpActionResult PostCinturon(Cinturon cinturon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cinturones.Add(cinturon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cinturon.CodigoCinturon }, cinturon);
        }

        // DELETE: api/Cinturones/5
        [ResponseType(typeof(Cinturon))]
        public IHttpActionResult DeleteCinturon(int id)
        {
            Cinturon cinturon = db.Cinturones.Find(id);
            if (cinturon == null)
            {
                return NotFound();
            }

            db.Cinturones.Remove(cinturon);
            db.SaveChanges();

            return Ok(cinturon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CinturonExists(int id)
        {
            return db.Cinturones.Count(e => e.CodigoCinturon == id) > 0;
        }
    }
}