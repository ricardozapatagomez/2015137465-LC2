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
    public class AutomovilesController : Controller
    {
        private _2015137465DbContext db = new _2015137465DbContext();
        public ActionResult Index()
        {
            var automoviles = db.Automoviles.Include(c => c.Ensambladora).Include(c => c.Parabrisas).Include(c => c.Propietario).Include(c => c.Volante);
            return View(automoviles.ToList());
        }

        // GET: Carros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro automoviles = db.Automoviles.Find(id);
            if (automoviles == null)
            {
                return HttpNotFound();
            }
            return View(automoviles);
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
        public ActionResult Create([Bind(Include = "CodigoCarro,NumserieCarro,NumserieChasis,CodigoEsambladora,TipoCarro,TipoAuto")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Automoviles.Add(automovil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoEsambladora = new SelectList(db.Ensambladoras, "CodigoEsambladora", "Nombre", automovil.CodigoEsambladora);
            ViewBag.CodigoCarro = new SelectList(db.Parabrisas, "CodigoParabrisas", "NumeroSerie", automovil.CodigoCarro);
            ViewBag.CodigoCarro = new SelectList(db.Propietarios, "CodigoPropietario", "Dni", automovil.CodigoCarro);
            ViewBag.CodigoCarro = new SelectList(db.Volantes, "CodigoVolante", "NumeroSerie", automovil.CodigoCarro);
            return View(automovil);
        }

        // GET: Carros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Carro automovil = db.Automoviles.Find(id);
            if (automovil == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoEsambladora = new SelectList(db.Ensambladoras, "CodigoEsambladora", "Nombre", automovil.CodigoEsambladora);
            ViewBag.CodigoCarro = new SelectList(db.Parabrisas, "CodigoParabrisas", "NumeroSerie", automovil.CodigoCarro);
            ViewBag.CodigoCarro = new SelectList(db.Propietarios, "CodigoPropietario", "Dni", automovil.CodigoCarro);
            ViewBag.CodigoCarro = new SelectList(db.Volantes, "CodigoVolante", "NumeroSerie", automovil.CodigoCarro);
            return View(automovil);
        }

        // POST: Carros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoCarro,NumserieCarro,NumserieChasis,CodigoEsambladora,TipoCarro,TipoAuto")] Automovil automovil)
        {
            if (ModelState.IsValid)
            {
                db.Entry(automovil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoEsambladora = new SelectList(db.Ensambladoras, "CodigoEsambladora", "Nombre", automovil.CodigoEsambladora);
            ViewBag.CodigoCarro = new SelectList(db.Parabrisas, "CodigoParabrisas", "NumeroSerie", automovil.CodigoCarro);
            ViewBag.CodigoCarro = new SelectList(db.Propietarios, "CodigoPropietario", "Dni", automovil.CodigoCarro);
            ViewBag.CodigoCarro = new SelectList(db.Volantes, "CodigoVolante", "NumeroSerie", automovil.CodigoCarro);
            return View(automovil);
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
