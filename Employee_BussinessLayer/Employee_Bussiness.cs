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
                if(employeeDetails.Count==0)
                {
                    throw new NotFoundException("No Records Found");
                }
                return employeeDetails;
            }
            catch(NotFoundException exception)
            {
                throw exception;
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
                if (employeeDetails.Count == 0)
                {
                    throw new NotFoundException("No Records Found");
                }
                if(empId == null)
                {
                    throw new BadRequestException("Input Not Valid");
                }
            }
            catch (NotFoundException exception)
            {
                throw exception;
            }
            catch (BadRequestException exception)
            {
                throw exception;
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
                    throw new BadRequestException("Input Not Valid");
                }
                await context.employeeDelete(empId);
            }
            catch (NotFoundException exception)
            {
                throw exception;
            }
            catch (BadRequestException exception)
            {
                throw exception;
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
                    throw new BadRequestException("Input Not Valid");
                }
                await context.employeeAdd(employeeDetails);
            }
            catch (BadRequestException exception)
            {
                throw exception;
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
                    throw new BadRequestException("Input Not Valid");
                }
                await context.employeeUpdate(employeeDetails);
            }
            catch (NotFoundException exception)
            {
                throw exception;
            }
            catch (BadRequestException exception)
            {
                throw exception;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
