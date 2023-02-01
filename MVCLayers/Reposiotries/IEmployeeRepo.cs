using MVCLayers.Models;

namespace MVCLayers.Reposiotries
{
    public interface IEmployeeRepo
    {
        int Add(Employee employee);
        int Delete(int id);
        int Edit(Employee employee);
        List<Employee> GetEmployee();
        Employee GetById(int id);
    }
}