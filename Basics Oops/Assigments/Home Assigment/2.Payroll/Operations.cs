using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace Payroll
{
    public static class Operations
    {
        //Local/global Object creation
        static EmployeeDetails currentLoggedInEmployee;

        static List<EmployeeDetails> employeeList = new List<EmployeeDetails>();
        static List<AttendenceDetails> attendenceList = new List<AttendenceDetails>();
        //Main Menu
        public static void Mainmenu()
        {
            bool flag = true;
            //welcome message
            do
            {
                flag = true;
                System.Console.WriteLine("Welcome to SyncFusion Pvt. Ltd");
                //Need to show MainMenu

                System.Console.WriteLine("MainMenu\n1.Employee Regsitarion\n2.Employee Login\n3.Exit");
                //Need to get input from user and validate.
                System.Console.WriteLine("Select an Option:");
                int mainChoice = int.Parse(Console.ReadLine());
                //Need to Create Mainmenu Structure.

                switch (mainChoice)
                {
                    case 1:
                        {
                            System.Console.WriteLine("*******Employee Registration******");
                            EmployeeRegistration();
                            //Employee Registatrion
                            break;
                        }
                    case 2:
                        {
                            System.Console.WriteLine("*******Employee Login******");
                            Login();
                            //Employee Login
                            break;
                        }
                    case 3:
                        {
                            System.Console.WriteLine("*******Registration Ends******");
                            //Exit
                            flag = false;
                            break;
                        }
                }
            } while (flag == true);
        }
        //Employee Registration  Methods Starts
        public static void EmployeeRegistration()
        {   //Need to get Required deatils.
            Console.WriteLine("Enter Your FullName: ");
            string fullName = Console.ReadLine();
            Console.WriteLine("Enter Your Date of Birth: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.WriteLine("Enter Your Gender:(Male,Female,Transgender) ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.WriteLine("Enter Your MobileNumber: ");
            string mobileNumber = Console.ReadLine();
            Console.WriteLine("Enter Your Branch:Eymard,Karuna,Madhura");
            Branch branch = Enum.Parse<Branch>(Console.ReadLine(), true);
            Console.WriteLine("Enter Your Team:(Network,Hardware,Developer,Facility)");
            Team team = Enum.Parse<Team>(Console.ReadLine(), true);
            //details end
            //Need to get Object.
            EmployeeDetails employee = new EmployeeDetails(fullName, dob, mobileNumber, gender, branch, team);
            Console.WriteLine("Employee Added Succesfully and Your EmployeeID is :" + employee.EmployeeID);
        }//Employee Registraion Ends.
        //Login METHOD starts
        public static void Login()
        {
            System.Console.WriteLine("Enter Your EmployeeId:");
            string loginID = Console.ReadLine().ToUpper();
            //Validate ID
            bool flag = true;
            foreach (EmployeeDetails employee in employeeList)
            {
                if (loginID.Equals(employee.EmployeeID))
                {
                    flag = false;
                    currentLoggedInEmployee = employee;
                    Console.WriteLine("Logged in Successfully.");
                    //submenu
                    SubMenu();
                }
                if (flag)
                {
                    Console.WriteLine("Invadil User ID or ID is not correct");
                }
            }
        }
        //Login METHOD Ends

        //Submenu starts
        public static void SubMenu()
        {
            string subChoice = "yes";
            do
            {
                System.Console.WriteLine("******Employee Login******");
                System.Console.WriteLine("Select an Option\n1.Add Attendance\n2.Display Details\n3.Caculate Salary\n4.Exit");
                int subOption = int.Parse(Console.ReadLine());
                subChoice = "yes";
                switch (subOption)
                {
                    case 1:
                        {  //add Attendance
                            ADDAttendance();

                            break;
                        }
                    case 2:
                        {   //Display details
                            break;
                        }
                    case 3:
                        {   //caculate salary
                            break;
                        }
                    case 4:
                        {
                            //Exit
                            System.Console.WriteLine("Taking back to MainMenu");
                            subChoice = "no";
                            break;
                        }
                }
            } while (subChoice == "yes");
        }
        //submenu Ends


        //Attendence Method
        public static void ADDAttendance()
        {
            //ask the user to date
            System.Console.WriteLine("Enter the CheckIN and CheckOut date:dd/MM/yyyy");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            //ask the user to checkout
            System.Console.WriteLine("Enter the time (24 Hours Format) to Checkin: (hh:mm AM)");
            DateTime checkIn = DateTime.ParseExact(Console.ReadLine(), "HH:mm", null);
            
            System.Console.WriteLine("Enter the time (24 Hours Format) to checkOut: (hh:mm PM)");
            DateTime checkOut = DateTime.ParseExact(Console.ReadLine(), "HH:mm", null);
            //Time Span
            TimeSpan hours = checkOut-checkIn;
            string hoursWorked = hours.ToString();
            int workedTime =int.Parse(hoursWorked);
             int timeWorked =0;
            if(workedTime>4 && workedTime<8)
            {
                 System.Console.WriteLine("Check-in and Check-Out Successful and today you have worked for 4 hours");
                 timeWorked = 4;
            }
            else if(workedTime>7)
            {
                System.Console.WriteLine("Check-in and Check-Out Successful and today you have worked for 8 hours");
                 timeWorked = 8;
            }
            
            //adding to List
            AttendenceDetails todayAttendence = new AttendenceDetails(currentLoggedInEmployee.EmployeeID, date, checkIn, checkOut, timeWorked);
            attendenceList.Add(todayAttendence);

           
        }
        
        public static void AddingDefaultData()
        {//Employee default data
            EmployeeDetails employee1 = new EmployeeDetails("Ravi", new DateTime(1999, 11, 11), "9958858888", Gender.Male, Branch.Eymard, Team.Developer);
            EmployeeDetails employee2 = new EmployeeDetails("Ravi", new DateTime(1997, 11, 11), "9958858555", Gender.Male, Branch.Madhura, Team.Facility);
            employeeList.AddRange(new List<EmployeeDetails> { employee1 });

            //Attendance details default data
            AttendenceDetails attendence1 = new AttendenceDetails(employee1.EmployeeID, new DateTime(2022, 05, 15), new DateTime(2022, 05, 15, 09, 00, 00), new DateTime(2022, 05, 15, 18, 00, 00), 8);
            AttendenceDetails attendence2 = new AttendenceDetails(employee2.EmployeeID, new DateTime(2022, 05, 16), new DateTime(2022, 05, 16, 09, 10, 00), new DateTime(2022, 05, 16, 18, 10, 00), 8);
        }



    }
}