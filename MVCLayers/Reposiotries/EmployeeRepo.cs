using MVCLayers.Models;

namespace MVCLayers.Reposiotries
{
    public class EmployeeRepo : IEmployeeRepo
    {
        CompanyDbContext DB;
        public EmployeeRepo()
        {
            DB = new CompanyDbContext();
        }

        public List<Employee> GetEmployee()
        {            
            return DB.Employees.ToList();
        }
        public Employee GetById(int id)
        {
            return DB.Employees.SingleOrDefault(s => s.SSN == id);
        }
        public int Add(Employee employee)
        {
            DB.Employees.Add(employee);
            return DB.SaveChanges();

        }
        public int Edit(Employee employee)
        {
            Employee oldEmployee = DB.Employees.Where(e => e.SSN == employee.SSN).SingleOrDefault();
            oldEmployee.Fname = employee.Fname;
            oldEmployee.LName = employee.LName;
            oldEmployee.Salary = employee.Salary;
            oldEmployee.Address = employee.Address;
            oldEmployee.BDate = employee.BDate;
            oldEmployee.Gender = employee.Gender;
            return DB.SaveChanges();

        }
        public int Delete(int id)
        {
            Employee employee = DB.Employees.Where(e => e.SSN == id).SingleOrDefault();
            DB.Employees.Remove(employee);
            return DB.SaveChanges();
        }
    }
}
