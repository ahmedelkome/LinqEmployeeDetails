
using LinqEmployeeDetails.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EmployeeDetailsEntity.Models.emp
{
    public class SqlEmployee : IEmployee
    {
        private readonly ApplicationDbContext _context;

        public SqlEmployee(ApplicationDbContext context)
        {
            _context = context;
        }

        public string DeleteEmployee(int id)

        {
            if (id > 0)
            {
                var resultEmployee = _context.employees.Where(e => e.id == id).FirstOrDefault();

                if (resultEmployee != null)
                {
                    _context.employees.Where(e => e.id == id)
                       .ExecuteDelete();

                    _context.employeeDetails.Where(d => d.Employeeid == id)
                        .ExecuteDelete();

                    _context.SaveChanges();

                    return "Delete Successfully";
                }
                else
                {
                    return "Can't Find Employee";
                }

            }
            else
            {
                return "Invalid Id";
            }
        }

        public Employee GetEmployee(int id)
        {
            if (id > 0)
            {
                var result = _context.employees.Where(e => e.id == id)
                    .Select(e => new Employee
                    {
                        id = e.id,
                        fName = e.fName,
                        lName = e.lName,
                        country = e.country,
                        salary = e.salary,
                        phone = e.phone,
                        age = e.age,
                        gender = e.gender,
                        state = e.state,
                        EmployeeDetails = (List<EmployeeDetails>)_context.employeeDetails.Where(d => d.Employeeid == id)
                        .Select(d => d)
                    }).FirstOrDefault() ?? new Employee();

                return result;
            }
            else return new Employee();

        }

        public EmployeeDto GetEmployeeDetailsAndEmployeeName(int id)
        {
            if (id > 0)
            {
                var result = _context.employeeDetails
                    .Where(d => d.id == id)
                   .Select(d => new EmployeeDto
                   {
                       id = d.id,
                       city = d.city,
                       experience = d.experience,
                       jobTitle = d.jobTitle,
                       Employeename = _context.employees.Where(
                           e => e.id == d.Employeeid)
                       .Select(e => e.fName)
                       .FirstOrDefault()

                   }).FirstOrDefault();


                /*
                 var result = _context.employeeDetails
                    .Where(d => d.id == id)
                   .Select(d => new EmployeeDto
                   {
                       id = d.id,
                       city = d.city,
                       experience = d.experience,
                       jobTitle = d.jobTitle,
                       Employeename = _context.employees.Where(
                           e => e.id == d.Employeeid)
                       .Select(e => e.fName)
                       .FirstOrDefault()

                   }).FirstOrDefault();
                 */

                if (result == null)
                {
                    return null;
                }

                return result;
            }
            else
            {
                return null;
            }
        }

        public Employee InsertEmployee(Employee employee)
        {
            if (employee.EmployeeDetails !=null )
            {
                

                foreach (var detail in employee.EmployeeDetails)
                {
                    detail.Employeeid = employee.id;


                }
                _context.employees.Add(employee);
                _context.employeeDetails.AddRange(employee.EmployeeDetails);
                _context.SaveChanges();
            }
            else
            {
                _context.employees.Add(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        public string UpdateEmployee(int id, Employee employee)
        {

            if (id > 0)
            {
                var resultEmployee = _context.employees
                    .FirstOrDefault(e => e.id == id);

                if (resultEmployee != null)
                {
                    _context.employees.Where(
                   e => e.id == id)
                   .ExecuteUpdate(e => e.SetProperty(e => e.fName, employee.fName)
                   .SetProperty(e => e.lName, employee.lName)
                   .SetProperty(e => e.age, employee.age)
                   .SetProperty(e => e.salary, employee.salary)
                   .SetProperty(e => e.state, employee.state)
                   .SetProperty(e => e.country, employee.country)
                   .SetProperty(e => e.email, employee.email)
                   .SetProperty(e => e.gender, employee.gender)
                   .SetProperty(e => e.phone, employee.phone));

                    
                        if (employee.EmployeeDetails != null)
                        {
                            var Details = _context.employeeDetails.Where(d=>d.Employeeid == id)
                                .FirstOrDefault();

                            foreach(var detail in employee.EmployeeDetails)
                            {
                                Details.jobTitle = detail.jobTitle;
                                Details.city = detail.city;
                                Details.experience = detail.experience;

                            }
                        }
                        _context.SaveChanges();
                    


                }
                else
                {
                    return "Can't Find Employee";
                }

                return "Update Successfully";
            }
            else
            {
                return "Invalid Employee";
            }
        }


    }
}
