using System.ComponentModel;

namespace MVCTest.Models
{
    public class Shift
    {
        private int _shiftId;
        private DateTime _shiftStart;
        private DateTime _shiftEnd;
        private string _shiftName;

        [DisplayName("Shift ID")]
        public int ShiftId
        {
            get { return _shiftId; }
            set { _shiftId = value; }
        }

        [DisplayName("Shift Start")]
        public DateTime ShiftStart
        {
            get { return _shiftStart; }
            set { _shiftStart = value; }
        }

        [DisplayName("Shift End")]
        public DateTime ShiftEnd
        {
            get { return _shiftEnd; }
            set { _shiftEnd = value; }
        }

        [DisplayName("Shift Name")]
        public string ShiftName
        {
            get { return _shiftName; }
            set { _shiftName = value; }
        }

        [DisplayName("Shift Month (Int)")]
        public int ShiftMonthInt
        {
            get { return _shiftStart.Month; }
        }

        [DisplayName("Shift Month")]
        public string ShiftMonth
        {
            get { return _shiftStart.ToString("MMMM"); }
        }

        [DisplayName("Shift Hours")]
        public int ShiftHours
        {
            get { return ((int) (_shiftEnd - _shiftStart).TotalHours); }
        }

        [DisplayName("Employees")]
        public ICollection<Employee> Employee { get; set; }
    }
}