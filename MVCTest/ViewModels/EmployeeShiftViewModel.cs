using System.ComponentModel;
using Newtonsoft.Json;
using MVCTest.Models;

namespace MVCTest.ViewModels
{
    public class EmployeeShiftsViewModel
    {
        public Employee Employee { get; set; }

        [DisplayName("Total Hours")]
        public ICollection<ShiftHours> TotalHours { get; set; }
    }
}
