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

public class UsersController : Controller
    {
        private treinamento_webEntities db = new treinamento_webEntities();



        // GET: Users
        //public ActionResult Index()
        //{
        //    var users = db.users.ToList();
        //    if ( users != null)
        //        return View(users);
        //    else
        //        return View();
        //}|

        public ActionResult Index(string name, string ldapuid, string optradio, int? page)
        {
            //ViewBag.Filter = new { Name = !string.IsNullOrEmpty(name) ? name : "", Ldapuid = !string.IsNullOrEmpty(ldapuid) ? ldapuid : "", Optradio = !string.IsNullOrEmpty(optradio) ? optradio : "" };
            ViewBag.Filter = new string[] { !string.IsNullOrEmpty(name) ? name : "", !string.IsNullOrEmpty(ldapuid) ? ldapuid : "", !string.IsNullOrEmpty(optradio) ? optradio : "" };
            if (Session["user"] != null)
            {
                var users = db.users.Where(u => (string.IsNullOrEmpty(name) || (u.name.Contains(name))) &&
                                     (string.IsNullOrEmpty(ldapuid) || u.ldap_uid.Contains(ldapuid)) &&
                                    (optradio == "actives" ? u.ative: optradio == "inactives"? !u.ative : u.ative || !u.ative )
                                    ).ToList();

                ViewBag.Count = users.Count;
                ViewBag.Page = page ?? 1;
                
            return View(users.Skip(page.HasValue ? (page.Value - 1) * 3 : 0).Take(3));
            }

            return View("Index", "Home");
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,email,ldap_uid,ative,password")] users users)
        {
            if (ModelState.IsValid)
            {
                db.users.Add(users);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(users);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,email,ldap_uid,ative,password")] users users)
        {
            if (ModelState.IsValid)
            {
                db.Entry(users).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(users);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            users users = db.users.Find(id);
            if (users == null)
            {
                return HttpNotFound();
            }
            return View(users);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            users users = db.users.Find(id);
            db.users.Remove(users);
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
