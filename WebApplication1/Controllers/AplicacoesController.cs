using HighMaintenance.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AplicacoesController : Controller
    {
        private ENTIDADES db = new ENTIDADES();

        // GET: Aplicacoes
        public ActionResult Index()
        {
            return View(db.APLICACOES.ToList());
        }

        // GET: Aplicacoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APLICACOES aPLICACOES = db.APLICACOES.Find(id);
            if (aPLICACOES == null)
            {
                return HttpNotFound();
            }
            return View(aPLICACOES);
        }

        // GET: Aplicacoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Aplicacoes/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "APP_ID,APP_NOME,APP_DESCRICAO,APP_TIPO,APP_VALIDADE,APP_RENTABILIDADE,APP_VALORMINIMO,APP_VALORMAXIMO,APP_VENCIMENTO")] APLICACOES aPLICACOES)
        {
            if (ModelState.IsValid)
            {
                db.APLICACOES.Add(aPLICACOES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aPLICACOES);
        }

        // GET: Aplicacoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APLICACOES aPLICACOES = db.APLICACOES.Find(id);
            if (aPLICACOES == null)
            {
                return HttpNotFound();
            }
            return View(aPLICACOES);
        }

        // POST: Aplicacoes/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "APP_ID,APP_NOME,APP_DESCRICAO,APP_TIPO,APP_VALIDADE,APP_RENTABILIDADE,APP_VALORMINIMO,APP_VALORMAXIMO,APP_VENCIMENTO")] APLICACOES aPLICACOES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPLICACOES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aPLICACOES);
        }

        // GET: Aplicacoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APLICACOES aPLICACOES = db.APLICACOES.Find(id);
            if (aPLICACOES == null)
            {
                return HttpNotFound();
            }
            return View(aPLICACOES);
        }

        // POST: Aplicacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            APLICACOES aPLICACOES = db.APLICACOES.Find(id);
            db.APLICACOES.Remove(aPLICACOES);
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
