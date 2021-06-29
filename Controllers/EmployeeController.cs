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
        // GET: EmployeeController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }


        // Post: EmployeeController/Details/
        public ActionResult Details(int id)
        {
            Employee emp = GetData(id);
            return View(emp);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                PostData(emp);
                return View("Details", emp);
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeController/Edit/5
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

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
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
            return View(GetAllData());
        }

        #region "Calls"
        public async void PostData(Employee emp)
        {
            string url = "https://localhost:44348/api/employee";
            using (HttpClient client = new HttpClient())
            {
                HttpContent reqContent = new StringContent(JsonConvert.SerializeObject(emp), Encoding.UTF8, "application/json");
                using (HttpResponseMessage res = await client.PostAsync(url, reqContent))
                {
                    HttpContent content = res.Content;
                    var responseJson = await content.ReadAsStringAsync();
                    Console.WriteLine(responseJson);
                }
            }
        }

        public Employee GetData(int id)
        {
            string url = $"https://localhost:44348/api/employee/{id}";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = client.GetAsync(url).Result)
                {
                    HttpContent content = res.Content;
                    string responseJson = content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Employee>(responseJson);
                }
            }
        }

        public IEnumerable<Employee> GetAllData()
        {
            string url = $"https://localhost:44348/api/employee";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = client.GetAsync(url).Result)
                {
                    HttpContent content = res.Content;
                    string responseJson = content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<Employee>>(responseJson);
                }
            }
        }
        #endregion
    }
}
