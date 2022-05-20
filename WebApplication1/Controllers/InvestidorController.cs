using HighMaintenance.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class InvestidorController : Controller
    {
        private ENTIDADES db = new ENTIDADES();

        // GET: Investidor
        public ActionResult Index()
        {
            return View(db.INVESTIDOR.ToList());
        }

        // GET: Investidor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVESTIDOR iNVESTIDOR = db.INVESTIDOR.Find(id);
            if (iNVESTIDOR == null)
            {
                return HttpNotFound();
            }
            return View(iNVESTIDOR);
        }

        // GET: Investidor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Investidor/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "INV_ID,INV_NOME,INV_CPF,INV_RG,INV_NASCIMENTO,INV_TELEFONE,INV_CELULAR,INV_CIDADE,INV_CEP,INV_ESTADO,INV_EMAIL,INV_VALORGERAL")] INVESTIDOR iNVESTIDOR)
        {
            if (ModelState.IsValid)
            {
                db.INVESTIDOR.Add(iNVESTIDOR);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(iNVESTIDOR);
        }

        // GET: Investidor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVESTIDOR iNVESTIDOR = db.INVESTIDOR.Find(id);
            if (iNVESTIDOR == null)
            {
                return HttpNotFound();
            }
            return View(iNVESTIDOR);
        }

        // POST: Investidor/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "INV_ID,INV_NOME,INV_CPF,INV_RG,INV_NASCIMENTO,INV_TELEFONE,INV_CELULAR,INV_CIDADE,INV_CEP,INV_ESTADO,INV_EMAIL,INV_VALORGERAL")] INVESTIDOR iNVESTIDOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNVESTIDOR).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(iNVESTIDOR);
        }

        // GET: Investidor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVESTIDOR iNVESTIDOR = db.INVESTIDOR.Find(id);
            if (iNVESTIDOR == null)
            {
                return HttpNotFound();
            }
            return View(iNVESTIDOR);
        }

        // POST: Investidor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INVESTIDOR iNVESTIDOR = db.INVESTIDOR.Find(id);
            db.INVESTIDOR.Remove(iNVESTIDOR);
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
