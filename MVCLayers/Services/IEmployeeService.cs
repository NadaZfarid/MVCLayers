using MVCLayers.Models;
using MVCLayers.ViewModels;

namespace MVCLayers.Services
{
    public interface IEmployeeService
    {
        int Add(EmployeeVM employeeVM);
        int Delete(int id);
        int  Edit(EmployeeVM employeeVM);
        List<EmployeeVM> GetEmployees();
        EmployeeVM GetById(int id);
    }
}