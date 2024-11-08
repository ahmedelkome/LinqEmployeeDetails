

using System.Text.Json.Serialization;

namespace EmployeeDetailsEntity.Models.emp
{
    public  class Employee
    {
        [JsonIgnore]
        public int id { get; set; } 

        public string? fName { get; set; } = "";

        public string? lName { get; set; } = "";

        public int? age { get; set; } = 0;

        public string? email { get; set; } = "";

        public decimal? salary { get; set; } = 0;

        public string? phone { get; set; } = "";

        public string? country { get; set; } = "";

        public string? state { get; set; } = "";

        public string? gender { get; set; } = "";

        public List<EmployeeDetails> EmployeeDetails { get; set; }
    }

    public class EmployeeDetails
    {
        [JsonIgnore]
        public int id { get; set; }

        public string? city { get; set; } = "";

        public int? experience { get; set; } = 0;

        public string? jobTitle { get; set; } = "";

        [JsonIgnore]
        public int? Employeeid { get; set; } = 0;

    }

    public class EmployeeDto
    {
        public int id { get; set; }

        public string? city { get; set; }

        public int? experience { get; set; }

        public string? jobTitle { get; set; }

        public string? Employeename { get; set; }

    }
}
