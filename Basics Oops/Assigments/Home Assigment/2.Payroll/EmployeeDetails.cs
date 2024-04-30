using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Payroll
{ 
    public enum Branch {select,Eymard,Karuna,Madhura}
    public enum Gender {select,Male,Female,Transgender}
    public enum Team {select,Network,Hardware,Developer,Facility}
    public class EmployeeDetails
    {
        private static int s_employeeID = 1000;
        public string EmployeeID {get;}
        public string FullName {get;set;}
        public DateTime DOB {get;set;}
        public string MobileNumber {get;set;}
        public Branch Branch {get;set;}
        public Team Team {get;set;}
        public Gender Gender {get;set;}
        
        
        
        public EmployeeDetails(string fullName,DateTime dob ,string mobileNumber,Gender gender,Branch branch,Team team)
         {
            s_employeeID++;
            EmployeeID = "SF"+s_employeeID;
            FullName = fullName;
            DOB = dob;
            MobileNumber = mobileNumber;
            Gender = gender;
            Branch = branch;
            Team = team;
         }


    }
}