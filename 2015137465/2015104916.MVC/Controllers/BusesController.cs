using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using _2015104916.Entities.Entities;
using _2015104916.Persistence;

namespace _2015104916.MVC.Controllers
{
    public class BusesController : Controller
    {
        private _2015137465DbContext db = new _2015137465DbContext();

        // GET: Carros
        public ActionResult Index()
        {
            var carros = db.Buses.Include(c => c.Ensambladora).Include(c => c.Parabrisas).Include(c => c.Propietario).Include(c => c.Volante);
            return View(carros.ToList());
        }

        // GET: Carros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro carro = db.Buses.Find(id);
            if (carro == null)
            {
                return HttpNotFound();
            }
            return View(carro);
        }

        // GET: Carros/Create
        public ActionResult Create()
        {
            ViewBag.CodigoEsambladora = new SelectList(db.Ensambladoras, "CodigoEsambladora", "Nombre");
            ViewBag.CodigoCarro = new SelectList(db.Parabrisas, "CodigoParabrisas", "NumeroSerie");
            ViewBag.CodigoCarro = new SelectList(db.Propietarios, "CodigoPropietario", "Dni");
            ViewBag.CodigoCarro = new SelectList(db.Volantes, "CodigoVolante", "NumeroSerie");
            return View();
        }

        // POST: Carros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoCarro,NumserieCarro,NumserieChasis,CodigoEsambladora,TipoCarro,TipoBus")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                db.AddB(bus, db);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoEsambladora = new SelectList(db.Ensambladoras, "CodigoEsambladora", "Nombre", bus.CodigoEsambladora);
            ViewBag.CodigoCarro = new SelectList(db.Parabrisas, "CodigoParabrisas", "NumeroSerie", bus.CodigoCarro);
            ViewBag.CodigoCarro = new SelectList(db.Propietarios, "CodigoPropietario", "Dni", bus.CodigoCarro);
            ViewBag.CodigoCarro = new SelectList(db.Volantes, "CodigoVolante", "NumeroSerie", bus.CodigoCarro);
            return View(bus);
        }

        // GET: Carros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoEsambladora = new SelectList(db.Ensambladoras, "CodigoEsambladora", "Nombre", bus.CodigoEsambladora);
            ViewBag.CodigoCarro = new SelectList(db.Parabrisas, "CodigoParabrisas", "NumeroSerie", bus.CodigoCarro);
            ViewBag.CodigoCarro = new SelectList(db.Propietarios, "CodigoPropietario", "Dni", bus.CodigoCarro);
            ViewBag.CodigoCarro = new SelectList(db.Volantes, "CodigoVolante", "NumeroSerie", bus.CodigoCarro);
            return View(bus);
        }

        // POST: Carros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoCarro,NumserieCarro,NumserieChasis,CodigoEsambladora,TipoCarro,TipoBus")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoEsambladora = new SelectList(db.Ensambladoras, "CodigoEsambladora", "Nombre", bus.CodigoEsambladora);
            ViewBag.CodigoCarro = new SelectList(db.Parabrisas, "CodigoParabrisas", "NumeroSerie", bus.CodigoCarro);
            ViewBag.CodigoCarro = new SelectList(db.Propietarios, "CodigoPropietario", "Dni", bus.CodigoCarro);
            ViewBag.CodigoCarro = new SelectList(db.Volantes, "CodigoVolante", "NumeroSerie", bus.CodigoCarro);
            return View(bus);
        }

        // GET: Carros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // POST: Carros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Carro bus = db.Buses.Find(id);
            db.Carros.Remove(bus);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
