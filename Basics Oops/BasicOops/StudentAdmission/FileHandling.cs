using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public static  class FileHandling
    {
        public static void Create()
        {
            if (!Directory.Exists("StudentAdmission"))
            {
                System.Console.WriteLine("Creating Folder");
                Directory.CreateDirectory("StudentAdmission");
            }
            else
            {
                System.Console.WriteLine("Folder Already Exists");
            }

            if (!File.Exists(@"D:\SyncFusion\Phase -II\Oops\BasicOops\StudentAdmission\Studentinfo.csv"))
            {
                System.Console.WriteLine("Creating File....");
                File.Create(@"D:\SyncFusion\Phase -II\Oops\BasicOops\StudentAdmission\Studentinfo.csv").Close();

            }
            else
            { System.Console.WriteLine("File Already Exists");
            }

            if (!File.Exists(@"D:\SyncFusion\Phase -II\Oops\BasicOops\StudentAdmission\AdmissionInfo.csv"))
            {
                System.Console.WriteLine("Creating File....");
                File.Create(@"D:\SyncFusion\Phase -II\Oops\BasicOops\StudentAdmission\AdmissionInfo.csv").Close();

            }
            else
            
            {
                 System.Console.WriteLine("File Already Exists");
            }
             if (!File.Exists(@"D:\SyncFusion\Phase -II\Oops\BasicOops\StudentAdmission\DepartmentInfo.csv"))
            {
                System.Console.WriteLine("Creating File....");
                File.Create(@"D:\SyncFusion\Phase -II\Oops\BasicOops\StudentAdmission\DepartmentInfo.csv").Close();

            }
            else
            {
                 System.Console.WriteLine("File Already Exists");
            }
        }

        public static void WriteToCSV()
        {
            //Students info
            string [] students = new string[Operations.studentList.Count];
            for(int i = 0;i<Operations.studentList.Count;i++)
            {
                
                students[i]=Operations.studentList[i].StudentID+","+Operations.studentList[i].StudentName+","+Operations.studentList[i].FatherName+","+Operations.studentList[i].DOB.ToString("dd/MM/yyyy")+","+Operations.studentList[i].Gender+","+Operations.studentList[i].Physics+","+Operations.studentList[i].Chemistry+","+Operations.studentList[i].Maths;
            }
            File.WriteAllLines(@"D:\SyncFusion\Phase -II\Oops\BasicOops\StudentAdmission\Studentinfo.csv",students);

            string [] department = new string[Operations.departmentList.Count];
            for(int i=0;i<Operations.departmentList.Count;i++)
            {
                department[i]=Operations.departmentList[i].DepartmentID+","+Operations.departmentList[i].DepartmentName+","+Operations.departmentList[i].NumberOfSeats;
            }
            File.WriteAllLines(@"D:\SyncFusion\Phase -II\Oops\BasicOops\StudentAdmission\Departmentinfo.csv",department);
        
            string [] admission = new string[Operations.admissionList.Count];
            for(int i=0;i<Operations.admissionList.Count;i++)
            {
                admission[i]=Operations.admissionList[i].AdmissionID+","+Operations.admissionList[i].StudentID+","+Operations.admissionList[i].DepartmentID+","+Operations.admissionList[i].AdmissionDate+","+Operations.admissionList[i].AdmissionStatus;
            }
             File.WriteAllLines(@"D:\SyncFusion\Phase -II\Oops\BasicOops\StudentAdmission\Admissioninfo.csv",admission);

        
        
        
        
        
        
        }

        public static void ReadFromCSV()
        {
            string [] students = File.ReadAllLines(@"D:\SyncFusion\Phase -II\Oops\BasicOops\StudentAdmission\Studentinfo.csv");
            foreach(string student in students)
            {
                StudentDetails student1 = new StudentDetails(student);
                Operations.studentList.Add(student1);

            }

            string [] departments = File.ReadAllLines(@"D:\SyncFusion\Phase -II\Oops\BasicOops\StudentAdmission\Departmentinfo.csv");
            
            
            foreach(string department in departments)
            {
    
                DepartmentDetails department1 = new DepartmentDetails(department);
                Operations.departmentList.Add(department1);

            }
            string [] admissions = File.ReadAllLines(@"D:\SyncFusion\Phase -II\Oops\BasicOops\StudentAdmission\Admissioninfo.csv");
              foreach(string admission in admissions)
            {
    
                AdmissonDetails admission1 = new AdmissonDetails(admission);
                Operations.admissionList.Add(admission1);

            }
        
        
        
        }
    }
}