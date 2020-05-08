using Employee_BussinessLayer;
using Employee_Controllers.Controllers;
using Employee_DataAccessLayer;
using Employee_DataAccessLayer.ServiceManager;
using Employee_Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class Employee_UnitTest_Controller
    {
        [TestMethod]
        public void getDetails_Positive_TestCase()
        {
            //Assign

            var Mock_IEmployee_Bussiness = new Mock<IEmployee_Bussiness>();
            Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();

            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_Get()).Returns(employeeDetailsList);
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var ActResult = AssignResult.getDetails();

            //Assert

            Assert.ReferenceEquals(ActResult, employeeDetailsList);
            //Assert.AreEqual(ActResult, employeeDetailsList);
        }
        [TestMethod]
        public void getDetailsId_Positive_TestCase()
        {
            //Assign

            var Mock_IEmployee_Bussiness = new Mock<IEmployee_Bussiness>();
            Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();

            Mock_IEmployee_Bussiness.Setup(x => x.employeeDetailsB_GetId(1)).Returns(employeeDetailsList);
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Act
            var ActResult = AssignResult.getDetails();

            //Assert

            Assert.ReferenceEquals(ActResult, employeeDetailsList);
            //Assert.AreEqual(ActResult, employeeDetailsList);
        }
        [TestMethod]
        public void deleteEmployeeId_Positive_TestCase()
        {
            //Assign

            var Mock_IEmployee_Bussiness = new Mock<IEmployee_Bussiness>();
            int Id = 1;
            //Act
            Mock_IEmployee_Bussiness.Setup(p => p.employeeDetailsB_DeleteId(Id)).Returns(Employees_Mock_Positive());
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            //Assert
            var _actualReturnType = AssignResult.deleteEmployeeId(Id);
            Assert.ReferenceEquals(employeeDetail(), _actualReturnType);
            //Assert.AreEqual(ActResult, employeeDetailsList);
        }
        [TestMethod]
        public void addEmployeeDetails_PositiveTestCases_TestResults()
        {

            //Assign
            var Mock_IEmployee_Bussiness = new Mock<IEmployee_Bussiness>();

;
            Mock_IEmployee_Bussiness.Setup(p => p.employeeDetailsB_Add(employeeDetail())).Returns(Employees_Mock_Positive());
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            var _actualReturnType = AssignResult.addEmployeeDetails(employeeDetail());
            Assert.ReferenceEquals(employeeDetail(), _actualReturnType);

        }
        [TestMethod]
        public void updateEmployeeDetails_PositiveTestCases_TestResults()
        {

            //Assign
            var Mock_IEmployee_Bussiness = new Mock<IEmployee_Bussiness>();

            ;
            Mock_IEmployee_Bussiness.Setup(p => p.employeeDetailsB_Update(employeeDetail())).Returns(Employees_Mock_Positive());
            EmployeeController AssignResult = new EmployeeController(Mock_IEmployee_Bussiness.Object);

            var _actualReturnType = AssignResult.updateEmployeeDetails(employeeDetail());
            Assert.ReferenceEquals(employeeDetail(), _actualReturnType);

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
        //private static ContentResult ReturnHttpResponse(string responseBody, HttpStatusCode StatusCode, string ContentType = "application/json")
        //{
        //    return new ContentResult
        //    {
        //        Content = responseBody,
        //        ContentType = ContentType,
        //        StatusCode = (int)StatusCode
        //    };
        //}
    }
}
