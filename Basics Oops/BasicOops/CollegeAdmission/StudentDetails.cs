using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeAdmission
{
    public enum Gender {select,Male, Female, Transgender}

    public class StudentDetails
    {
        //Field
        private static int s_studentID = 1000;
        // Properties
        public string StudentID { get; }
        public string StudentName { get; set; }
        //Autoproperty
        public string Fathername { get; set; }
        public Gender Gender { get; set; }
        public DateTime DOB { get; set; }
        public long Phone { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }

        //Events
        //Indexers
        //Constructor
        public StudentDetails()
        {
            StudentName = "Enter Your Name";
            Fathername = "Enter Your FatherName";
            Gender = Gender.select;
        }
        //Parameterized constructor
        public StudentDetails(string studentName, string fatherName,
        Gender gender, DateTime dob, long phone, int physics, int chemistry, int maths)
        {
            s_studentID++;
            StudentID = "SF" + s_studentID;
            //Assign parameter values to Properties.
            StudentName = studentName;
            Fathername = fatherName;
            Gender = gender;
            DOB = dob;
            Phone = phone;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;

        }
        //Destructor


        //Methods
        public bool CheckEligilibity(double cutOff)
        {
            double average = (Physics + Chemistry + Maths) / 3;
            if (average >= 75)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}