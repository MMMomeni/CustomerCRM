using Microsoft.AspNetCore.Mvc;
using Antra.CustomerCRM.WebAppMVC.Models;

namespace Antra.CustomerCRM.WebAppMVC.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> lstEmployees = new List<Employee>
            {
                new Employee() {Id=1, FirstName = "Jack", LastName="Moore", Salary=61000, Department="IT"},
                new Employee() {Id=2, FirstName = "Goran", LastName="Somic", Salary=80000, Department="IT"},
                new Employee() {Id=3, FirstName = "John", LastName="Hence", Salary=90000, Department="IT"},
                new Employee() {Id=4, FirstName = "Sadaf", LastName="Ebrahimi", Salary=55000, Department="IT"}
            };
            
            return View(lstEmployees);
        }
    }
}
