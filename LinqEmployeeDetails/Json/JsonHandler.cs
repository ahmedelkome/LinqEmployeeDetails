using EmployeeDetailsEntity.Models.emp;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LinqEmployeeDetails.Json
{
    public class JsonHandler
    {
        private readonly string _filePath;

        public JsonHandler()
        {
            _filePath = "Employee.json";
        }


        public void SaveEmployee(Employee employee)
        {
            if (File.Exists(_filePath))
            {
                var employeesList = new List<Employee>();

                var json = File.ReadAllText(_filePath);

                employeesList = JsonConvert.DeserializeObject<List<Employee>>(json) ?? new List<Employee>();

                employeesList.Add(employee);

                var updateJson = JsonConvert.SerializeObject(employeesList, Formatting.Indented);

                File.WriteAllText(_filePath, updateJson);

            }
        }


        public List<Employee> WriteAllEmployeeFromDatabase(List<Employee> employeesList)
        {
            var json = JsonConvert.SerializeObject(employeesList, formatting: Formatting.Indented);
            File.WriteAllText(_filePath, json);

            var jsonString = File.ReadAllText(_filePath);

            var result = JsonConvert.DeserializeObject<List<Employee>>(jsonString);

            return result;
        }

        public List<Employee> GetEmployeeList()
            {
                var jsonString = File.ReadAllText(_filePath);

                var result = JsonConvert.DeserializeObject<List<Employee>>(jsonString);

                return result;
            }
        }
    }
