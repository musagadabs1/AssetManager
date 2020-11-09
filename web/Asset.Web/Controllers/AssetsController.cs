﻿using Asset.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Asset.Web.Controllers
{
    public class AssetsController : Controller
    {
        private HttpClient client = new HttpClient();
        // GET: AssetsController
        public async Task<IActionResult> Index()
        {
            IEnumerable<AssetViewModel> assets = null;
            using (client =new HttpClient())
            {
                client.BaseAddress = new Uri("");
                var respondTask = await client.GetAsync("GetAssets");
                //respondTask.Wait();

                var result = respondTask;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsAsync<IList<AssetViewModel>>();
                    assets = readTask;
                }
                else
                {
                    assets = Enumerable.Empty<AssetViewModel>();
                    ModelState.AddModelError(string.Empty, "Server error. Please contact ICT");
                }
            }
            return View(assets);
        }

        // GET: AssetsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AssetsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AssetsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssetViewModel model)
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

        // GET: AssetsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AssetsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AssetViewModel model)
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

        // GET: AssetsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AssetsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, AssetViewModel model)
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
