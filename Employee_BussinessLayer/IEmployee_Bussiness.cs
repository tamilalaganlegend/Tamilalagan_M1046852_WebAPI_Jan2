using Employee_Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_BussinessLayer
{
    public interface IEmployee_Bussiness
    {
        Task<List<EmployeeDetails>> employeeDetailsB_Get();
        Task<List<EmployeeDetails>> employeeDetailsB_GetId(int empId);
        Task employeeDetailsB_DeleteId(int empId);
        Task employeeDetailsB_Add(EmployeeDetails employeeDetails);
        Task employeeDetailsB_Update(EmployeeDetails employeeDetails);
    }
}
