using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EstagiosEtec.Models;
using EstagiosEtec.AcessoDados;
using Microsoft.AspNet.Identity;

namespace EstagiosEtec.Controllers
{
    public class descricaoVagasController : Controller
    {
        private vagasContexto db = new vagasContexto();

        // GET: /descricaoVagas/
        public ActionResult Index()
        {
            bool btn = false;
            string user = "";

            if(ModelState.IsValid){
                user = User.Identity.GetUserName();
            }
            if (user == "Admin")
            {
                btn = true;
            }

            ViewBag.btn = btn;
            return View();
        }

        public JsonResult Listar( string searchPhrase, int current = 1, int rowCount = 5)
        {
            //sort[Titulo] || sort[diaPublicacao] || sort[dataMaxima] || sort[empresa] || sort[valor]
            string chave = Request.Form.AllKeys.Where(k => k.StartsWith("sort")).First();

            string ordenacao = Request[chave];
            string campo = chave.Replace("sort[", String.Empty).Replace("]", String.Empty);

            var descricaovagas = db.descricaoVagas.Include(d => d.tipoVaga);

            int total = descricaovagas.Count();

            if (!String.IsNullOrWhiteSpace(searchPhrase))
            {
                int ano = 0;
                int.TryParse(searchPhrase, out ano);

                decimal valor = 0.0m;
                decimal.TryParse(searchPhrase, out valor);
            
         
                descricaovagas = descricaovagas.Where("Titulo.Contains(@0) OR diaPublicacao == (@1) OR dataMaxima == (@1) OR empresa.Contains(@0) OR valor = (@2)", searchPhrase, ano, valor);
            }


            string campoOrdenacao = String.Format("{0} {1}", campo, ordenacao);

            var vagasPaginadas = descricaovagas.OrderBy(campoOrdenacao).Skip((current - 1) * rowCount).Take(rowCount);

            ViewBag.pagina = current;

            return Json(new {
                                rows = vagasPaginadas.ToList(),
                                current = current,
                                rowCount = rowCount,
                                total = total
                          }
                , JsonRequestBehavior.AllowGet);
        }

        // GET: /descricaoVagas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            descricaoVaga descricaovaga = db.descricaoVagas.Find(id);
            if (descricaovaga == null)
            {
                return HttpNotFound();
            }
            return PartialView(descricaovaga);
        }

        // GET: /descricaoVagas/Create
        public ActionResult Create()
        {
            ViewBag.tipoVagaid = new SelectList(db.tipoVagas, "id", "Nome");
            return PartialView();
        }

       

        // POST: /descricaoVagas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Titulo,diaPublicacao,dataMaxima,empresa,valor,tipoVagaid")] descricaoVaga descricaovaga)
        {
            if (ModelState.IsValid)
            {
                db.descricaoVagas.Add(descricaovaga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.tipoVagaid = new SelectList(db.tipoVagas, "id", "Nome", descricaovaga.tipoVagaid);
            return View(descricaovaga);
        }

        // GET: /descricaoVagas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            descricaoVaga descricaovaga = db.descricaoVagas.Find(id);
            if (descricaovaga == null)
            {
                return HttpNotFound();
            }
            ViewBag.tipoVagaid = new SelectList(db.tipoVagas, "id", "Nome", descricaovaga.tipoVagaid);
            return PartialView(descricaovaga);
        }

        // POST: /descricaoVagas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Titulo,diaPublicacao,dataMaxima,empresa,valor,tipoVagaid")] descricaoVaga descricaovaga)
        {
            if (ModelState.IsValid)
            {
                db.Entry(descricaovaga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.tipoVagaid = new SelectList(db.tipoVagas, "id", "Nome", descricaovaga.tipoVagaid);
            return View(descricaovaga);
        }

        // GET: /descricaoVagas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            descricaoVaga descricaovaga = db.descricaoVagas.Find(id);
            if (descricaovaga == null)
            {
                return HttpNotFound();
            }
            return PartialView(descricaovaga);
        }

        // POST: /descricaoVagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            descricaoVaga descricaovaga = db.descricaoVagas.Find(id);
            db.descricaoVagas.Remove(descricaovaga);
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
