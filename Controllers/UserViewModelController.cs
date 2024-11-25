using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProvaMVC.DAL;
using ProvaMVC.Models;

namespace ProvaMVC.Controllers
{
    public class UserViewModelController : Controller
    {
        private UserContext db = new UserContext();

        // GET: UserViewModel
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        // GET: UserViewModel/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userViewModel = db.User.Find(id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // GET: UserViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserViewModel/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,BirthDate,Password,ConfirmPassword")] UserViewModel userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.User.Add(userViewModel);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

                // Caso os dados do modelo sejam inválidos
                ViewBag.ErrorMessage = "Os dados fornecidos são inválidos. Por favor, verifique os campos e tente novamente.";
            }
            catch (Exception)
            {
                // Captura exceções e exibe uma mensagem amigável
                ViewBag.ErrorMessage = "Ocorreu um erro ao tentar cadastrar o usuário: ID ja cadastrado";
            }

            // Retorna a view com a mensagem de erro e os dados preenchidos
            return View(userViewModel);
        }

        // GET: UserViewModel/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userViewModel = db.User.Find(id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // POST: UserViewModel/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,BirthDate,Password,ConfirmPassword")] UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userViewModel);
        }

        // GET: UserViewModel/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserViewModel userViewModel = db.User.Find(id);
            if (userViewModel == null)
            {
                return HttpNotFound();
            }
            return View(userViewModel);
        }

        // POST: UserViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            UserViewModel userViewModel = db.User.Find(id);
            db.User.Remove(userViewModel);
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
        //dinamico

     
        public ActionResult CreateDinamico()
        {
            var model = new UserViewModel();
            return View(model);
        }

        //ajax
        public ActionResult Ajax()
        {
            var model = new UserViewModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Ajax(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index"); 
            }
            return View("CreateDinamico", model);
        }

    }
}
