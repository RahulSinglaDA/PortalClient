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
    public class DepartmentController : Controller
    {
        // GET: DepartmentController
        public ActionResult Index()
        {
            return View();
        }

        // GET: DepartmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DepartmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DepartmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department dep)
        {
            try
            {
                GetData(dep);
                return View();
            }
            catch
            {
                return View();
            }
        }

        public async void GetData(Department dep)
        {
            string url = "https://localhost:44348/api/department";
            using (HttpClient client = new HttpClient())
            {
                HttpContent reqContent = new StringContent(JsonConvert.SerializeObject(dep), Encoding.UTF8, "application/json");
                using (HttpResponseMessage res = await client.PostAsync(url, reqContent))
                {
                    HttpContent content = res.Content;
                    var responseJson = await content.ReadAsStringAsync();
                    Console.WriteLine(responseJson);
                }
            }
        }

        // GET: DepartmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DepartmentController/Edit/5
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

        // GET: DepartmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DepartmentController/Delete/5
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
