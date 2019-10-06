using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EstagiosEtec.Models;
using EstagiosEtec.AcessoDados;

namespace EstagiosEtec.Controllers
{
    public class TipoVagaController : Controller
    {
        private vagasContexto db = new vagasContexto();

        // GET: /TipoVaga/
        public ActionResult Index()
        {
            return View(db.tipoVagas.ToList());
        }

        // GET: /TipoVaga/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoVaga tipovaga = db.tipoVagas.Find(id);
            if (tipovaga == null)
            {
                return HttpNotFound();
            }
            return View(tipovaga);
        }

        // GET: /TipoVaga/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /TipoVaga/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,Nome")] tipoVaga tipovaga)
        {
            if (ModelState.IsValid)
            {
                db.tipoVagas.Add(tipovaga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipovaga);
        }

        // GET: /TipoVaga/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoVaga tipovaga = db.tipoVagas.Find(id);
            if (tipovaga == null)
            {
                return HttpNotFound();
            }
            return View(tipovaga);
        }

        // POST: /TipoVaga/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,Nome")] tipoVaga tipovaga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipovaga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipovaga);
        }

        // GET: /TipoVaga/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tipoVaga tipovaga = db.tipoVagas.Find(id);
            if (tipovaga == null)
            {
                return HttpNotFound();
            }
            return View(tipovaga);
        }

        // POST: /TipoVaga/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tipoVaga tipovaga = db.tipoVagas.Find(id);
            db.tipoVagas.Remove(tipovaga);
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
