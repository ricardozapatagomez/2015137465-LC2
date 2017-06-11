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
    public class AsientosController : Controller
    {
        private _2015137465DbContext db = new _2015137465DbContext();

        // GET: Asientos
        public ActionResult Index()
        {
            var asientos = db.Asientos.Include(a => a.Carro);
            return View(asientos.ToList());
        }

        // GET: Asientos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento asiento = db.Asientos.Find(id);
            if (asiento == null)
            {
                return HttpNotFound();
            }
            return View(asiento);
        }

        // GET: Asientos/Create
        public ActionResult Create()
        {
            ViewBag.CodigoCarro = new SelectList(db.Carros, "CodigoCarro", "NumserieCarro");
            return View();
        }

        // POST: Asientos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoAsiento,NumeroSerie,CodigoCarro")] Asiento asiento)
        {
            if (ModelState.IsValid)
            {
                db.Asientos.Add(asiento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoCarro = new SelectList(db.Carros, "CodigoCarro", "NumserieCarro", asiento.CodigoCarro);
            return View(asiento);
        }

        // GET: Asientos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento asiento = db.Asientos.Find(id);
            if (asiento == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoCarro = new SelectList(db.Carros, "CodigoCarro", "NumserieCarro", asiento.CodigoCarro);
            return View(asiento);
        }

        // POST: Asientos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoAsiento,NumeroSerie,CodigoCarro")] Asiento asiento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asiento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoCarro = new SelectList(db.Carros, "CodigoCarro", "NumserieCarro", asiento.CodigoCarro);
            return View(asiento);
        }

        // GET: Asientos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asiento asiento = db.Asientos.Find(id);
            if (asiento == null)
            {
                return HttpNotFound();
            }
            return View(asiento);
        }

        // POST: Asientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Asiento asiento = db.Asientos.Find(id);
            db.Asientos.Remove(asiento);
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
