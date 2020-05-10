using Custom_Exceptions;
using Employee_BussinessLayer;
using Employee_Entities;
using Employee_Entities.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_UnitTest_BussinessLayer
{
    [TestClass]
    public class Employee_UnitTest_BussinessLayer
    {
        Mock<IEmployeeRepo> Mock_IEmployee_Repo = new Mock<IEmployeeRepo>();
        [TestMethod]
        public void employeeDetailsB_Get_Positive_TestCase()
        {
            //Assign
            Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
            Mock_IEmployee_Repo.Setup(x => x.employeeGet()).Returns(employeeDetailsList);
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);

            //Act
            var ActResult = AssignResult.employeeDetailsB_Get();

            //Assert
            Assert.ReferenceEquals(ActResult, employeeDetailsList);
        }
        [TestMethod]
        public void employeeDetailsB_GetId_Positive_TestCase()
        {
            //Assign
            Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
            Mock_IEmployee_Repo.Setup(x => x.employeeGetId(1)).Returns(employeeDetailsList);
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);

            //Act
            var ActResult = AssignResult.employeeDetailsB_GetId(1);

            //Assert
            Assert.ReferenceEquals(ActResult, employeeDetailsList);
        }
        [TestMethod]
        public void employeeDetailsB_DeleteId_Positive_TestCase()
        {
            //Assign
            int Id = 1;
            Mock_IEmployee_Repo.Setup(p => p.employeeDelete(Id)).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);

            //Act
            var _actualReturnType = AssignResult.employeeDetailsB_DeleteId(Id);

            //Assert
            Assert.ReferenceEquals(employeeDetail(), _actualReturnType);
        }
        [TestMethod]
        public void employeeDetailsB_Add_PositiveTestCases_TestResults()
        {

            //Assign
            Mock_IEmployee_Repo.Setup(p => p.employeeAdd(employeeDetail())).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);

            //Act
            var _actualReturnType = AssignResult.employeeDetailsB_Add(employeeDetail());

            //Assert
            Assert.ReferenceEquals(employeeDetail(), _actualReturnType);

        }
        [TestMethod]
        public void employeeDetailsB_Update_PositiveTestCases_TestResults()
        {

            //Assign
            Mock_IEmployee_Repo.Setup(p => p.employeeUpdate(employeeDetail())).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);

            //Act
            var _actualReturnType = AssignResult.employeeDetailsB_Update(employeeDetail());

            //Assert
            Assert.ReferenceEquals(Employees_Mock_Positive(), _actualReturnType);
        }
        /// <summary>
        /// Not Found
        /// </summary>
        [TestMethod]
        public void employeeDetailsB_Get_NegativeTestCases_TestResult_NotFound()
        {
            //Assign
            Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
            Mock_IEmployee_Repo.Setup(x => x.employeeGet()).Returns(employeeDetailsList);
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);

            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_Get();
            }
            catch(NotFoundException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, "Id Not Found");
            }
        }
        [TestMethod]
        public void employeeDetailsB_GetId_NegativeTestCases_TestResult_NotFound()
        {
            //Assign
            int Id = 0;
            Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
            Mock_IEmployee_Repo.Setup(x => x.employeeGetId(1)).Returns(employeeDetailsList);
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);
            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_GetId(Id);
            }
            catch (NotFoundException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, "Id Not Found");
            }
        }
        [TestMethod]
        public void employeeDetailsB_DeleteId_NegativeTestCases_TestResult_NotFound()
        {
            //Assign
            int Id = 0;
            Mock_IEmployee_Repo.Setup(p => p.employeeDelete(Id)).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);
            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_DeleteId(Id);
            }
            catch (NotFoundException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, "Id Not Found");
            }
        }
        //[TestMethod]
        public void employeeDetailsB_Add_NegativeTestCases_TestResult_NotFound()
        {

            //Assign
            Mock_IEmployee_Repo.Setup(p => p.employeeAdd(employeeDetail())).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);
            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_Add(new EmployeeDetails());
            }
            catch (NotFoundException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, "Id Not Found");
            }

        }
        [TestMethod]
        public void employeeDetailsB_Update_NegativeTestCases_TestResult_NotFound()
        {

            //Assign
            Mock_IEmployee_Repo.Setup(p => p.employeeUpdate(employeeDetail())).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);
            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_Update(new EmployeeDetails());
            }
            catch (NotFoundException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, "Id Not Found");
            }
        }
        /// <summary>
        /// Bad Request
        /// </summary>
        //[TestMethod]
        public void employeeDetailsB_Get_NegativeTestCases_TestResult_BadRequest()
        {
            //Assign
            Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
            Mock_IEmployee_Repo.Setup(x => x.employeeGet()).Returns(employeeDetailsList);
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);

            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_Get();
            }
            catch (NotFoundException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, "Id Not Found");
            }
        }
        [TestMethod]
        public void employeeDetailsB_GetId_NegativeTestCases_TestResult_BadRequest()
        {
            //Assign
            int Id = 0;
            Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
            Mock_IEmployee_Repo.Setup(x => x.employeeGetId(1)).Returns(employeeDetailsList);
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);
            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_GetId(Id);
            }
            catch (NotFoundException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, "Id Not Found");
            }
        }
        [TestMethod]
        public void employeeDetailsB_DeleteId_NegativeTestCases_TestResult_BadRequest()
        {
            //Assign
            int Id = 0;
            Mock_IEmployee_Repo.Setup(p => p.employeeDelete(Id)).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);
            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_DeleteId(Id);
            }
            catch (NotFoundException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, "Id Not Found");
            }
        }
        [TestMethod]
        public void employeeDetailsB_Add_NegativeTestCases_TestResult_BadRequest()
        {

            //Assign
            Mock_IEmployee_Repo.Setup(p => p.employeeAdd(employeeDetail())).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);
            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_Add(new EmployeeDetails());
            }
            catch (NotFoundException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, "Id Not Found");
            }

        }
        [TestMethod]
        public void employeeDetailsB_Update_NegativeTestCases_TestResult_BadRequest()
        {

            //Assign
            Mock_IEmployee_Repo.Setup(p => p.employeeUpdate(employeeDetail())).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);
            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_Update(new EmployeeDetails());
            }
            catch (NotFoundException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, "Id Not Found");
            }
        }
        /// <summary>
        /// Internal Server
        /// </summary>
        [TestMethod]
        public void employeeDetailsB_Get_NegativeTestCases_TestResult_InternalServer()
        {
            //Assign
            Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
            Mock_IEmployee_Repo.Setup(x => x.employeeGet()).Returns(employeeDetailsList);
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);

            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_Get();
            }
            catch (InternalServerException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, InternalServerError);
            }
        }
        [TestMethod]
        public void employeeDetailsB_GetId_NegativeTestCases_TestResult_InternalServer()
        {
            //Assign
            int Id = 0;
            Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
            Mock_IEmployee_Repo.Setup(x => x.employeeGetId(1)).Returns(employeeDetailsList);
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);
            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_GetId(Id);
            }
            catch (InternalServerException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, InternalServerError);
            }
        }
        [TestMethod]
        public void employeeDetailsB_DeleteId_NegativeTestCases_TestResult_InternalServer()
        {
            //Assign
            int Id = 0;
            Mock_IEmployee_Repo.Setup(p => p.employeeDelete(Id)).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);
            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_DeleteId(Id);
            }
            catch (InternalServerException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, InternalServerError);
            }
        }
        [TestMethod]
        public void employeeDetailsB_Add_NegativeTestCases_TestResult_InternalServer()
        {

            //Assign
            Mock_IEmployee_Repo.Setup(p => p.employeeAdd(employeeDetail())).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);
            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_Add(new EmployeeDetails());
            }
            catch (InternalServerException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, InternalServerError);
            }

        }
        [TestMethod]
        public void employeeDetailsB_Update_NegativeTestCases_TestResult_InternalServer()
        {

            //Assign
            Mock_IEmployee_Repo.Setup(p => p.employeeUpdate(employeeDetail())).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);
            try
            {
                //Act
                var ActResult = AssignResult.employeeDetailsB_Update(new EmployeeDetails());
            }
            catch (InternalServerException exception)
            {
                //Assert
                Assert.AreEqual(exception.Message, InternalServerError);
            }
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
        string InternalServerError = "Exception of type 'Custom_Exceptions.InternalServerException' was thrown.";
    }
}
