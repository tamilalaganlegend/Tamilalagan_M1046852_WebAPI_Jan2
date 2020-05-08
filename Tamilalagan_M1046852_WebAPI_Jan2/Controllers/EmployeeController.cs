using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Employee_BussinessLayer;
using Employee_Entities;
using Custom_Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace Employee_Controllers.Controllers
{
    [Route("EmpMgt")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        //public Employee_Bussiness context = new Employee_Bussiness();
        private readonly IEmployee_Bussiness context;

        public EmployeeController(IEmployee_Bussiness employee_bussiness)
        {
            context = employee_bussiness;
        }
        private static ContentResult ReturnHttpResponse(string responseBody,HttpStatusCode StatusCode,string ContentType = "application/json")
        {
            return new ContentResult
            {
                Content = responseBody,
                ContentType = ContentType,
                StatusCode = (int)StatusCode
            };
        }

        [HttpGet]
        [Route("getAllEmpDetails")]
        public async Task<IActionResult> getDetails()
        {
            try
            {
                IEnumerable<EmployeeDetails> employeeDetails = await context.employeeDetailsB_Get();
                return Ok(employeeDetails);
            }
            catch (BadRequestException exception)
            {
                return ReturnHttpResponse(exception.Message, HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                string ErrorMessage = JsonConvert.SerializeObject(new JObject
                {
                    new JProperty("Error",exception.Message)
                });
                return ReturnHttpResponse(ErrorMessage, HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        [Route("getByEmpId/{empId}")]
        public async Task<IActionResult> getDetailsId(int empId)
        {
            try
            {
                IEnumerable<EmployeeDetails> employeeDetails = await context.employeeDetailsB_GetId(empId);
                if (empId == null)
                {
                    throw new ArgumentNullException();
                }
                return Ok(employeeDetails);
            }
            catch (BadRequestException exception)
            {
                return ReturnHttpResponse(exception.Message, HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                string ErrorMessage = JsonConvert.SerializeObject(new JObject
                {
                    new JProperty("Error",exception.Message)
                });
                return ReturnHttpResponse(ErrorMessage, HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        [Route("deleteEmp/{id}")]
        public async Task<IActionResult> deleteEmployeeId(int empId)
        {
            try
            {
                if (empId == null)
                {
                    throw new ArgumentNullException();
                }
                if (ModelState.IsValid)
                {
                    await context.employeeDetailsB_DeleteId(empId);
                }
                string response = JsonConvert.SerializeObject(new JObject
                    {
                        new JProperty("Message","Deleted Successfully")
                    });
                return ReturnHttpResponse(response, HttpStatusCode.OK);
            }
            catch (BadRequestException exception)
            {
                return ReturnHttpResponse(exception.Message, HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                string ErrorMessage = JsonConvert.SerializeObject(new JObject
                {
                    new JProperty("Error",exception.Message)
                });
                return ReturnHttpResponse(ErrorMessage, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        [Route("addEmp")]
        public async Task<IActionResult> addEmployeeDetails(EmployeeDetails employeeDetails)
        {
            try
            {
                if (employeeDetails == null)
                {
                    throw new ArgumentNullException();
                }
                if (ModelState.IsValid)
                {
                    await context.employeeDetailsB_Add(employeeDetails);
                }
                string response = JsonConvert.SerializeObject(new JObject
                    {
                        new JProperty("Message","Added Successfully")
                    });
                return ReturnHttpResponse(response, HttpStatusCode.OK);
            }
            catch (BadRequestException exception)
            {
                return ReturnHttpResponse(exception.Message, HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                string ErrorMessage = JsonConvert.SerializeObject(new JObject
                {
                    new JProperty("Error",exception.Message)
                });
                return ReturnHttpResponse(ErrorMessage, HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        [Route("updateEmp")]
        public async Task<IActionResult> updateEmployeeDetails(EmployeeDetails employeeDetails)
        {
            try
            {
                if (employeeDetails == null)
                {
                    throw new ArgumentNullException();
                }
                if (ModelState.IsValid)
                {
                    await context.employeeDetailsB_Update(employeeDetails);
                }
                string response = JsonConvert.SerializeObject(new JObject
                    {
                        new JProperty("Message","Updated Successfully")
                    });
                return ReturnHttpResponse(response, HttpStatusCode.OK);
            }
            catch (BadRequestException exception)
            {
                return ReturnHttpResponse(exception.Message, HttpStatusCode.BadRequest);
            }
            catch (Exception exception)
            {
                string ErrorMessage = JsonConvert.SerializeObject(new JObject
                {
                    new JProperty("Error",exception.Message)
                });
                return ReturnHttpResponse(ErrorMessage, HttpStatusCode.InternalServerError);
            }
        }
    }
}