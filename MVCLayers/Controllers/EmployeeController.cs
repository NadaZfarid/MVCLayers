using Microsoft.AspNetCore.Mvc;
using MVCLayers.Services;
using MVCLayers.ViewModels;

namespace MVCLayers.Controllers
{
    public class EmployeeController : Controller
    {
        private  IEmployeeService employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }
        public IActionResult EmployeeList()
        {
            List<EmployeeVM> employees = employeeService.GetEmployees();
            return View(employees);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<EmployeeVM> employees = employeeService.GetEmployees();
            return View(employees);
        }
        [HttpPost]
        public IActionResult Add(EmployeeVM employeeVM)
        {
            employeeService.Add(employeeVM);
            List<EmployeeVM> employees = employeeService.GetEmployees();
            return RedirectToAction("EmployeeList", employees);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = employeeService.GetById(id);
            return View(employee);
        }
        [HttpPost]
        public IActionResult Edit(EmployeeVM employeeVM)
        {
            employeeService.Edit(employeeVM);
            List<EmployeeVM> employees = employeeService.GetEmployees();
            return RedirectToAction("EmployeeList", employees);
        }
        public IActionResult Delete(int id)
        {
            employeeService.Delete(id);
            List<EmployeeVM> employees = employeeService.GetEmployees();
            return RedirectToAction("EmployeeList",employees);
        }
    }
}
