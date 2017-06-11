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
    public class VolantesController : ApiController
    {
        private _2015137465DbContext db = new _2015137465DbContext();

        // GET: api/Volantes
        public IQueryable<Volante> GetVolantes()
        {
            return db.Volantes;
        }

        // GET: api/Volantes/5
        [ResponseType(typeof(Volante))]
        public IHttpActionResult GetVolante(int id)
        {
            Volante volante = db.Volantes.Find(id);
            if (volante == null)
            {
                return NotFound();
            }

            return Ok(volante);
        }

        // PUT: api/Volantes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVolante(int id, Volante volante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != volante.CodigoVolante)
            {
                return BadRequest();
            }

            db.Entry(volante).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolanteExists(id))
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

        // POST: api/Volantes
        [ResponseType(typeof(Volante))]
        public IHttpActionResult PostVolante(Volante volante)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Volantes.Add(volante);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = volante.CodigoVolante }, volante);
        }

        // DELETE: api/Volantes/5
        [ResponseType(typeof(Volante))]
        public IHttpActionResult DeleteVolante(int id)
        {
            Volante volante = db.Volantes.Find(id);
            if (volante == null)
            {
                return NotFound();
            }

            db.Volantes.Remove(volante);
            db.SaveChanges();

            return Ok(volante);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VolanteExists(int id)
        {
            return db.Volantes.Count(e => e.CodigoVolante == id) > 0;
        }
    }
}