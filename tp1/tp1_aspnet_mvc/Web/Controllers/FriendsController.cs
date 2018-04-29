using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.ViewModel;
using Bussines;
using Web.Lib;

namespace Web.Controllers
{
    public class FriendsController : Controller
    {
        // GET: Friends
        public ActionResult Index()
        {
            List<Amigo> amigos = new List<Amigo>();
            amigos = Helper.ToViewModel(Rules.UsersList());
            return View(amigos);
        }

        public ActionResult WithBirthday()
        {
            List<Amigo> amigos = new List<Amigo>();
            amigos = Helper.ToViewModel(Rules.UsersList());
            return View(amigos);
        }

        public ActionResult WithEmail()
        {
            List<Amigo> amigos = new List<Amigo>();
            amigos = Helper.ToViewModel(Rules.UsersList());
            return View(amigos);
        }

        // POST: Friends/CreateCookie
        [HttpPost]
        public string CreateCookie(int PessoaID)
        {
            Rules.WriteCookie(PessoaID);
            return "_COOKEADO";
        }

        // GET: Friends/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Friends/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friends/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Friends/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Friends/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Friends/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Friends/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
