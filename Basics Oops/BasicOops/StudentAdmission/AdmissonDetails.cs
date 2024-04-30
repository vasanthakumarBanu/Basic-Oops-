using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{
    public enum AdmissionStatus { select,Admitted,Cancelled}
    public class AdmissonDetails
    {
      
        //field
        //static
        private static int s_admissionID = 1000;

       /* a.	AdmissionID – (Auto Increment ID - AID1001)
            b.	StudentID
            c.	DepartmentID
            d.	AdmissionDate
            e.	AdmissionStatus – Enum- (Select, Admitted, Cancelled)*/

        public string AdmissionID {get;}
        public string StudentID{get;set;}
        public string DepartmentID{get;set;}
        public DateTime AdmissionDate {get;set;}
        public AdmissionStatus AdmissionStatus {get;set;}

        //Constructor 
        public AdmissonDetails(string studentID,string departmentID,DateTime admissionDate, AdmissionStatus admissionStatus)
        { 
            //Auto Increment
            s_admissionID++;
            AdmissionID = "AID"+s_admissionID;

            StudentID = studentID;
            DepartmentID = departmentID;
            AdmissionDate = admissionDate;
            AdmissionStatus = admissionStatus;
            
        }
        public AdmissonDetails(string admission1)
        { 
            string [] Values = admission1.Split(","); 
            AdmissionID = Values[0];
            s_admissionID = int.Parse(Values[0].Remove(0,3));
            StudentID = Values[1];
            DepartmentID = Values[2];
            AdmissionDate =DateTime.Parse(Values[3]);
            AdmissionStatus =Enum.Parse<AdmissionStatus>(Values[4]);
            
        }
        //Methods

    



    }
}