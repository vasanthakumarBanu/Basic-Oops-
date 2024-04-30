using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Library_Management
{ 
    public enum Status {Default,Borrowed,Returned}
    public class BorrowDetails
    {   private static int s_borrowID = 1000;
        public string BorrowID {get;}

        public string BookID {get;set;}
        public string UserID {get;set;}
        public DateTime BorrowDate{get;set;}
        public int BorrowBookCount {get;set;}
        public Status Status {get;set;}
        public double PaidFIneAmount{get;set;}
        //Constructor
        public  BorrowDetails(string bookID,string userID,DateTime borrowDate,
        int borrowBookCount,Status status,double paidFIneAmount)
        {
           ++s_borrowID;
            BorrowID = "LB"+s_borrowID;
            BookID = bookID;
            UserID = userID;
            BorrowDate = borrowDate;
            BorrowBookCount = borrowBookCount;
            Status = status;
            PaidFIneAmount = paidFIneAmount;
        }
        
    }
}
