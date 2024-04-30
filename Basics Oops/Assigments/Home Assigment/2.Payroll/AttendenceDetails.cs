using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll
{
    public class AttendenceDetails
    {
        private static int s_attendenceID = 1001;
        public string AttendenceID { get; }
        public string EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime Checkout { get; set; }
        public  int HoursWorked { get; set; }

        public AttendenceDetails(string employeeID, DateTime date, DateTime checkIn,
        DateTime checkout, int hoursWorked)
        {
            s_attendenceID++;
            AttendenceID = "SF"+s_attendenceID;
            EmployeeID = employeeID;
            Date = date;
            CheckIn = checkIn;
            Checkout = checkout;
            HoursWorked = hoursWorked;

        }

    }
}