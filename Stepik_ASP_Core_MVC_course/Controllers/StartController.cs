using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class StartController : Controller
    {
        public string Hello()
        {
            var dtCurrent = DateTime.Now;
            
            if (dtCurrent.Hour < 6) return "Доброй ночи";
            if (dtCurrent.Hour < 12) return "Доброе утро";
            if (dtCurrent.Hour < 17) return "Добрый день";
            //if (dtCurrent.Hour >= 18 && dtCurrent.Hour < 24) return "Добрый вечер";
            return "Добрый вечер";
        }
                
        public ActionResult Index()
        {
            return View();
        }
                
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

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

        // GET: StartController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StartController1/Edit/5
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

        // GET: StartController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StartController1/Delete/5
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
