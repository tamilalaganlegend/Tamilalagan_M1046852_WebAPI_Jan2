using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_Entities.Contracts
{
    public interface IEmployeeRepo
    {
        Task<List<EmployeeDetails>> employeeGet();
        Task<List<EmployeeDetails>> employeeGetId(int empId);
        Task employeeAdd(EmployeeDetails employeeDetails);
        Task employeeUpdate(EmployeeDetails employeeDetails);
        Task employeeDelete(int empId);

    }
}
