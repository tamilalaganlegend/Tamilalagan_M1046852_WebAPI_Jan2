using Custom_Exceptions;
using Employee_Entities;
using Employee_Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_BussinessLayer
{
    public class Employee_Bussiness : IEmployee_Bussiness
    {
        //public EmployeeRepo context = new EmployeeRepo();
        private readonly IEmployeeRepo context;
        public Employee_Bussiness(IEmployeeRepo employeerepo)
        {
            context = employeerepo;
        }
        public async Task<List<EmployeeDetails>> employeeDetailsB_Get()
        {
            List<EmployeeDetails> employeeDetails = await context.employeeGet();
            try
            {
                if(employeeDetails==null)
                {
                    throw new BadRequestException("No Records Found");
                }
                return employeeDetails;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }
        public async Task<List<EmployeeDetails>> employeeDetailsB_GetId(int empId)
        {
            List<EmployeeDetails> employeeDetails = await context.employeeGetId(empId);
            try
            {
                if (employeeDetails == null)
                {
                    throw new BadRequestException("No Records Found");
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return employeeDetails;
        }
        public async Task employeeDetailsB_DeleteId(int empId)
        {
            try
            {
                if (empId == null)
                {
                    throw new ArgumentNullException();
                }
                await context.employeeDelete(empId);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task employeeDetailsB_Add(EmployeeDetails employeeDetails)
        {
            try
            {
                if (employeeDetails == null)
                {
                    throw new ArgumentNullException();
                }
                await context.employeeAdd(employeeDetails);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public async Task employeeDetailsB_Update(EmployeeDetails employeeDetails)
        {
            try
            {
                if (employeeDetails == null)
                {
                    throw new ArgumentNullException();
                }
                await context.employeeUpdate(employeeDetails);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
