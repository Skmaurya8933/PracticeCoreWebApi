using System.ComponentModel.DataAnnotations;

namespace PracticeCoreWebApi.Model
{
    public class EmployeeDetail
    {
        [Key]
        public int EmployeeId { get; set; }
        public string  EmployeeName { get; set; } = string.Empty;
        public DateTime EmpDoB { get; set; }
        public DateTime EmpDateOFJoining { get; set; } 
        public decimal EmpSalary { get; set; }
        public string  EmpDepartment { get; set; } = string.Empty;
        public string  EmpTechnicalSkills { get; set; } = string.Empty;
    }


    public class EmployeeDetailResponseModel
    {
        public EmployeeDetailResponseModel()
        {
            CommonResponseStatus = new CommonResponseStatus();
        }
        public CommonResponseStatus CommonResponseStatus { get; set; }
        public EmployeeDetail employeeDetail { get; set; }
        public IEnumerable<EmployeeDetail> employeeDetails { get; set; }
    }
}
