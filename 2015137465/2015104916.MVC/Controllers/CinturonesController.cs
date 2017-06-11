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
    public class CinturonesController : Controller
    {
        private _2015137465DbContext db = new _2015137465DbContext();

        // GET: Cinturones
        public ActionResult Index()
        {
            var cinturones = db.Cinturones.Include(c => c.Asiento);
            return View(cinturones.ToList());
        }

        // GET: Cinturones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinturon cinturon = db.Cinturones.Find(id);
            if (cinturon == null)
            {
                return HttpNotFound();
            }
            return View(cinturon);
        }

        // GET: Cinturones/Create
        public ActionResult Create()
        {
            ViewBag.CodigoAsiento = new SelectList(db.Asientos, "CodigoAsiento", "NumeroSerie");
            return View();
        }

        // POST: Cinturones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoCinturon,NumeroSerie,Metraje,CodigoAsiento")] Cinturon cinturon)
        {
            if (ModelState.IsValid)
            {
                db.Cinturones.Add(cinturon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CodigoAsiento = new SelectList(db.Asientos, "CodigoAsiento", "NumeroSerie", cinturon.CodigoAsiento);
            return View(cinturon);
        }

        // GET: Cinturones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinturon cinturon = db.Cinturones.Find(id);
            if (cinturon == null)
            {
                return HttpNotFound();
            }
            ViewBag.CodigoAsiento = new SelectList(db.Asientos, "CodigoAsiento", "NumeroSerie", cinturon.CodigoAsiento);
            return View(cinturon);
        }

        // POST: Cinturones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoCinturon,NumeroSerie,Metraje,CodigoAsiento")] Cinturon cinturon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cinturon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CodigoAsiento = new SelectList(db.Asientos, "CodigoAsiento", "NumeroSerie", cinturon.CodigoAsiento);
            return View(cinturon);
        }

        // GET: Cinturones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cinturon cinturon = db.Cinturones.Find(id);
            if (cinturon == null)
            {
                return HttpNotFound();
            }
            return View(cinturon);
        }

        // POST: Cinturones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cinturon cinturon = db.Cinturones.Find(id);
            db.Cinturones.Remove(cinturon);
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
