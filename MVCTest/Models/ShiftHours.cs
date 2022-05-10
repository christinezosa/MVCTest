using System.ComponentModel.DataAnnotations.Schema;

namespace MVCTest.Models
{
    [NotMapped]
    public class ShiftHours
    {
        private int _monthId;
        private string _monthName;
        private int _hours;

        public int MonthId
        {
            get { return _monthId; }
            set { _monthId = value; }
        }

        public string MonthName
        {
            get { return _monthName; }
            set { _monthName = value; }
        }

        public int Hours
        {
            get { return _hours; }
            set { _hours = value; }
        }
    }
}