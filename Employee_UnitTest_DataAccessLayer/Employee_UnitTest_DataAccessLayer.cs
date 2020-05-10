using Custom_Exceptions;
using Employee_DataAccessLayer;
using Employee_DataAccessLayer.ServiceManager;
using Employee_Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Employee_UnitTest_DataAccessLayer
{
    [TestClass]
    public class Employee_UnitTest_DataAccessLayer
    {
        [TestClass]
        public class Employee_UnitTest_BussinessLayer
        {
            Mock<Employee_DBContext> Mock_IEmployee_Repo = new Mock<Employee_DBContext>();
            [TestMethod]
            public void employeeGet_Positive_TestCase()
            {
                //Assign
                Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
                Mock_IEmployee_Repo.Setup(x => x.Employee);
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);

                //Act
                var ActResult = AssignResult.employeeGet();

                //Assert
                Assert.ReferenceEquals(ActResult, employeeDetailsList);
            }
            [TestMethod]
            public void employeeGetId_Positive_TestCase()
            {
                //Assign
                int Id = 1;
                Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
                Mock_IEmployee_Repo.Setup(x => x.Employee.FindAsync(Id));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);

                //Act
                var ActResult = AssignResult.employeeGetId(1);

                //Assert
                Assert.ReferenceEquals(ActResult, employeeDetailsList);
            }
            [TestMethod]
            public void employeeDelete_Positive_TestCase()
            {
                //Assign
                int Id = 1;
                Mock_IEmployee_Repo.Setup(p => p.Remove(employeeDetail()));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);

                //Act
                var _actualReturnType = AssignResult.employeeDelete(Id);

                //Assert
                Assert.ReferenceEquals(employeeDetail(), _actualReturnType);
            }
            [TestMethod]
            public void employeeAdd_PositiveTestCases_TestResults()
            {

                //Assign
                Mock_IEmployee_Repo.Setup(p => p.Add(employeeDetail()));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);

                //Act
                var _actualReturnType = AssignResult.employeeAdd(employeeDetail());

                //Assert
                Assert.ReferenceEquals(employeeDetail(), _actualReturnType);

            }
            [TestMethod]
            public void employeeUpdate_PositiveTestCases_TestResults()
            {
                //Assign
                Mock_IEmployee_Repo.Setup(p => p.Update(employeeDetail()));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);

                //Act
                var _actualReturnType = AssignResult.employeeUpdate(employeeDetail());

                //Assert
                Assert.ReferenceEquals(Employees_Mock_Positive(), _actualReturnType);
            }
            /// <summary>
            /// Not Found
            /// </summary>
            [TestMethod]
            public void employeeGet_NegativeTestCases_TestResult_NotFound()
            {
                //Assign
                Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
                Mock_IEmployee_Repo.Setup(x => x.Employee);
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);

                try
                {
                    //Act
                    var ActResult = AssignResult.employeeGet();
                }
                catch (NotFoundException exception)
                {
                    //Assert
                    Assert.AreEqual(exception.Message, "Id Not Found");
                }
            }
            [TestMethod]
            public void employeeGetId_NegativeTestCases_TestResult_NotFound()
            {
                //Assign
                int Id = 0;
                Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
                Mock_IEmployee_Repo.Setup(x => x.Employee.FindAsync(Id));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);
                try
                {
                    //Act
                    var ActResult = AssignResult.employeeGetId(Id);
                }
                catch (NotFoundException exception)
                {
                    //Assert
                    Assert.AreEqual(exception.Message, "Id Not Found");
                }
            }
            [TestMethod]
            public void employeeDelete_NegativeTestCases_TestResult_NotFound()
            {
                //Assign
                int Id = 0;
                Mock_IEmployee_Repo.Setup(p => p.Remove(employeeDetail()));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);
                try
                {
                    //Act
                    var ActResult = AssignResult.employeeDelete(Id);
                }
                catch (NotFoundException exception)
                {
                    //Assert
                    Assert.AreEqual(exception.Message, "Id Not Found");
                }
            }
            //[TestMethod]
            public void employeeAdd_NegativeTestCases_TestResult_NotFound()
            {

                //Assign
                Mock_IEmployee_Repo.Setup(p => p.Add(employeeDetail()));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);
                try
                {
                    //Act
                    var ActResult = AssignResult.employeeAdd(new EmployeeDetails());
                }
                catch (NotFoundException exception)
                {
                    //Assert
                    Assert.AreEqual(exception.Message, "Id Not Found");
                }

            }
            [TestMethod]
            public void employeeUpdate_NegativeTestCases_TestResult_NotFound()
            {

                //Assign
                Mock_IEmployee_Repo.Setup(p => p.Update(employeeDetail()));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);
                try
                {
                    //Act
                    var ActResult = AssignResult.employeeUpdate(new EmployeeDetails());
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
            public void employeeGet_NegativeTestCases_TestResult_BadRequest()
            {
                //Assign
                Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
                Mock_IEmployee_Repo.Setup(x => x.Employee);
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);

                try
                {
                    //Act
                    var ActResult = AssignResult.employeeGet();
                }
                catch (NotFoundException exception)
                {
                    //Assert
                    Assert.AreEqual(exception.Message, "Id Not Found");
                }
            }
            [TestMethod]
            public void employeeGetId_NegativeTestCases_TestResult_BadRequest()
            {
                //Assign
                int Id = 0;
                Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
                Mock_IEmployee_Repo.Setup(x => x.Employee.FindAsync(Id));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);
                try
                {
                    //Act
                    var ActResult = AssignResult.employeeGetId(Id);
                }
                catch (NotFoundException exception)
                {
                    //Assert
                    Assert.AreEqual(exception.Message, "Id Not Found");
                }
            }
            [TestMethod]
            public void employeeDelete_NegativeTestCases_TestResult_BadRequest()
            {
                //Assign
                int Id = 0;
                Mock_IEmployee_Repo.Setup(p => p.Remove(employeeDetail()));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);
                try
                {
                    //Act
                    var ActResult = AssignResult.employeeDelete(Id);
                }
                catch (NotFoundException exception)
                {
                    //Assert
                    Assert.AreEqual(exception.Message, "Id Not Found");
                }
            }
            [TestMethod]
            public void employeeAdd_NegativeTestCases_TestResult_BadRequest()
            {

                //Assign
                Mock_IEmployee_Repo.Setup(p => p.Add(employeeDetail()));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);
                try
                {
                    //Act
                    var ActResult = AssignResult.employeeAdd(new EmployeeDetails());
                }
                catch (NotFoundException exception)
                {
                    //Assert
                    Assert.AreEqual(exception.Message, "Id Not Found");
                }

            }
            [TestMethod]
            public void employeeUpdate_NegativeTestCases_TestResult_BadRequest()
            {

                //Assign
                Mock_IEmployee_Repo.Setup(p => p.Update(employeeDetail()));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);
                try
                {
                    //Act
                    var ActResult = AssignResult.employeeUpdate(new EmployeeDetails());
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
            /// <returns></returns>
            [TestMethod]
            public void employeeGet_NegativeTestCases_TestResult_InternalServer()
            {
                //Assign
                Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
                Mock_IEmployee_Repo.Setup(x => x.Employee);
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);

                try
                {
                    //Act
                    var ActResult = AssignResult.employeeGet();
                }
                catch (InternalServerException exception)
                {
                    //Assert
                    Assert.AreEqual(exception.Message, InternalServerError);
                }
            }
            [TestMethod]
            public void employeeGetId_NegativeTestCases_TestResult_InternalServer()
            {
                //Assign
                int Id = 0;
                Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();
                Mock_IEmployee_Repo.Setup(x => x.Employee.FindAsync(Id));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);
                try
                {
                    //Act
                    var ActResult = AssignResult.employeeGetId(Id);
                }
                catch (InternalServerException exception)
                {
                    //Assert
                    Assert.AreEqual(exception.Message, InternalServerError);
                }
            }
            [TestMethod]
            public void employeeDelete_NegativeTestCases_TestResult_InternalServer()
            {
                //Assign
                int Id = 0;
                Mock_IEmployee_Repo.Setup(p => p.Remove(employeeDetail()));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);
                try
                {
                    //Act
                    var ActResult = AssignResult.employeeDelete(Id);
                }
                catch (InternalServerException exception)
                {
                    //Assert
                    Assert.AreEqual(exception.Message, InternalServerError);
                }
            }
            [TestMethod]
            public void employeeAdd_NegativeTestCases_TestResult_InternalServer()
            {

                //Assign
                Mock_IEmployee_Repo.Setup(p => p.Add(employeeDetail()));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);
                try
                {
                    //Act
                    var ActResult = AssignResult.employeeAdd(new EmployeeDetails());
                }
                catch (InternalServerException exception)
                {
                    //Assert
                    Assert.AreEqual(exception.Message, InternalServerError);
                }

            }
            [TestMethod]
            public void employeeUpdate_NegativeTestCases_TestResult_InternalServer()
            {

                //Assign
                Mock_IEmployee_Repo.Setup(p => p.Update(employeeDetail()));
                EmployeeRepo AssignResult = new EmployeeRepo(Mock_IEmployee_Repo.Object);
                try
                {
                    //Act
                    var ActResult = AssignResult.employeeUpdate(new EmployeeDetails());
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
}
