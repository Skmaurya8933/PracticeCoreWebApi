using Microsoft.EntityFrameworkCore;
using PracticeCoreWebApi.Data;
using PracticeCoreWebApi.Model;

namespace PracticeCoreWebApi.Repo
{
    public class EmployeeDetailRepository : IEmployeeDetailRepository
    {
        private readonly DataContext _dataContext;
        public EmployeeDetailRepository(DataContext dataContext)
        {
          _dataContext = dataContext;   
        }

        public async Task<CommonResponseStatus> AddEmployeeDetail(EmployeeDetail employeeDetail)
        {
            try
            {
                CommonResponseStatus obj = new CommonResponseStatus();         
                var addresult = await _dataContext.EmployeeDetails.AddAsync(employeeDetail);
                if (addresult != null)
                {
                    var a = await _dataContext.SaveChangesAsync();
                    if (a > 0)
                    {
                        obj.Message = "Employee detail added successfully!";
                        obj.Status = true;
                        return obj;
                    }
                    else
                    {
                        obj.Message = "Failed to Add Data!";
                        obj.Status = false;
                        return obj;
                    }
                }
                else
                {
                    return obj;
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<EmployeeDetailResponseModel> GetAllEmployeeDetail()
        {
            try
            {
                EmployeeDetailResponseModel objResponse = new EmployeeDetailResponseModel();
                var emplist = await _dataContext.EmployeeDetails.ToListAsync();
                if (!emplist.Any())
                {
                    objResponse.CommonResponseStatus.Status = true;
                    objResponse.CommonResponseStatus.Message = "There is no superhero detail";
                }
                else
                {
                    objResponse.CommonResponseStatus.Status = true;
                    objResponse.CommonResponseStatus.Message = "Success";
                    objResponse.employeeDetails = emplist;
                }
                return objResponse;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<EmployeeDetailResponseModel> GetEmployeeDetail(int id)
        {
            try
            {
                EmployeeDetailResponseModel objResponse = new EmployeeDetailResponseModel();
                var employee = await _dataContext.EmployeeDetails.FirstOrDefaultAsync(x => x.EmployeeId == id);
                if (employee != null)
                {
                    objResponse.CommonResponseStatus.Status = true;
                    objResponse.CommonResponseStatus.Message = "Success";
                    objResponse.employeeDetail = employee;
                }
                else
                {
                    objResponse.CommonResponseStatus.Status = true;
                    objResponse.CommonResponseStatus.Message = "There is no employee detail";
                }
                return objResponse;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
           
        public async Task<CommonResponseStatus> UpdateEmployeeDetail(EmployeeDetail employeeDetail)
        {
            CommonResponseStatus obj = new CommonResponseStatus();
            var data = await _dataContext.EmployeeDetails.Where(x => x.EmployeeId == employeeDetail.EmployeeId).FirstOrDefaultAsync();
            if (data != null)
            {
                data.EmployeeName = employeeDetail.EmployeeName;
                data.EmpDepartment = employeeDetail.EmpDepartment;
                data.EmpDateOFJoining = employeeDetail.EmpDateOFJoining;
                data.EmpDoB = employeeDetail.EmpDoB;
                data.EmpTechnicalSkills = employeeDetail.EmpTechnicalSkills;
                data.EmpSalary = employeeDetail.EmpSalary;
                _dataContext.Entry(data).State = EntityState.Modified;
                var result = _dataContext.SaveChanges();
                if (result > 0)
                {
                    obj.Message = "Updated Successfully !";
                    obj.Status = true;
                    return obj;
                }
                else
                {
                    obj.Message = "Failed to Update Data!";
                    obj.Status = false;
                    return obj;
                }
            }
            else
            {
                obj.Message = "Invalid Employee!";
                obj.Status = false;
                return obj;
            }
        }
        public async Task<CommonResponseStatus> DeleteEmployeeDetail(int id)
        {
            CommonResponseStatus obj = new CommonResponseStatus();
            var data = await _dataContext.EmployeeDetails.Where(x => x.EmployeeId == id).FirstOrDefaultAsync();
            if (data != null)
            {
                _dataContext.EmployeeDetails.Remove(data);
                var result = _dataContext.SaveChanges();
                if (result > 0)
                {
                    obj.Message = "Deleted Successfully !";
                    obj.Status = true;
                    return obj;
                }
                else
                {
                    obj.Message = "Failed to Delete Data!";
                    obj.Status = false;
                    return obj;
                }
            }
            else
            {
                obj.Message = "Invalid Employee!";
                obj.Status = false;
                return obj;
            }
        }
    }
}
