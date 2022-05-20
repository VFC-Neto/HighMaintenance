using HighMaintenance.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class AppInvestidorController : Controller
    {
        private ENTIDADES db = new ENTIDADES();

        // GET: AppInvestidor
        public ActionResult Index()
        {
            var aPPXINVESTIDOR = db.APPXINVESTIDOR.Include(a => a.APLICACOES).Include(a => a.INVESTIDOR);

            var bENS = db.BENS.Include(b => b.INVESTIDOR);
            decimal? valorBem = bENS.Select(a => a.BENS_VALOR).Sum();
            decimal? valorInvestidor = bENS.Select(a => a.INVESTIDOR.INV_VALORGERAL).Sum();
            decimal? valorReal = valorInvestidor + valorBem;
            Session["Valor"] = FormatTo2Dp(valorReal);

            return View(aPPXINVESTIDOR.ToList());
        }


        public string FormatTo2Dp(decimal? myNumber)
        {
            return String.Format("{0:#,0.000}", myNumber);
        }

        // GET: AppInvestidor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPXINVESTIDOR aPPXINVESTIDOR = db.APPXINVESTIDOR.Find(id);
            if (aPPXINVESTIDOR == null)
            {
                return HttpNotFound();
            }
            return View(aPPXINVESTIDOR);
        }

        // GET: AppInvestidor/Create
        public ActionResult Create()
        {
            ViewBag.APP_ID = new SelectList(db.APLICACOES, "APP_ID", "APP_NOME");
            ViewBag.INV_ID = new SelectList(db.INVESTIDOR, "INV_ID", "INV_NOME");
            return View();
        }

        // POST: AppInvestidor/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "APPIN_ID,APP_ID,INV_ID,APPIN_VALORINVESTIDO")] APPXINVESTIDOR aPPXINVESTIDOR)
        {
            if (ModelState.IsValid)
            {
                var Teste = db.APLICACOES.Where(a => a.APP_ID == aPPXINVESTIDOR.APP_ID).FirstOrDefault();
                decimal percent = decimal.Parse(Teste.APP_RENTABILIDADE) * aPPXINVESTIDOR.APPIN_VALORINVESTIDO / decimal.Parse(Teste.APP_VALIDADE);
                aPPXINVESTIDOR.APPIN_VALORRETIRADO = percent;

                db.APPXINVESTIDOR.Add(aPPXINVESTIDOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.APP_ID = new SelectList(db.APLICACOES, "APP_ID", "APP_NOME", aPPXINVESTIDOR.APP_ID);
            ViewBag.INV_ID = new SelectList(db.INVESTIDOR, "INV_ID", "INV_NOME", aPPXINVESTIDOR.INV_ID);
            return View(aPPXINVESTIDOR);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calcular([Bind(Include = "APPIN_ID,APP_ID,INV_ID,APPIN_VALORINVESTIDO")] APPXINVESTIDOR aPPXINVESTIDOR)
        {
            if (ModelState.IsValid)
            {
                var Teste = db.APPXINVESTIDOR.Where(a => a.APLICACOES.APP_ID == aPPXINVESTIDOR.APP_ID).FirstOrDefault();
                decimal percent = decimal.Parse(Teste.APLICACOES.APP_RENTABILIDADE) * aPPXINVESTIDOR.APPIN_VALORINVESTIDO / int.Parse(Teste.APLICACOES.APP_VALIDADE);
                aPPXINVESTIDOR.APPIN_VALORRETIRADO = percent;

            }

            ViewBag.APP_ID = new SelectList(db.APLICACOES, "APP_ID", "APP_NOME", aPPXINVESTIDOR.APP_ID);
            ViewBag.INV_ID = new SelectList(db.INVESTIDOR, "INV_ID", "INV_NOME", aPPXINVESTIDOR.INV_ID);
            return View(aPPXINVESTIDOR);
        }

        // GET: AppInvestidor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPXINVESTIDOR aPPXINVESTIDOR = db.APPXINVESTIDOR.Find(id);
            if (aPPXINVESTIDOR == null)
            {
                return HttpNotFound();
            }
            ViewBag.APP_ID = new SelectList(db.APLICACOES, "APP_ID", "APP_NOME", aPPXINVESTIDOR.APP_ID);
            ViewBag.INV_ID = new SelectList(db.INVESTIDOR, "INV_ID", "INV_NOME", aPPXINVESTIDOR.INV_ID);
            return View(aPPXINVESTIDOR);
        }

        // POST: AppInvestidor/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "APPIN_ID,APP_ID,INV_ID,APPIN_VALORINVESTIDO,APPIN_VALORRETIRADO")] APPXINVESTIDOR aPPXINVESTIDOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPPXINVESTIDOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.APP_ID = new SelectList(db.APLICACOES, "APP_ID", "APP_NOME", aPPXINVESTIDOR.APP_ID);
            ViewBag.INV_ID = new SelectList(db.INVESTIDOR, "INV_ID", "INV_NOME", aPPXINVESTIDOR.INV_ID);
            return View(aPPXINVESTIDOR);
        }

        // GET: AppInvestidor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPXINVESTIDOR aPPXINVESTIDOR = db.APPXINVESTIDOR.Find(id);
            if (aPPXINVESTIDOR == null)
            {
                return HttpNotFound();
            }
            return View(aPPXINVESTIDOR);
        }

        // POST: AppInvestidor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            APPXINVESTIDOR aPPXINVESTIDOR = db.APPXINVESTIDOR.Find(id);
            db.APPXINVESTIDOR.Remove(aPPXINVESTIDOR);
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
