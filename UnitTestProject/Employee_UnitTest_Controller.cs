using Custom_Exceptions;
using Employee_BussinessLayer;
using Employee_Controllers.Controllers;
using Employee_Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class Employee_UnitTest_Controller
    {
        public Mock<IEmployee_Bussiness> Mock_IEmployee_Bussiness = new Mock<IEmployee_Bussiness>();
        [TestMethod]
        public void getDetails_Positive_TestCase()
        {
            //Assign
            Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_Get()).Returns(employeeDetailsList);
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var ActResult = AssignResult.getDetails();
            var MockedResult = ReturnHttpResponse(JsonValue(employeeDetailsList),HttpStatusCode.OK);

            //Assert
            Assert.ReferenceEquals(ActResult, MockedResult);
        }
        [TestMethod]
        public void getDetailsId_Positive_TestCase()
        {
            //Assign
            int Id = 1;
            Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();

            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_GetId(Id)).Returns(employeeDetailsList);
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var ActResult = AssignResult.getDetailsId(Id);
            var MockedResult = ReturnHttpResponse(JsonValue(employeeDetailsList), HttpStatusCode.OK);

            //Assert
            Assert.ReferenceEquals(ActResult, MockedResult);
        }
        [TestMethod]
        public void deleteEmployeeId_Positive_TestCase()
        {
            //Assign
            int Id = 1;
            Mock_IEmployee_Bussiness.Setup(p => p.employeeDetailsB_DeleteId(Id)).Returns(Employees_Mock_Positive());
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.deleteEmployeeId(Id);
            string response = JsonConvert.SerializeObject(new JObject
                    {new JProperty("Message","Deleted Successfully")});
            var MockedResult = ReturnHttpResponse(response, HttpStatusCode.OK);

            //Assert
            Assert.ReferenceEquals(MockedResult, _actualReturnType);
        }
        [TestMethod]
        public void addEmployeeDetails_PositiveTestCases_TestResults()
        {

            //Assign
            Mock_IEmployee_Bussiness.Setup(p => p.employeeDetailsB_Add(employeeDetail())).Returns(Employees_Mock_Positive());
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.addEmployeeDetails(employeeDetail());
            string response = JsonConvert.SerializeObject(new JObject
                    {new JProperty("Message","Employee data inserted successfully")});
            var MockedResult = ReturnHttpResponse(response, HttpStatusCode.OK);

            //Assert
            Assert.ReferenceEquals(MockedResult, _actualReturnType);

        }
        [TestMethod]
        public void updateEmployeeDetails_PositiveTestCases_TestResults()
        {
            //Assign
            Mock_IEmployee_Bussiness.Setup(p => p.employeeDetailsB_Update(employeeDetail())).Returns(Employees_Mock_Positive());
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.updateEmployeeDetails(employeeDetail());
            string response = JsonConvert.SerializeObject(new JObject
                    {new JProperty("Message","Updated Successfully")});
            var MockedResult = ReturnHttpResponse(response, HttpStatusCode.OK);

            //Assert
            Assert.ReferenceEquals(MockedResult, _actualReturnType);
        }
        /// <summary>
        /// Not Found
        /// </summary>
        [TestMethod]
        public void getDetails_NegativeTestCases_TestResult_NotFound()
        {
            //Assign
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_Get()).Throws<NotFoundException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.getDetails();
            var MockedReturn = ReturnHttpResponse("No Records Found",HttpStatusCode.NotFound);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }
        
        [TestMethod]
        public void getDetailsId_NegativeTestCases_TestResult_NotFound()
        {
            //Assign
            int Id = 0;
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_GetId(Id)).Throws<NotFoundException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.getDetailsId(Id);
            var MockedReturn = ReturnHttpResponse("No Records Found", HttpStatusCode.NotFound);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }

        [TestMethod]
        public void deleteEmployeeId_NegativeTestCases_TestResult_NotFound()
        {
            //Assign
            int Id = 0;
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_DeleteId(Id)).Throws<NotFoundException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.deleteEmployeeId(Id);
            var MockedReturn = ReturnHttpResponse("No Records Found", HttpStatusCode.NotFound);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }
       
        //[TestMethod]
        public void addEmployeeDetails_NegativeTestCases_TestResult_NotFound()
        {
            //Assign
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_Add(employeeDetail())).Throws<NotFoundException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.addEmployeeDetails(employeeDetail());
            var MockedReturn = ReturnHttpResponse("No Records Found", HttpStatusCode.NotFound);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }
       
        [TestMethod]
        public void updateEmployeeDetails_NegativeTestCases_TestResult_NotFound()
        {
            //Assign
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_Update(employeeDetail())).Throws<NotFoundException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.updateEmployeeDetails(employeeDetail());
            var MockedReturn = ReturnHttpResponse("No Records Found", HttpStatusCode.NotFound);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }
        /// <summary>
        /// Bad Request
        /// </summary>
        //[TestMethod]
        public void getDetails_NegativeTestCases_TestResult_BadRequest()
        {
            //Assign
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_Get()).Throws<BadRequestException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.getDetails();
            var MockedReturn = ReturnHttpResponse("Input Not Valid", HttpStatusCode.BadRequest);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }
        [TestMethod]
        public void getDetailsId_NegativeTestCases_TestResult_BadRequest()
        {
            //Assign
            int Id = 0;
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_GetId(Id)).Throws<BadRequestException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.getDetailsId(Id);
            var MockedReturn = ReturnHttpResponse("Input Not Valid", HttpStatusCode.BadRequest);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }
        [TestMethod]
        public void deleteEmployeeId_NegativeTestCases_TestResult_BadRequest()
        {
            //Assign
            int Id = 0;
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_DeleteId(Id)).Throws<BadRequestException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.deleteEmployeeId(Id);
            var MockedReturn = ReturnHttpResponse("Input Not Valid", HttpStatusCode.BadRequest);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }
        [TestMethod]
        public void addEmployeeDetails_NegativeTestCases_TestResult_BadRequest()
        {
            //Assign
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_Add(employeeDetail())).Throws<BadRequestException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.addEmployeeDetails(employeeDetail());
            var MockedReturn = ReturnHttpResponse("Input Not Valid", HttpStatusCode.BadRequest);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }
        [TestMethod]
        public void updateEmployeeDetails_NegativeTestCases_TestResult_BadRequest()
        {
            //Assign
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_Update(employeeDetail())).Throws<BadRequestException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.updateEmployeeDetails(employeeDetail());
            var MockedReturn = ReturnHttpResponse("Input Not Valid", HttpStatusCode.BadRequest);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }
        /// <summary>
        /// Internal Server
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void getDetails_NegativeTestCases_TestResult_InternalServer()
        {
            //Assign
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_Get()).Throws<InternalServerException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.getDetails();
            var MockedReturn = ReturnHttpResponse(InternalServerError, HttpStatusCode.InternalServerError);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }
        [TestMethod]
        public void getDetailsId_NegativeTestCases_TestResult_InternalServer()
        {
            //Assign
            int Id = 0;
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_GetId(Id)).Throws<InternalServerException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.getDetailsId(Id);
            var MockedReturn = ReturnHttpResponse(InternalServerError, HttpStatusCode.InternalServerError);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }
        [TestMethod]
        public void deleteEmployeeId_NegativeTestCases_TestResult_InternalServer()
        {
            //Assign
            int Id = 0;
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_DeleteId(Id)).Throws<InternalServerException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.deleteEmployeeId(Id);
            var MockedReturn = ReturnHttpResponse(InternalServerError, HttpStatusCode.InternalServerError);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }
        [TestMethod]
        public void addEmployeeDetails_NegativeTestCases_TestResult_InternalServer()
        {
            //Assign
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_Add(employeeDetail())).Throws<InternalServerException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.addEmployeeDetails(employeeDetail());
            var MockedReturn = ReturnHttpResponse(InternalServerError, HttpStatusCode.InternalServerError);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }
        [TestMethod]
        public void updateEmployeeDetails_NegativeTestCases_TestResult_InternalServer()
        {
            //Assign
            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_Update(employeeDetail())).Throws<InternalServerException>();
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var _actualReturnType = AssignResult.updateEmployeeDetails(employeeDetail());
            var MockedReturn = ReturnHttpResponse(InternalServerError, HttpStatusCode.InternalServerError);

            //Assert
            Assert.ReferenceEquals(_actualReturnType, MockedReturn);
        }
        public EmployeeDetails employeeDetail()
        {
            EmployeeDetails employeeDetails = new EmployeeDetails();
            employeeDetails.Username = "Tamil";
            employeeDetails.FullName = "Tamilalagan";
            employeeDetails.DateOfBirth = "01/01/2000";
            employeeDetails.EmailId = "Tamilalagan.s2@mindtree.com";
            employeeDetails.Gender = "Male";
            employeeDetails.Password = "Password";
            employeeDetails.Id = 1;
            return employeeDetails;
        }
        public async Task<List<EmployeeDetails>> Employees_Mock_Positive()
        {
            List<EmployeeDetails> employeeDetails = new List<EmployeeDetails>();
            employeeDetails.Add(employeeDetail());
            return employeeDetails;

        }
        public string JsonValue(object employeeDetailsList)
        {
            string response = JsonConvert.SerializeObject(employeeDetailsList, new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver(),
                Formatting = Formatting.Indented
            });
            return response;
        }
        private static ContentResult ReturnHttpResponse(string responseBody, HttpStatusCode StatusCode, string ContentType = "application/json")
        {
            return new ContentResult
            {
                Content = responseBody,
                ContentType = ContentType,
                StatusCode = (int)StatusCode
            };
        }
        string InternalServerError = "Exception of type 'Custom_Exceptions.InternalServerException' was thrown.";
    }
}
