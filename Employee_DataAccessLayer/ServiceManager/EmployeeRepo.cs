using Employee_Entities;
using System.Linq;
using System;
using System.Collections.Generic;
using Employee_Entities.Contracts;
using System.Threading.Tasks;
using Custom_Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Employee_DataAccessLayer.ServiceManager
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly Employee_DBContext context;
        public EmployeeRepo(Employee_DBContext employee_DBContext)
        {
            context = employee_DBContext;
        }

        public async Task<List<EmployeeDetails>> employeeGet()
        {
            try
            {
                List<EmployeeDetails> employeeDetailsGet = context.Employee.ToList();
                if (employeeDetailsGet.Count==0)
                {
                    throw new NotFoundException("No Records Found");
                }
                return employeeDetailsGet;
            }
            catch (NotFoundException exception)
            {
                throw exception;
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
                    throw new BadRequestException("Input Not Valid");
                }
                if (employeeDetailsGet.Count == 0)
                {
                    throw new NotFoundException("No Records Found");
                }
                return employeeDetailsGet;
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
        public async Task employeeAdd(EmployeeDetails employeeDetails)
        {
            try
            {
                if (employeeDetails == null)
                {
                    throw new BadRequestException("Input Not Valid");
                }
                var employeeDetail = await context.Employee.AddAsync(employeeDetails);
                context.SaveChanges();
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

        public async Task employeeUpdate(EmployeeDetails employeeDetails)
        {
            try
            {
                if (employeeDetails == null)
                {
                    throw new BadRequestException("Input Not Valid");
                }
                var findEmployeeId = context.Employee.Where(x => x.Id == employeeDetails.Id).FirstOrDefault();

                if (findEmployeeId != null)
                {
                    findEmployeeId.Username = employeeDetails.Username;
                    findEmployeeId.DateOfBirth = employeeDetails.DateOfBirth;
                    findEmployeeId.EmailId = employeeDetails.EmailId;
                    findEmployeeId.FullName = employeeDetails.FullName;
                    findEmployeeId.Gender = employeeDetails.Gender;
                    findEmployeeId.Password = employeeDetails.Password;
                    findEmployeeId.SecurityAnswer = employeeDetails.SecurityAnswer;
                    findEmployeeId.SecurityQuestion = employeeDetails.SecurityQuestion;

                    context.Entry(findEmployeeId).State = EntityState.Modified;
                    context.SaveChanges();
                }
                else
                {
                    throw new NotFoundException("No Records Found");
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
        }
        public async Task employeeDelete(int empId)
        {
            try
            {
                if (empId==null)
                {
                    throw new BadRequestException("Input Not Valid");
                }
                var findEmployeeId = context.Employee.Where(x => x.Id == empId).FirstOrDefault(); 
                if (findEmployeeId == null)
                {
                    throw new NotFoundException("No Records Found");
                }
                context.Employee.Remove(findEmployeeId);
                context.SaveChanges();
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
