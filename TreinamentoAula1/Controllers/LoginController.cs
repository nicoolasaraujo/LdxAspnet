using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TreinamentoAula1.Models.Entity;
using TreinamentoAula1.Models.DataContract;


namespace TreinamentoAula1.Controllers
{
    public class LoginController : Controller
    {
        private readonly treinamento_webEntities db = new treinamento_webEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var user = db.users.Where(u => u.email == login.Username && u.password == login.Password);
                if (user.Any())
                {
                    Session["user"] = user;
                    return RedirectToAction("Index", "Users");
                }
                ModelState.AddModelError(string.Empty, "Usuário ou senha incoretos");

            }
            return View("Index", login);
        }
    }
}