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
    public class VolantesController : Controller
    {
        private _2015137465DbContext db = new _2015137465DbContext();

        // GET: Volantes
        public ActionResult Index()
        {
            return View(db.Volantes.ToList());
        }

        // GET: Volantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volante volante = db.Volantes.Find(id);
            if (volante == null)
            {
                return HttpNotFound();
            }
            return View(volante);
        }

        // GET: Volantes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Volantes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoVolante,NumeroSerie")] Volante volante)
        {
            if (ModelState.IsValid)
            {
                db.Volantes.Add(volante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volante);
        }

        // GET: Volantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volante volante = db.Volantes.Find(id);
            if (volante == null)
            {
                return HttpNotFound();
            }
            return View(volante);
        }

        // POST: Volantes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoVolante,NumeroSerie")] Volante volante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(volante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volante);
        }

        // GET: Volantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volante volante = db.Volantes.Find(id);
            if (volante == null)
            {
                return HttpNotFound();
            }
            return View(volante);
        }

        // POST: Volantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volante volante = db.Volantes.Find(id);
            db.Volantes.Remove(volante);
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
