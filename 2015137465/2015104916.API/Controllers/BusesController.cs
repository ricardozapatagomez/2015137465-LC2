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
    public class BusesController : ApiController
    {
        private _2015137465DbContext db = new _2015137465DbContext();

        // GET: api/Buses
        public IQueryable<Bus> GetCarros()
        {
            return db.Buses;
        }

        // GET: api/Buses/5
        [ResponseType(typeof(Bus))]
        public IHttpActionResult GetBus(int id)
        {
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return NotFound();
            }

            return Ok(bus);
        }

        // PUT: api/Buses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBus(int id, Bus bus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bus.CodigoCarro)
            {
                return BadRequest();
            }

            db.Entry(bus).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusExists(id))
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

        // POST: api/Buses
        [ResponseType(typeof(Bus))]
        public IHttpActionResult PostBus(Bus bus)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Carros.Add(bus);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (BusExists(bus.CodigoCarro))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = bus.CodigoCarro }, bus);
        }

        // DELETE: api/Buses/5
        [ResponseType(typeof(Bus))]
        public IHttpActionResult DeleteBus(int id)
        {
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return NotFound();
            }

            db.Carros.Remove(bus);
            db.SaveChanges();

            return Ok(bus);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BusExists(int id)
        {
            return db.Carros.Count(e => e.CodigoCarro == id) > 0;
        }
    }
}