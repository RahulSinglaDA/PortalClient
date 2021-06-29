using ClientCalls;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PortalClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PortalClient.Controllers
{

    public class EmployeeController : Controller
    {
        const string BASE_URL = "https://localhost:44366/api/employee";

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            string url = $"{BASE_URL}/{id}";
            Employee emp = CallManager<Employee>.Get(url);
            return View(emp);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                CallManager<Employee>.Post(emp, BASE_URL);
                return View("Details", emp);
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

        public ActionResult All()
        {
            return View(CallManager<IEnumerable<Employee>>.Get(BASE_URL));
        }

    }
}
