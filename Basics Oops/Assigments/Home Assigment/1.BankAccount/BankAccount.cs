using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _1.BankAccount

{
    public enum Gender { select, Male, Female, Transgender }


    /// <summary>
    /// class BankAccount used to create instance for accounts <see cref="BankAccount"/>
    /// Refer documentation on <see href="www.syncfusion.com"/>
    /// </summary>

    public class BankAccount
    {
        /*
        Class May Contains
        1.Filed - Static and Non-Static
        2.
        
        */
        /// <summary>
        /// Static Field s_ccustomer used to autoincrement StudentID of the instance of <see cref="BankAccount"/>
        /// </summary>

        private static int s_customerID = 1000;  //Field to Autoincrement ID

        /// <summary>
        /// CustomerId Property used to hold a customer'Id of instance of <see cref="BankAccount"/>
        /// </summary>
        ///  /// <value>It accpets string value"HDFC0000"</value>
        public string CustomerId { get; set; }
        /// <summary>
        /// Customername Property used to hold customer's name of instance of<see cref="BankAcount"/> 
        /// </summary>
        /// <value></value>
        public string Customername { get; set; }
        public double Balance { get ;set ;}
        public Gender Gender { get; set; }
        public long Phone { get; set; }
        public string MailId { get; set; }
        public DateTime DOB { get; set; }
     
        
        
        /// <summary>
        /// Constructor BankAccount used to initialize parameter values to its properties.
        /// </summary>
        /// <="customerName"></param>
        /// <param name="gender"></param>
        /// <param name="phone"></param>
        /// <param name="mailId"></param>
        /// <param name="dob"></param>
        /// <param name="balance"></param> <summary>
        /// 
        /// </summary>
        /// <param name="customerName"></param>
        /// <param name="gender"></param>
        /// <param name="phone"></param>
        /// <param name="mailId"></param>
        /// <param name="dob"></param>
        /// <param name="balance"></param>
        public BankAccount(string customerName,
        Gender gender, long phone, string mailId, DateTime dob, double balance)
        {
            s_customerID++;
            CustomerId = "HDFC" + s_customerID;
            Customername = customerName;
            Balance = balance;
            Gender = gender;
            Phone = phone;
            MailId = mailId;
            DOB = dob;

        }
        /// <summary>
        /// This method is withDrawAmount used to subrtact amount from the balance amount of <see cref="BankAccount"/>
        /// </summary>
        /// <param name="withDrawAmount"></param> <summary>
        /// This method is Deposit used to subrtact amount from the balance amount of <see cref="BankAccount"/>
        /// </summary>
        /// <param name="withDrawAmount"></param>
        public  void WithDraw(double withDrawAmount)
        {
            Balance = Balance - withDrawAmount;
        }
        public  void Deposit(double depositAmount)
        {
            Balance = Balance + depositAmount;
        }
        
    
    }

}