using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace StudentAdmission
{
    //static  class
    public static class Operations
    {
        //Local/Global Object creation
        static StudentDetails currentLoggedInStudent;
        //staic list creation
        public static List<StudentDetails> studentList = new List<StudentDetails>();
        public static List<DepartmentDetails> departmentList = new List<DepartmentDetails>();
        public static List<AdmissonDetails> admissionList = new List<AdmissonDetails>();
        public static void Mainmenu()
        {

            string mainChoice = "yes";
            do
            {
                Console.WriteLine("Welcome to SyncFusion College");
                //Need to show Mainmenu.
                Console.WriteLine("Mainmenu\n1.Student Registration\n2.Student Login\n3.DepartmentList Seat Avialability\n4.Exit");
                //Need to get an  input from user and validate.
                Console.WriteLine("Select an option:");
                int mainOption = int.Parse(Console.ReadLine());
                //Need to create Mainmenu Structure.
                switch (mainOption)
                {
                    case 1:
                        {
                            Console.WriteLine("*********Student Resgistration********");
                            StudentRegistration();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("*********Student Login********");
                            StudentLogin();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("*********Department wise Seat Avialabity********");
                            DepartmentWiseSeatAvialibity();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Application Exited Successfully");
                            mainChoice = "no";
                            break;

                        }

                }
                //Need to iterate untill the option is exit.

            } while (mainChoice == "yes");
            //Mainmenu Ends

        }
        //Student Registration Methods
        public static void StudentRegistration()
        {
            //Need to get required details.
            Console.Write("Enter Your Name: ");
            string studentName = Console.ReadLine();
            Console.Write("Enter Your FatherName: ");
            string fatherName = Console.ReadLine();
            Console.Write("Enter Your Date Of Birth: ");
            DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
            Console.Write("Enter Your Gender: ");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
            Console.Write("Enter Your PhysicsMark: ");
            int physics = int.Parse(Console.ReadLine());
            Console.Write("Enter Your ChemistryMark: ");
            int chemistry = int.Parse(Console.ReadLine());
            Console.Write("Enter Your MathsMark: ");
            int maths = int.Parse(Console.ReadLine());
            //details end

            //Need to get object.
            StudentDetails student = new StudentDetails(studentName, fatherName, dob, gender, physics, chemistry, maths);
            //Need to Add in the list.
            studentList.Add(student);
            //Need to Display Confirmation and ID.
            Console.WriteLine("Registered Succesfully and Your StudentID is :" + student.StudentID);




        }
        //Student Registration Methods ends

        //Student Login Methods
        public static void StudentLogin()
        {
            //need to get Valid Id
            Console.WriteLine("Enter Your StudentID:");
            string loginID = Console.ReadLine().ToUpper();
            //validate in the list
            bool flag = true;
            foreach (StudentDetails student in studentList)
            {
                if (loginID.Equals(student.StudentID))
                {
                    flag = false;
                    //assiging current user to global variable
                    currentLoggedInStudent = student;
                    Console.WriteLine("Logged in Successfully.");
                    //need to call submenu
                    subMenu();
                    break;

                }
            }
            if (flag)
            {
                Console.WriteLine("Invadil User ID or ID is not correct");
            }

            //If invalid print invalid
        }
        //Student Login Methods Ends
        public static void subMenu()
        { //initiate flag;
            string subChoice = "yes";
            do
            {
                System.Console.WriteLine("******Student Login******");
                // need to show submenu Option
                System.Console.WriteLine("Select an Option:\n1.Check Eligbilty\n2.Show details\n3.Take Admission\n4.cancel addmission\n5.show admission details\n6.Exit ");
                //need to get option
                System.Console.WriteLine("Enter your Option:");
                int subOption = int.Parse(Console.ReadLine());
                //check avialibilty
                //show details
                //Take admission
                //cancel addmission
                //show admission details
                //exit
                //option 

                switch (subOption)
                {
                    case 1:
                        {
                            //check avialibilty
                            System.Console.WriteLine("******Avialibilyt******");
                            CheckEligibilty();
                            break;
                        }
                    case 2:
                        {
                             //show details
                            System.Console.WriteLine("******Student details******");
                            ShowDetails();
                            break;
                        }
                    case 3:
                        {
                             //Take admission
                            System.Console.WriteLine("******Take Admission******");
                            TakeAdmission();
                            break;
                        }
                    case 4:
                        {
                            //cancel addmission
                            System.Console.WriteLine("******cancel addmission******");
                            CancelAdmission();
                            break;
                        }
                    case 5:
                        {
                            //show admission details
                            System.Console.WriteLine("******show admission details******");
                            AdmissionDetails();
                            break;
                        }
                    case 6:
                        {
                            //exit
                            System.Console.WriteLine("Taking back to MainMenu");
                            subChoice = "no";
                            break;
                        }
                }

            } while (subChoice == "yes");

        }
        //SubMenu ends
        //Eligibilty Methods start
        public static void CheckEligibilty()
        {
            //need to get CutOFFvalue
            System.Console.WriteLine("Enter the CutOff Value:");
            double cutOffValue = double.Parse(Console.ReadLine());
           //check eligible or not.
           if(currentLoggedInStudent.CheckEligibilty(cutOffValue))
           {
             System.Console.WriteLine("Student is eligible");
           }
           else
           {
             System.Console.WriteLine("Student is not eligible");
           }

        }
        //Eligibilty Methods Ends

        //Showdetails Methods start
        public static void ShowDetails()
        {
            foreach (StudentDetails student in studentList)
                Console.WriteLine("|Student ID|Student Name|Father Name|Date Of Birth|Gender|Physics Marks|Chemistry Marks|Maths marks|");
            {
                Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.Physics}|{currentLoggedInStudent.Chemistry}|{currentLoggedInStudent.Maths}");
            }
        }
        //Showdetails Methods Ends
        //takeAdmissio Methods start
        public static void TakeAdmission()
        {
            //Need to show avilible department details.
            DepartmentWiseSeatAvialibity();
            //Ask department ID from user
            System.Console.WriteLine("Select an Department ID:");
            string departmentID = Console.ReadLine();
            //Check ID present or not.
            bool flag = true;
            foreach(DepartmentDetails department in departmentList)
            {
                if(departmentID.Equals(department.DepartmentID))
                {
                    flag = false;
                        //check the student is eligible or not
                        if(currentLoggedInStudent.CheckEligibilty(75.0))
                        {
                             //check seat aviliablity
                             if(department.NumberOfSeats>0)
                             { int count = 0;
                             //check student already taken any admission
                                foreach(AdmissonDetails admisson in admissionList)
                                { 
                                    if(currentLoggedInStudent.StudentID.Equals(admisson.StudentID) && admisson.AdmissionStatus.Equals(AdmissionStatus.Admitted))
                                    {
                                        count++;
                                    }
                                }
                                    if(count==0)
                                    {
                                        
                                        //create Admission object.
                                        AdmissonDetails admissiontaken = new AdmissonDetails(currentLoggedInStudent.StudentID,department.DepartmentID,DateTime.Now,AdmissionStatus.Admitted);
                                        //Reduce seat count
                                        department.NumberOfSeats--;
                                        //Add to addmission list
                                        admissionList.Add(admissiontaken);
                                        //show addmision successfull
                                        Console.WriteLine($"You have taken the Addmission, Your Addmission ID is:"+ admissiontaken.AdmissionID);

                                    }
                                    else
                                    {
                                        System.Console.WriteLine("You Already Took Admission");
                                    }

                                
                                 
                                
                             }
                             else
                             {
                                System.Console.WriteLine("Seats are not avilable in this Department");
                             }
                       

                        }
                        else
                        {
                            System.Console.WriteLine("Your are not eligible due to low cutoff");
                        }
                       
                        break;

                }
                
            }
            if(flag)
            {
                System.Console.WriteLine("Invalid id or Already Taken");
            }
          
        }
        //takeAdmissio MethodsEnds
        //cancelAdmission Methods start
        public static void CancelAdmission()
        {
            bool flag = true;
            //check the student is taken admission and diplay it.
            foreach(AdmissonDetails admisson in admissionList)
            {
                if(currentLoggedInStudent.StudentID.Equals(admisson.StudentID)&&(admisson.AdmissionStatus == AdmissionStatus.Admitted))
                {
                    //cancel the found admission
                    admisson.AdmissionStatus =AdmissionStatus.Cancelled;
                    //return the seat to department
                    foreach(DepartmentDetails department in departmentList)
                    {
                        if(admisson.DepartmentID.Equals(department.DepartmentID))
                    {
                        department.NumberOfSeats++;
                        break;
                    }
                    }
                    
                }
                if (flag)
                {
                    System.Console.WriteLine("your ID not found");
                    break;
                }

            }
           
        }
        //cancelAdmissionMethods Ends


        //admissionDetails Methods start
        public static void AdmissionDetails()
        
        {
            System.Console.WriteLine("Enter Your Admission ID");
            //Need to show current Logged in studetn addmissin details.
            
                foreach(AdmissonDetails admisson in admissionList)
            {
                
                if(currentLoggedInStudent.StudentID.Equals(admisson.StudentID))
                {
                    System.Console.WriteLine($"|{admisson.AdmissionID}|{admisson.DepartmentID}|{admisson.StudentID}|{admisson.AdmissionStatus}|");
                }
                //Missed
            }
           

        }
        //admissionDetails  Methods Ends

        //Student SeatAvialibity Methods
        public static void DepartmentWiseSeatAvialibity()
        {
            //Need to show all Department details
            System.Console.WriteLine("|DepartmentID|DepartmentName|NumberOfSeats|");
            foreach (DepartmentDetails department in departmentList)
            {
                Console.WriteLine($"|{department.DepartmentID}|{department.DepartmentName}|{department.NumberOfSeats}");
            }

        }
        //Student SeatAvialibity Methods Ends


        //Adding data
        public static void AddingDefaultData()
        {  //students details default data
            StudentDetails student1 = new StudentDetails("Ravichandran E", "Ettapparajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            StudentDetails student2 = new StudentDetails("Baskaran S", "Sethurajan", new DateTime(1999, 11, 11), Gender.Male, 95, 95, 95);
            studentList.AddRange(new List<StudentDetails> { student1, student2 });

            //Department details default data
            DepartmentDetails department1 = new DepartmentDetails("EEE", 29);
            DepartmentDetails department2 = new DepartmentDetails("CSE", 29);
            DepartmentDetails department3 = new DepartmentDetails("MECH", 30);
            DepartmentDetails department4 = new DepartmentDetails("ECE", 30);
            departmentList.AddRange(new List<DepartmentDetails> { department1, department2, department3, department4 });


            //Addminsion Details default data

            AdmissonDetails admisson1 = new AdmissonDetails(student1.StudentID, department1.DepartmentID, new DateTime(2022, 05, 11), AdmissionStatus.Admitted);
            AdmissonDetails admisson2 = new AdmissonDetails(student2.StudentID, department2.DepartmentID, new DateTime(2022, 05, 12), AdmissionStatus.Admitted);
            admissionList.AddRange(new List<AdmissonDetails> { admisson1, admisson2 });
           
            //Main menu


            //Printing Data
            // foreach (StudentDetails student in studentList)
            // {
            //     Console.WriteLine($"|{currentLoggedInStudent.StudentID}|{currentLoggedInStudent.StudentName}|{currentLoggedInStudent.FatherName}|{currentLoggedInStudent.DOB}|{currentLoggedInStudent.Gender}|{currentLoggedInStudent.Physics}|{currentLoggedInStudent.Chemistry}|{currentLoggedInStudent.Maths}");
            // }
            //     foreach(AdmissonDetails admisson in admissionList)
            // {
            //     if(currentLoggedInStudent.StudentID.Equals(admisson.StudentID))
            //     {
            //         System.Console.WriteLine($"|{admisson.AdmissionID}{admisson.DepartmentID}{admisson.StudentID}{admisson.AdmissionStatus}");
            //     }
            // }

        }
    }
}