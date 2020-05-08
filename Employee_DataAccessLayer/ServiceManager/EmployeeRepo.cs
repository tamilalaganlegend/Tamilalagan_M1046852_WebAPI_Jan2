using Employee_Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using Employee_Entities.Contracts;
using System.Threading.Tasks;

namespace Employee_DataAccessLayer.ServiceManager
{
    public class EmployeeRepo : IEmployeeRepo
    {
        //public Employee_DBContext context = new Employee_DBContext();
        private readonly Employee_DBContext context;
        public EmployeeRepo(Employee_DBContext employee_DBContext)
        {
            context = employee_DBContext;
        }

        public async Task<List<EmployeeDetails>> employeeGet()
        {
            //IEnumerable<EmployeeDetails> employeeDetailsGet = context.Employee;
            try
            {
                List<EmployeeDetails> employeeDetailsGet = context.Employee.ToList();
                if (employeeDetailsGet==null)
                {
                    throw new Exception("No Records Found");
                }
                return employeeDetailsGet;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task<List<EmployeeDetails>> employeeGetId(int empId)
        {
            List<EmployeeDetails> employeeDetailsGet = context.Employee.Where(x=>x.Id== empId).ToList();
            try
            {
                if (employeeDetailsGet == null)
                {
                    throw new Exception("No Records Found");
                }
                return employeeDetailsGet;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task employeeAdd(EmployeeDetails employeeDetails)
        {
            try
            {
                if (employeeDetails == null)
                {
                    throw new ArgumentNullException();
                }
                var employeeDetail = await context.Employee.AddAsync(employeeDetails);
                context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task employeeUpdate(EmployeeDetails employeeDetails)
        {
            try
            {
                if (employeeDetails != null)
                {
                    context.Employee.Update(employeeDetails);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task employeeDelete(int empId)
        {
            try
            {
                var findEmployeeId = context.Employee.FirstOrDefault(d => d.Id == empId);
                if (findEmployeeId == null)
                {
                    throw new Exception("No Records Found");
                }

                context.Employee.Remove(findEmployeeId);
                context.SaveChanges();

            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
