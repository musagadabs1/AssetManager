using Asset.Web.Factory;
using Asset.Web.Models;
using Asset.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Asset.Web.Controllers
{
    public class AssetsController : Controller
    {
        private readonly IOptions<MySettingsModel> appSettings;
        public AssetsController(IOptions<MySettingsModel> app)
        {
            appSettings = app;
            //new Uri("https://localhost:44359/api/Assets/");
            //ApplicationSettings.WebApiUrl = appSettings.Value.WebApiBaseUrl;
            ApplicationSettings.WebApiUrl = "https://localhost:44359/api/Assets/";
        }
        private HttpClient client = new HttpClient();
        // GET: AssetsController
        public async Task<IActionResult> Index()
        {
            IEnumerable<AssetSummaryViewModel> assets = await ApiClientFactory.Instance.GetAssetSummaries(); 

            //var data = await ApiClientFactory.Instance.GetAssetSummaries();
            //assets = data;
            //using (client =new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:44359/api/Assets/");
            //    var respond = await client.GetAsync("GetAssetSummaries");

            //    if (respond.IsSuccessStatusCode)
            //    {
            //        assets = await respond.Content.ReadAsAsync<IList<AssetSummaryViewModel>>();
            //    }
            //    else
            //    {
            //        assets = Enumerable.Empty<AssetSummaryViewModel>();
            //        ModelState.AddModelError(string.Empty, "Server error. Please contact ICT");
            //    }
            //}
            return View(assets);
        }
        public async Task<IActionResult> AssetSummary()
        {
            IEnumerable<AssetViewModel> assets = null;//ApiClientFactory.Instance.GetAssetSummaries();
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44359/api/Assets/");
                var respond = await client.GetAsync("GetAssetSummaries");

                if (respond.IsSuccessStatusCode)
                {
                    assets = await respond.Content.ReadAsAsync<IList<AssetViewModel>>();
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
        public async Task<IActionResult> Details(string id)
        {
            //var getAssetsByEmployee=_u
            IEnumerable<AssetViewModel> assets = await ApiClientFactory.Instance.GetAssetDetails(id);
            //using (client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("https://localhost:44359/api/Assets/");
            //    var respond = await client.GetAsync("GetAssetsByEmployeeId/" + id);

            //    if (respond.IsSuccessStatusCode)
            //    {
            //        assets = await respond.Content.ReadAsAsync<IList<AssetViewModel>>();
            //    }
            //    else
            //    {
            //        assets = Enumerable.Empty<AssetViewModel>();
            //        ModelState.AddModelError(string.Empty, "Server error. Please contact ICT");
            //    }
            //}
            return View(assets);
        }
        // GET: AssetsController/Details/5
        public ActionResult ReturnDevice(int id)
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
        public async Task<JsonResult> Create(AssetViewModel model)
        {
            try
            {

                //CreateHttpContent<T>(content)

                var response = await ApiClientFactory.Instance.SaveAsset(model);
                //var respond = await client.PostAsync("PostAsset", CreateHttpContent model);

                //if (respond.IsSuccessStatusCode)
                //{
                //    assets = await respond.Content.ReadAsAsync<IList<AssetViewModel>>();
                //}
                //else
                //{
                //    assets = Enumerable.Empty<AssetViewModel>();
                //    ModelState.AddModelError(string.Empty, "Server error. Please contact ICT");
                //}
                return Json(response);
            }
            catch
            {
               throw new Exception("Something is wrong");
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
