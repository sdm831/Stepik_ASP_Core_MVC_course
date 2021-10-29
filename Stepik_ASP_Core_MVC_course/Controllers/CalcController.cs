using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class CalcController : Controller
    {
        // GET: CalcController
        public string Index()
        {
            return "lesson 2-4";
        }

        // GET: CalcController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CalcController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CalcController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CalcController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CalcController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CalcController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CalcController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
