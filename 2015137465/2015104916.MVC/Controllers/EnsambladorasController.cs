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
    public class EnsambladorasController : Controller
    {
        private _2015137465DbContext db = new _2015137465DbContext();

        // GET: Ensambladoras
        public ActionResult Index()
        {
            return View(db.Ensambladoras.ToList());
        }

        // GET: Ensambladoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ensambladora ensambladora = db.Ensambladoras.Find(id);
            if (ensambladora == null)
            {
                return HttpNotFound();
            }
            return View(ensambladora);
        }

        // GET: Ensambladoras/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ensambladoras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CodigoEsambladora,Nombre")] Ensambladora ensambladora)
        {
            if (ModelState.IsValid)
            {
                db.Ensambladoras.Add(ensambladora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ensambladora);
        }

        // GET: Ensambladoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ensambladora ensambladora = db.Ensambladoras.Find(id);
            if (ensambladora == null)
            {
                return HttpNotFound();
            }
            return View(ensambladora);
        }

        // POST: Ensambladoras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CodigoEsambladora,Nombre")] Ensambladora ensambladora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ensambladora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ensambladora);
        }

        // GET: Ensambladoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ensambladora ensambladora = db.Ensambladoras.Find(id);
            if (ensambladora == null)
            {
                return HttpNotFound();
            }
            return View(ensambladora);
        }

        // POST: Ensambladoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ensambladora ensambladora = db.Ensambladoras.Find(id);
            db.Ensambladoras.Remove(ensambladora);
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
