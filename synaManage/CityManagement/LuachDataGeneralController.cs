using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationLUACH.Controllers
{
    public class LuachDataGeneralController : Controller
    {
        // GET: LuachDataGeneral
        public ActionResult Index()
        {
            return View();
        }

        // GET: LuachDataGeneral/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LuachDataGeneral/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LuachDataGeneral/Create
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

        // GET: LuachDataGeneral/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LuachDataGeneral/Edit/5
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

        // GET: LuachDataGeneral/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LuachDataGeneral/Delete/5
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
