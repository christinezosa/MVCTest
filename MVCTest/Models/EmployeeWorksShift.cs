namespace MVCTest.Models
{
    public class EmployeeWorksShift
    {
        public int EmployeeId { get; set; }
        public int ShiftId { get; set; }
        public Employee Employee { get; set; }
        public Shift Shift { get; set; }
    }
}