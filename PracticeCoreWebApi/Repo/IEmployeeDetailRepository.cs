using PracticeCoreWebApi.Model;

namespace PracticeCoreWebApi.Repo
{
    public interface IEmployeeDetailRepository
    {
        Task<CommonResponseStatus> AddEmployeeDetail(EmployeeDetail employeeDetail);
        Task<EmployeeDetailResponseModel> GetAllEmployeeDetail();
        Task<EmployeeDetailResponseModel> GetEmployeeDetail(int id);
        Task<CommonResponseStatus> UpdateEmployeeDetail(EmployeeDetail employeeDetail);
        Task<CommonResponseStatus> DeleteEmployeeDetail(int id);
    }
}
