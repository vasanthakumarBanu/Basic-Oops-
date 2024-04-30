using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentAdmission
{  
    public class DepartmentDetails
    { 
        /*a.	DepartmentID – (AutoIncrement - DID101)
            b.	DepartmentName
            c.	NumberOfSeats*/

            private static int s_departmentID = 100;
            public string DepartmentID {get;}
            public string DepartmentName {get;set;}
            public int NumberOfSeats {get;set;}
            
            
            
            public DepartmentDetails(string departmentName, int numberOfSeats)
            {    s_departmentID++;
                DepartmentID = "DID"+s_departmentID;
                DepartmentName = departmentName;
                NumberOfSeats = numberOfSeats;
            }
              public DepartmentDetails(string department)
            {    
                string [] Values = department.Split(",");
                DepartmentID = Values[0];
                s_departmentID = int.Parse(Values[0].Remove(0,3));
                DepartmentName =  Values[1];
                NumberOfSeats =int.Parse(Values[2]);
            }


    }
    
}