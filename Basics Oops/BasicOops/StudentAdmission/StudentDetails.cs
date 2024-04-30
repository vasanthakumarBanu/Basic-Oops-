using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum Gender { select, Male, Female }

    public class StudentDetails
    {
        private static int s_studentID = 1000;

        public string StudentID { get; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public int Physics { get; set; }
        public int Chemistry { get; set; }
        public int Maths { get; set; }

        //Constructor 
        public StudentDetails(string studentName, string fatherName, DateTime dob, Gender gender, int physics, int chemistry, int maths)
        {
            //Auto Increment
            s_studentID++;
            StudentID = "SF" + s_studentID;
            StudentName = studentName;
            FatherName = fatherName;
            DOB = dob;
            Gender = gender;
            Physics = physics;
            Chemistry = chemistry;
            Maths = maths;
        }
        public StudentDetails(string student1)
        {
            string[] values = student1.Split(",");
            StudentID = values[0];
            s_studentID = int.Parse(values[0].Remove(0,2));
            StudentName = values[1];
            FatherName = values[2];
            DOB = DateTime.ParseExact(values[3],"dd/MM/yyyy",null);
            Gender = Enum.Parse<Gender>(values[4]);
            Physics = int.Parse(values[5]);
            Chemistry = int.Parse(values[6]);
            Maths = int.Parse(values[7]);
        }
        //Methods
        public double Average()
        {
            int total = Physics + Chemistry + Maths;
            double average = (double)total / 3;
            return average;

        }
        public bool CheckEligibilty(double CutOff)
        {
            if (Average() >= CutOff)
            {
                return true;
            }
            return false;
        }






    }
}