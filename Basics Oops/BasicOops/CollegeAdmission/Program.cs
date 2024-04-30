using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.ConstrainedExecution;
namespace CollegeAdmission;
class Program
{
  public static void Main(string[] args)

  {   //Document File           
    List<StudentDetails> studentList = new List<StudentDetails>();
    string option = "";

    do
    { //Action to be repeated
      //StudentDetails student1 = new StudentDetails();
      System.Console.WriteLine("Student Registration form");


      System.Console.WriteLine("Enter Your name");
      string studentName = Console.ReadLine();
      System.Console.WriteLine("Enter your Father Name");
      string fatherName = Console.ReadLine();
      System.Console.WriteLine("Enter your Gender ");
      Gender gender =Enum.Parse<Gender>(Console.ReadLine(),true);
      System.Console.WriteLine("Enter your Date of birth dd/MM/yyyy");
      DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
      System.Console.WriteLine("Enter your phone number");
      long phone = long.Parse(Console.ReadLine());
      System.Console.WriteLine("Enter your physics mark");
      int physics = int.Parse(Console.ReadLine());
      System.Console.WriteLine("Enter your chemistry mark");
      int chemistry = int.Parse(Console.ReadLine());
      System.Console.WriteLine("Enter your maths mark");
      int maths = int.Parse(Console.ReadLine());
      //{+Parameter Constructor object}
      StudentDetails student = new StudentDetails(studentName, fatherName, gender, dob, phone, physics, chemistry, maths);
      System.Console.WriteLine("You have registered successfully. Your ID: "+student.StudentID);
      studentList.Add(student);

      //Loop breaker
      System.Console.WriteLine("Do you want to continue ?");
      option = Console.ReadLine();

    } while (option == "yes");

    foreach (StudentDetails student in studentList)
    {

      System.Console.WriteLine("Name: " + student.StudentName + "\n" + "FatherName:" + student.Fathername);
      System.Console.WriteLine("DOB:" + student.DOB + "\nGender: " + student.Gender + "\nPhone: " + student.Phone);
      System.Console.WriteLine("Physics:" + student.Physics + "\nChemistry:" + student.Chemistry + "\nMaths" + student.Maths);
      bool eligibility = student.CheckEligilibity(75);
      if (eligibility)
      {
        System.Console.WriteLine("You are eligible for admission");
      }
      else
      {
        System.Console.WriteLine("You are not eligible for admission");
      }
    }


  }
}