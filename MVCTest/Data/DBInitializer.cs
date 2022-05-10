using Microsoft.EntityFrameworkCore;
using MVCTest.Models;

namespace MVCTest.Data
{
    public static class DBInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MVCTestContext(serviceProvider.GetRequiredService<DbContextOptions<MVCTestContext>>()))
            {
                var employees = new Employee[]
                {
                    new Employee
                    {
                        FirstName = "James",
                        Surname = "Brown"
                    },
                    new Employee
                    {
                        FirstName = "Harry",
                        Surname = "Potter"
                    },
                    new Employee
                    {
                        FirstName = "Alice",
                        Surname = "Cooper"
                    },
                    new Employee
                    {
                        FirstName = "Joe",
                        Surname = "Cocker"
                    },
                    new Employee
                    {
                        FirstName = "Neil",
                        Surname = "Young"
                    },
                    new Employee
                    {
                        FirstName = "Rob",
                        Surname = "Roy"
                    }
                };

                if (!context.Employee.Any())
                {
                    foreach (Employee e in employees)
                    {
                        context.Employee.Add(e);
                    }
                    context.SaveChanges();
                }

                var shifts = new Shift[]
                {
                    new Shift
                    {
                        ShiftStart = DateTime.Parse("2020-04-11 09:00:00.000"),
                        ShiftEnd = DateTime.Parse("2020-04-11 17:00:00.000"),
                        ShiftName = "Morning 9-17"
                    },
                    new Shift
                    {
                        ShiftStart = DateTime.Parse("2020-04-12 10:00:00.000"),
                        ShiftEnd = DateTime.Parse("2020-04-12 14:00:00.000"),
                        ShiftName = "Morning 10-14"
                    },
                    new Shift
                    {
                        ShiftStart = DateTime.Parse("2020-04-13 09:00:00.000"),
                        ShiftEnd = DateTime.Parse("2020-04-13 17:00:00.000"),
                        ShiftName = "Morning 9-17"
                    },
                    new Shift
                    {
                        ShiftStart = DateTime.Parse("2020-04-14 10:00:00.000"),
                        ShiftEnd = DateTime.Parse("2020-04-14 14:00:00.000"),
                        ShiftName = "Morning 10-14"
                    },
                    new Shift
                    {
                        ShiftStart = DateTime.Parse("2020-04-15 09:00:00.000"),
                        ShiftEnd = DateTime.Parse("2020-04-15 17:00:00.000"),
                        ShiftName = "Morning 9-17"
                    },
                    new Shift
                    {
                        ShiftStart = DateTime.Parse("2020-05-13 09:00:00.000"),
                        ShiftEnd = DateTime.Parse("2020-05-13 17:00:00.000"),
                        ShiftName = "Morning 9-17"
                    },
                    new Shift
                    {
                        ShiftStart = DateTime.Parse("2020-05-14 09:00:00.000"),
                        ShiftEnd = DateTime.Parse("2020-05-14 17:00:00.000"),
                        ShiftName = "Morning 9-17"
                    }
                };

                if (!context.Shift.Any())
                {
                    foreach (Shift s in shifts)
                    {
                        context.Shift.Add(s);
                    }
                    context.SaveChanges();
                }

                if (!context.EmployeeWorksShift.Any())
                {
                    context.EmployeeWorksShift.AddRange(
                        // April 11 shifts
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Brown").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-11 09:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Potter").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-11 09:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Cooper").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-11 09:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Cocker").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-11 09:00:00.000")).ShiftId
                        },

                        // April 12 shifts
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Brown").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-12 10:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Young").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-12 10:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Roy").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-12 10:00:00.000")).ShiftId
                        },

                        // April 13 shifts
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Brown").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-13 09:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Cocker").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-13 09:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Roy").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-13 09:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Potter").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-13 09:00:00.000")).ShiftId
                        },

                        // April 14 shifts
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Roy").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-14 10:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Potter").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-14 10:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Cocker").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-14 10:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Young").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-14 10:00:00.000")).ShiftId
                        },

                        // April 15 shifts
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Brown").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-15 9:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Potter").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-15 9:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Cooper").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-15 9:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Roy").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-04-15 9:00:00.000")).ShiftId
                        },

                        // May 13 shifts
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Cooper").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-05-13 9:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Young").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-05-13 9:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Potter").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-05-13 9:00:00.000")).ShiftId
                        },

                        // May 14 shifts
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Brown").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-05-14 9:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Young").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-05-14 9:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Potter").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-05-14 9:00:00.000")).ShiftId
                        },
                        new EmployeeWorksShift
                        {
                            EmployeeId = employees.Single(e => e.Surname == "Cooper").EmployeeId,
                            ShiftId = shifts.Single(s => s.ShiftStart == DateTime.Parse("2020-05-14 9:00:00.000")).ShiftId
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
