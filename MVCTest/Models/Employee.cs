using System.ComponentModel;

namespace MVCTest.Models
{
    public class Employee
    {
        private int _employeeId;
        private string _firstName;
        private string _surname;

        [DisplayName("Employee ID")]
        public int EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        [DisplayName("First Name")]
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        [DisplayName("Surname")]
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        [DisplayName("Full Name")]
        public string FullName
        {
            get { return _firstName + " " + _surname; }
        }
    }
}