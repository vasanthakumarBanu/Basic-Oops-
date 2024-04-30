using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Library_Management
{  //Field static
    public enum Gender {select , Male, Female,Tansgender}
    public  class UserDetails
    {
        private static int s_userID = 3000;
        public string UserID {get;}
        public string UserName {get;set;}
        public Gender Gender {get;set;}
        public string Department {get;set;}
        public string MobileNumber {get;set;}
        public string MailID {get;set;}
        public double WalletBalance {get;set;}
        //Constructor

      public UserDetails(string userName,Gender gender,string department,string mobileNumber,string mailID,double walletBalance)
      {
        ++s_userID;
        UserID = "SF"+ s_userID;
        UserName = userName;
        Gender = gender;
        MobileNumber = mobileNumber;
        MailID = mailID;
        WalletBalance = walletBalance;

      }
      //Methods for 
    }
}