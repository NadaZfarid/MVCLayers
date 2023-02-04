using MVCLayers.Models;
using MVCLayers.Reposiotries;
using MVCLayers.ViewModels;

namespace MVCLayers.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepo employeeRepo;
        public EmployeeService(IEmployeeRepo employeeRepo)
        {
            this.employeeRepo = employeeRepo;
        }
        public List<EmployeeVM> GetEmployees()
        {
            List<Employee> employees = employeeRepo.GetEmployee();
            List<EmployeeVM> employeeVMs = new List<EmployeeVM>();
            foreach (var EVM in employees)
            {
                employeeVMs.Add(new EmployeeVM()
                {
                    SSN = EVM.SSN,
                    Fname = EVM.Fname,
                    LName = EVM.LName,
                    Address = EVM.Address,
                    Salary = EVM.Salary,
                   // Dept_id = EVM.Dept_id,
                    BDate = EVM.BDate,
                    //Super_SSN = EVM.Super_SSN,
                    Gender = EVM.Gender,
                });
            }
            return employeeVMs;
        }
        public EmployeeVM GetById(int id)
        {
            Employee employee = employeeRepo.GetById(id);
            EmployeeVM employeeVM = new()
            {
                Address= employee.Address,
                Fname= employee.Fname,
                LName= employee.LName,
                Salary= employee.Salary,
                Gender = employee.Gender,
                BDate= employee.BDate,
                SSN= employee.SSN,

            };
            return employeeVM;
        }

        public int Add(EmployeeVM employeeVM)
        {
            Employee newEmployee = new Employee()
            {
                SSN = employeeVM.SSN,
                Fname = employeeVM.Fname,
                LName = employeeVM.LName,
                Address = employeeVM.Address,
                Salary = employeeVM.Salary,
                Gender = employeeVM.Gender,
                BDate = employeeVM.BDate,
            };
            return employeeRepo.Add(newEmployee);
        }
        public int Delete(int id)
        {
            return employeeRepo.Delete(id);
        }
        public int Edit(EmployeeVM employeeVM)
        {
            Employee newEmployee = new Employee()
            {
                SSN = employeeVM.SSN,
                Fname = employeeVM.Fname,
                LName = employeeVM.LName,
                Address = employeeVM.Address,
                Salary = employeeVM.Salary,
                Gender = employeeVM.Gender,
                BDate = employeeVM.BDate,
            };

            return employeeRepo.Edit(newEmployee);
        }

    }
}
