using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stepik_ASP_Core_MVC_course.Controllers
{
    public class CalculatorController : Controller
    {        
        public string Index(double a, double b, string str)
        {
            char c;
            if (str == null)
            {
                c = '+';
            }
            else
            {
                c = str[0];
            }

            if (c == '+' || c == '-' || c == '*')
            {
                switch (c)
                {
                    case '+':
                        return $"{a} + {b} = {a + b}";                        
                    case '-':
                        return $"{a} - {b} = {a - b}";                        
                    default:
                        return $"{a} * {b} = {a * b}";                        
                }
            }

            else
            {
                return "Math operation is false.";
            }
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

        public ActionResult Edit(int id)
        {
            return View();
        }

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

        public ActionResult Delete(int id)
        {
            return View();
        }

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
