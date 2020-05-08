using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Employee_Entities
{
    public class EmployeeDetails
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string EmailId { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string SecurityQuestion { get; set; }
        public string SecurityAnswer { get; set; }
        [Key]
        public int Id { get; set; }

    }
}
