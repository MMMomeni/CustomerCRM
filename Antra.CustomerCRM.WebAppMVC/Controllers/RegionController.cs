using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Antra.CustomerCRM.WebAppMVC.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionServiceAsync regionServiceAsync;
        public RegionController (IRegionServiceAsync _service)
        {
            regionServiceAsync = _service;
        }
        public async Task<IActionResult> Index()
        {
            var result = await regionServiceAsync.GetAllRegions();
            return View(result);
        }

        /* Since we cannot open a view with a post request and cannot use the Create extension in the URL
         * to open a view, we first open a view with a get request as below 
         * then the second Create method will be called to make the real post request */
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /* Submit button in the HTML will call only Create method and not Demo,
         * because post request in html looks for name "Create" and HTML submit does not
         * care about configuration and cares about convention
         */
        [HttpPost]
        public async Task<IActionResult> Create(RegionModel model)
        {
            if (ModelState.IsValid)
            {
               await regionServiceAsync.InsertRegion(model);
                return RedirectToAction("Index");
            }
            return View(model);

        }


        public async Task<IActionResult> Delete(int regionId)
        {
            await regionServiceAsync.DeleteRegion(regionId);
            return RedirectToAction("Index");
        }

        // This Edit() only shows the data on the screen.
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            RegionModel model = await regionServiceAsync.GetRegionById(id);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RegionModel model)
        {
            if (ModelState.IsValid)
            {
                await regionServiceAsync.UpdateRegion(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
