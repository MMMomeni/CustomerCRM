using CustomerCRM.Core.Contracts.Service;
using CustomerCRM.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Antra.CustomerCRM.WebAppMVC.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRegionServiceAsync regionServiceAsync;
         private readonly ICustomerServiceAsync customerServiceAsync;

        public CustomerController(IRegionServiceAsync regionServiceAsync, ICustomerServiceAsync customerServiceAsync)
        {
            this.regionServiceAsync = regionServiceAsync;
            this.customerServiceAsync = customerServiceAsync;
        }
        public async Task<IActionResult> Index(string cityname="")
        {
            var result = await customerServiceAsync.GetAllAsync();
            return View(result);
        }

        public async Task<IActionResult> Detail(int id)
        {
            var result = await customerServiceAsync.GetCustomerByIdAsync(id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            /* This line will create a select list dropdown for our view*/
            ViewBag.Regions = new SelectList(await regionServiceAsync.GetAllRegions(), "Id", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CustomerModel model)
        {
            if (ModelState.IsValid)
            {
                await customerServiceAsync.InsertCustomerAsync(model);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
