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
        [TestMethod]
        public void getDetails_Positive_TestCase()
        {
            //Assign

            var Mock_IEmployee_Repo = new Mock<IEmployeeRepo>();
            Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();

            Mock_IEmployee_Repo.Setup(x => x.employeeGet()).Returns(employeeDetailsList);
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);

            //Act
            var ActResult = AssignResult.employeeDetailsB_Get();

            //Assert

            Assert.ReferenceEquals(ActResult, employeeDetailsList);
            //Assert.AreEqual(ActResult, employeeDetailsList);
        }
        [TestMethod]
        public void getDetailsId_Positive_TestCase()
        {
            //Assign

            var Mock_IEmployee_Repo = new Mock<IEmployeeRepo>();
            Task<List<EmployeeDetails>> employeeDetailsList = Employees_Mock_Positive();

            Mock_IEmployee_Repo.Setup(x => x.employeeGetId(1)).Returns(employeeDetailsList);
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);

            //Act
            var ActResult = AssignResult.employeeDetailsB_GetId(1);

            //Assert

            Assert.ReferenceEquals(ActResult, employeeDetailsList);
            //Assert.AreEqual(ActResult, employeeDetailsList);
        }
        [TestMethod]
        public void deleteEmployeeId_Positive_TestCase()
        {
            //Assign

            var Mock_IEmployee_Repo = new Mock<IEmployeeRepo>();
            int Id = 1;
            //Act
            Mock_IEmployee_Repo.Setup(p => p.employeeDelete(Id)).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Repo.Object);

            //Assert
            var _actualReturnType = AssignResult.employeeDetailsB_DeleteId(Id);
            Assert.ReferenceEquals(employeeDetail(), _actualReturnType);
            //Assert.AreEqual(ActResult, employeeDetailsList);
        }
        [TestMethod]
        public void addEmployeeDetails_PositiveTestCases_TestResults()
        {

            //Assign
            var Mock_IEmployee_Bussiness = new Mock<IEmployeeRepo>();

            ;
            Mock_IEmployee_Bussiness.Setup(p => p.employeeAdd(employeeDetail())).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Bussiness.Object);

            var _actualReturnType = AssignResult.employeeDetailsB_Add(employeeDetail());
            Assert.ReferenceEquals(employeeDetail(), _actualReturnType);

        }
        [TestMethod]
        public void updateEmployeeDetails_PositiveTestCases_TestResults()
        {

            //Assign
            var Mock_IEmployee_Bussiness = new Mock<IEmployeeRepo>();

            ;
            Mock_IEmployee_Bussiness.Setup(p => p.employeeUpdate(employeeDetail())).Returns(Employees_Mock_Positive());
            Employee_Bussiness AssignResult = new Employee_Bussiness(Mock_IEmployee_Bussiness.Object);

            var _actualReturnType = AssignResult.employeeDetailsB_Update(employeeDetail());
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
    }
}
