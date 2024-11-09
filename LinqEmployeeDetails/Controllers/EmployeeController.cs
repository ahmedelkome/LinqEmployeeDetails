using EmployeeDetailsEntity.Models.emp;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDetailsEntity.Controllers
{

    [ApiController]
    [Route("EmployeeDetailsApi")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }


        [HttpPost]
        public IActionResult InsertEmployee(Employee employee)
        {
            var result = _employee.InsertEmployee(employee);
            return Ok(result);
        }


        [HttpGet("Getemployee")]
        public IActionResult GetEmployee(int id)
        {
            var result = _employee.GetEmployee(id);
            return Ok(result);
        }

        [HttpGet("GetAllEmployee")]
        public IActionResult GetAllEmployee()
        {
            var result = _employee.GetAllEmployee();
            return Ok(result);
        }

        [HttpGet]
        public IActionResult GetEmployeeDetails(int id)
        {
            var result = _employee.GetEmployeeDetailsAndEmployeeName(id);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult DeleteEmployee(int id)
        {
            var result = _employee.DeleteEmployee(id);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult UpdateEmployee(int id,Employee employee)
        {
            var result = _employee.UpdateEmployee(id,employee);
            return Ok(result);
        }




        [HttpGet("JsonGetapi")]
        public List<Employee> GetAllEmployeeFromJson()
        {
            return _employee.GetEmployeeAllFromJson();
        }
    }
}
