using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pregunta1.Models;

namespace admPregunta1.Controllers
{
    public class VelascoesController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Velascoes
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Velascoes.ToList());
        }

        // GET: Velascoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Velasco velasco = db.Velascoes.Find(id);
            if (velasco == null)
            {
                return HttpNotFound();
            }
            return View(velasco);
        }

        // GET: Velascoes/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Velascoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VelascoID,FriendofVelasco,place,Email,Birthdate")] Velasco velasco)
        {
            if (ModelState.IsValid)
            {
                db.Velascoes.Add(velasco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(velasco);
        }

        // GET: Velascoes/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Velasco velasco = db.Velascoes.Find(id);
            if (velasco == null)
            {
                return HttpNotFound();
            }
            return View(velasco);
        }

        // POST: Velascoes/Edit/5
        [Authorize]
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VelascoID,FriendofVelasco,place,Email,Birthdate")] Velasco velasco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(velasco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(velasco);
        }

        // GET: Velascoes/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Velasco velasco = db.Velascoes.Find(id);
            if (velasco == null)
            {
                return HttpNotFound();
            }
            return View(velasco);
        }

        // POST: Velascoes/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Velasco velasco = db.Velascoes.Find(id);
            db.Velascoes.Remove(velasco);
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
