using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TreinamentoAula1.Models.Entity;

namespace TreinamentoAula1.Controllers
{
    public class BranchesController : Controller
    {
        private treinamento_webEntities db = new treinamento_webEntities();

        // GET: Branches
        //public ActionResult Index()
        //{
        //    return View(db.branches.ToList());
        //}
        public ActionResult Index(string name_branch, string description, string product, string optradio, int? page)
        {
            //ViewBag.Filter = new { Name = !string.IsNullOrEmpty(name) ? name : "", Ldapuid = !string.IsNullOrEmpty(ldapuid) ? ldapuid : "", Optradio = !string.IsNullOrEmpty(optradio) ? optradio : "" };
            ViewBag.Filter = new string[] { !string.IsNullOrEmpty(name_branch) ? name_branch : "", !string.IsNullOrEmpty(description) ? description : "", !string.IsNullOrEmpty(description) ? description : "", !string.IsNullOrEmpty(optradio) ? optradio : "" };
            if (Session["user"] != null)
            {
                var users = db.branches.Where(u => (string.IsNullOrEmpty(name_branch) || (u.name.Contains(name_branch)))).ToList();
                                    //&& (string.IsNullOrEmpty(description) || u.description.Contains(description)) &&
                                    //(optradio == "actives" ? u.ative : optradio == "inactives" ? !u.ative : u.ative || !u.ative)
                                    //)
                                    //.ToList();

                ViewBag.Count = users.Count;
                ViewBag.Page = page ?? 1;

                return View(users.Skip(page.HasValue ? (page.Value - 1) * 3 : 0).Take(3));
            }

            return View("Index", "Home");
        }

        // GET: Branches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            branches branches = db.branches.Find(id);
            if (branches == null)
            {
                return HttpNotFound();
            }
            return View(branches);
        }

        // GET: Branches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Branches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,description,merge_executed,parent_branch,type,product,id")] branches branches)
        {
            if (ModelState.IsValid)
            {
                db.branches.Add(branches);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(branches);
        }

        // GET: Branches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            branches branches = db.branches.Find(id);
            if (branches == null)
            {
                return HttpNotFound();
            }
            return View(branches);
        }

        // POST: Branches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "name,description,merge_executed,parent_branch,type,product,id")] branches branches)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branches).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branches);
        }

        // GET: Branches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            branches branches = db.branches.Find(id);
            if (branches == null)
            {
                return HttpNotFound();
            }
            return View(branches);
        }

        // POST: Branches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            branches branches = db.branches.Find(id);
            db.branches.Remove(branches);
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
