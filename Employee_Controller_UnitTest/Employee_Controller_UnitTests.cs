using Employee_BussinessLayer;
using Employee_Controllers.Controllers;
using Employee_DataAccessLayer;
using Employee_DataAccessLayer.ServiceManager;
using Employee_Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Employee_Controller_UnitTest
{
    [TestClass]
    public class Employee_Controller_UnitTests
    {
        [TestMethod]
        public void getDetails_PositiveTestCases_TestResult()
        {
            var _Repo = (new EmployeeRepo(new Employee_DBContext()));
            var _service = new Employee_Bussiness(_Repo);
            var cntrl = new EmployeeController(_service);
            var res = cntrl.getDetailsId(1).AsyncState();
        }

        private EmployeeDetails GetEmployees_Mock_Positive()
        {
            var EmployeeDetails_Assign = new EmployeeDetails();
            EmployeeDetails_Assign.Username = "Tamil";
            EmployeeDetails_Assign.FullName = "Tamilalagan";
            EmployeeDetails_Assign.DateOfBirth = "01/01/2000";
            EmployeeDetails_Assign.EmailId = "Tamilalagan.s2@mindtree.com";
            EmployeeDetails_Assign.Gender = "Male";
            EmployeeDetails_Assign.Password = "Password";
            return EmployeeDetails_Assign;
        }
        
    }
}
