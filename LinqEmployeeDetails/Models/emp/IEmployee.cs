using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetailsEntity.Models.emp
{
    public interface IEmployee
    {

        public Employee InsertEmployee(Employee employee);
        public Employee GetEmployee(int id);
        public List<Employee> GetAllEmployee();
        public EmployeeDto GetEmployeeDetailsAndEmployeeName(int id);
        public string UpdateEmployee(int id, Employee employee);
        public string DeleteEmployee(int id);

        public List<Employee> GetEmployeeAllFromJson();
    }
}
