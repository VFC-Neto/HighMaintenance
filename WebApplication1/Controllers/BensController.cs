using HighMaintenance.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class BensController : Controller
    {
        private ENTIDADES db = new ENTIDADES();

        // GET: Bens
        public ActionResult Index()
        {
            var bENS = db.BENS.Include(b => b.INVESTIDOR);
             
            decimal? valorBem = bENS.Select(a => a.BENS_VALOR).Sum();
            decimal? valorInvestidor = bENS.Select(a => a.INVESTIDOR.INV_VALORGERAL).Sum();
            decimal? valorReal = valorInvestidor + valorBem;
            Session["Valor"] = FormatTo2Dp(valorReal);

            return View(bENS.ToList());
        }

        public string FormatTo2Dp(decimal? myNumber)
        {
            return String.Format("{0:#,0.000}", myNumber);
        }

        // GET: Bens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENS bENS = db.BENS.Find(id);
            if (bENS == null)
            {
                return HttpNotFound();
            }
            return View(bENS);
        }

        // GET: Bens/Create
        public ActionResult Create()
        {
            ViewBag.INV_ID = new SelectList(db.INVESTIDOR, "INV_ID", "INV_NOME");
            return View();
        }

        // POST: Bens/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BENS_ID,INV_ID,BENS_NOME,BENS_TIPO,BENS_DESCRICAO,BENS_VALOR")] BENS bENS)
        {
            if (ModelState.IsValid)
            {
                db.BENS.Add(bENS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.INV_ID = new SelectList(db.INVESTIDOR, "INV_ID", "INV_NOME", bENS.INV_ID);
            return View(bENS);
        }

        // GET: Bens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENS bENS = db.BENS.Find(id);
            if (bENS == null)
            {
                return HttpNotFound();
            }
            ViewBag.INV_ID = new SelectList(db.INVESTIDOR, "INV_ID", "INV_NOME", bENS.INV_ID);
            return View(bENS);
        }

        // POST: Bens/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BENS_ID,INV_ID,BENS_NOME,BENS_TIPO,BENS_DESCRICAO,BENS_VALOR")] BENS bENS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bENS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.INV_ID = new SelectList(db.INVESTIDOR, "INV_ID", "INV_NOME", bENS.INV_ID);
            return View(bENS);
        }

        // GET: Bens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BENS bENS = db.BENS.Find(id);
            if (bENS == null)
            {
                return HttpNotFound();
            }
            return View(bENS);
        }

        // POST: Bens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BENS bENS = db.BENS.Find(id);
            db.BENS.Remove(bENS);
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
