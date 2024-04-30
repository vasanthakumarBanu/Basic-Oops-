using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Online_Library_Management
{
  public static class Operations
  {    //static Local/Global
    static UserDetails currentLoggedIn;
    static string line = "-----------------------------------------------------------------------";

    //list
    static List<UserDetails> userList = new List<UserDetails>();
    static List<BookDetails> bookList = new List<BookDetails>();
    static List<BorrowDetails> borrowList = new List<BorrowDetails>();

    //MainMenu
    public static void Mainmenu()
    {

      bool choice = true;
      do
      {
        System.Console.WriteLine(line);
        System.Console.WriteLine("******Welcome to SyncFusion college's Library****** ");

        //create Options
        System.Console.WriteLine("Select your Option\n1.User Registration\n2.UserLogin\n3.Exit");
        System.Console.WriteLine(line);
        //get input to select options
        int option = int.Parse(Console.ReadLine());
        choice = false;
        switch (option)
        {
          case 1:
            {
              //user registaration
              userRegistations();
              break;
            }
          case 2:
            {
              Login();
              //user login
              break;
            }
          case 3:
            {
              //exit
              choice = true;
              break;
            }

        }
      } while (choice == false);
      if (true)
      {
        Console.WriteLine("Thank your for your Valubel time , Come Again");
        System.Console.WriteLine(line);
      }
    }
    //userRegistations methods start

    public static void userRegistations()
    {
      System.Console.WriteLine(line);
      System.Console.WriteLine("******Welcome to SyncFusion College Library-User Registration******");
      System.Console.WriteLine("Please enter the UserName: ");
      string userName = Console.ReadLine();
      System.Console.WriteLine("Please Specify your Gender:(Male,Female,Transgender)");
      Gender gender = Enum.Parse<Gender>(Console.ReadLine(), true);
      System.Console.WriteLine("Please Specify your Department(EX:ECE)");
      string department = Console.ReadLine();
      System.Console.WriteLine("Please enter your 10 Digit MobileNumber(Ex:8110877339)");
      string mobileNumber = Console.ReadLine();
      System.Console.WriteLine("Please enter your E-MailID(Ex:Vasanthbanukumar@gmail.com)");
      string mailID = Console.ReadLine();
      System.Console.WriteLine("Please enter the Amount to recharge your wallet (Ex:100.00)");
      double walletBalance = double.Parse(Console.ReadLine());
      UserDetails user = new UserDetails(userName, gender, department, mobileNumber, mailID, walletBalance);
      System.Console.WriteLine("Hooray!!! User Registration Done Succefully and Your UserID is:" + user.UserID);
      System.Console.WriteLine(line);

    }
    //userRegistations methods ends

    //userLogin Starts
    public static void Login()
    {
      System.Console.WriteLine(line);
      //welcome
      System.Console.WriteLine("*****Welcome SyncFusion Login Page****");
      System.Console.WriteLine(line);
      //Get userID
      System.Console.WriteLine("Enter the UserID to Login(Ex:SF3001)");
      string loginID = Console.ReadLine().ToUpper();
      //Validate ID


      bool flag = false;
      foreach (UserDetails user in userList)
      {
        if (loginID.Equals(user.UserID))
        {
          currentLoggedIn = user;
          flag = true;
          break;
        }
      }
      if (flag)
      {
        //passing all details of current user to new variable
        System.Console.WriteLine("Login Sucessfull");
        System.Console.WriteLine(line);
        //submenu
        SubMenu();
      }
      else
      {
        System.Console.WriteLine("Invalid ID or ID Not present");
        System.Console.WriteLine(line);
      }

      //ask user to enter the ID
      //validate id
      // exist show menu



    }
    //usr login Ends

    //Ading  Default starts
    public static void AddingDefaultData()
    {
      //Deafult userdetails
      UserDetails userName1 = new UserDetails("ravichandran", Gender.Male, "EEE", "99383883333", "ravi@gmail.com", 100);
      UserDetails userName2 = new UserDetails("Priyadharshini", Gender.Female, "CSE", "9944444455", "priya@gmail.com", 150);
      userList.AddRange(new List<UserDetails> { userName1, userName2 });
      //Deafult Boookdetails
      BookDetails newbook1 = new BookDetails("C#", "Author1", 3);
      BookDetails newbook2 = new BookDetails("HTML", "Author2", 5);
      BookDetails newbook3 = new BookDetails("CSS", "Author3", 3);
      BookDetails newbook4 = new BookDetails("JS", "Author4", 3);
      BookDetails newbook5 = new BookDetails("TS", "Author5", 2);
      bookList.AddRange(new List<BookDetails> { newbook1, newbook2, newbook3, newbook4, newbook5 });
      //default Borrow details
      BorrowDetails newborrow1 = new BorrowDetails(newbook1.BookID, userName1.UserID, new DateTime(2023, 09, 10), 2, Status.Borrowed, 0);
      BorrowDetails newborrow2 = new BorrowDetails(newbook3.BookID, userName1.UserID, new DateTime(2023, 09, 12), 2, Status.Borrowed, 0);
      BorrowDetails newborrow3 = new BorrowDetails(newbook4.BookID, userName1.UserID, new DateTime(2023, 09, 14), 2, Status.Returned, 16);
      BorrowDetails newborrow4 = new BorrowDetails(newbook2.BookID, userName2.UserID, new DateTime(2023, 09, 11), 2, Status.Borrowed, 0);
      BorrowDetails newborrow5 = new BorrowDetails(newbook5.BookID, userName2.UserID, new DateTime(2023, 09, 09), 2, Status.Returned, 20);
      borrowList.AddRange(new List<BorrowDetails> { newborrow1, newborrow2, newborrow3, newborrow4, newborrow5 });
    }
    //Adding Default Ends

    //SubMneu Method Starts
    public static void SubMenu()
    {
      string option1 = "y";
      do
      {
        System.Console.WriteLine("******Welcome To SubMenu*****");
        System.Console.WriteLine(line);
        System.Console.WriteLine("Select the option\n1.Borrowbook\n2.ShowBorrowHitory\n3.ReturnBooks\n4.WalletRecharge\n5.Exit");
        System.Console.WriteLine(line);


        int choice = int.Parse(Console.ReadLine());
        //Diplayin Choice for submenu
        switch (choice)
        {
          case 1:
            {//Method for Boroow book
              ShowDetails();
              //CheckAvialibity 

              break;
            }
          case 2:
            {
              ShowBorrowHitory();
              //Method for ShowBoroow history
              break;
            }
          case 3:
            {
              ReturnBooks();
              //Method for ReturnBook
              break;
            }
          case 4:
            {//Method for walletRecharge
              break;
            }
          case 5:
            {
              option1 = "n";
              break;
            }
        }
      } while (option1 == "y");

    }
    //SubMenu Method Ends

    //Show details Menu starts
    public static void ShowDetails()
    { // show the input book id details
      System.Console.WriteLine(line);
      Console.WriteLine("|Book ID     |Book Name     |Author Name     |BookCount");
      foreach (BookDetails book in bookList)
      {

        Console.WriteLine($"|{book.BookID}|{book.BookName}|{book.BookCount}");
      }
      System.Console.WriteLine(line);
      //Get the Book id 

      System.Console.WriteLine("Please Enter the Book Id to Borrow (EX:BID1003)");
      string newBookID = Console.ReadLine().ToUpper();
      //seach for the user bookid
      bool flag = false;
      foreach (BookDetails book in bookList)
      {
        if (newBookID.Equals(book.BookID))
        {
          flag = true;
          System.Console.WriteLine("Enter the count of the book you wish to purchase");

          int needCount = int.Parse(Console.ReadLine());
          int count = 0;

          if (needCount <= book.BookCount)
          {// Any book borrowed verifiction
            System.Console.WriteLine("Book is Avilable for the Entered count");
            foreach (BorrowDetails borrowcount in borrowList)
            {

              if (currentLoggedIn.UserID == borrowcount.UserID && borrowcount.Status.Equals(Status.Borrowed))
              {
                count = borrowcount.BorrowBookCount;
              }
            }

            if (count > 3)
            {
              Console.WriteLine("You had Borrowed 3 books already");
              break;
            }
            else
            {
              if (count + needCount > 3)
              {
                System.Console.WriteLine($"You can have maximum of 3 borrowed books. Your already borrowed books count is {count} and requested count is {needCount}, which exceeds 3");
              }
              else
              {
                BorrowDetails borrow = new BorrowDetails(book.BookID, currentLoggedIn.UserID, DateTime.Now, needCount, Status.Borrowed, 0);
                borrowList.Add(borrow);
                book.BookCount -= needCount;
                System.Console.WriteLine($"Book Borrowed  Sucessfully and ID is{borrow.BorrowID}");
                break;
              }

            }
          }
          else
          {
            System.Console.WriteLine($"The books are not avilable for the selected count.The Avilable count for the selected book is{book.BookCount}");
            foreach (BorrowDetails borrow in borrowList)
            {
              System.Console.WriteLine($"The Selected book is avilabe on {borrow.BorrowDate.AddDays(15).ToString("dd/MM/yyyy")}");
            }
          }
        }

      }
      if (flag == false)
      {
        System.Console.WriteLine("Invalid Book ID Please Enter the Valid ID");
      }


    }
    //Show details Menu Ends


    //Show Book history Starts
    public static void ShowBorrowHitory()
    {
      bool flag = true;
      foreach (BorrowDetails borrow in borrowList)
      {

        if (currentLoggedIn.UserID.Equals(borrow.UserID))
        {
          flag = false;
          break;
        }
      }
      if (!flag)
      {
        System.Console.WriteLine("|{BorrowID}|{Book ID}|{User ID}|{Borrow Date}|{Borrow Book Count}|{Status}|Paid Fine Amount ");
        foreach (BorrowDetails borrow in borrowList)
        {
          if (currentLoggedIn.UserID.Equals(borrow.UserID))
            System.Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowDate}|{borrow.BorrowBookCount}|{borrow.Status}|{borrow.PaidFIneAmount}");
        }
      }
      else
      {
        System.Console.WriteLine("There are Histroty in your borrowed List");
      }

    }
    //Show Book History Ends
    public static void ReturnBooks()
    {
      bool flag = true;
      foreach (BorrowDetails borrow in borrowList)
      {
        if (currentLoggedIn.UserID.Equals(borrow.UserID) && (borrow.Status.Equals(Status.Borrowed)))
        {
          flag = true;
          break;
        }
      }
      if (flag)
      {
        System.Console.WriteLine("|{BorrowID}|{Book ID}|{User ID}|{Borrow Date}|{Borrow Book Count}|{Status}|Paid Fine Amount ");
        int fine = 0;
        foreach (BorrowDetails borrow in borrowList)
        {
          if (currentLoggedIn.UserID.Equals(borrow.UserID) && borrow.Status.Equals(Status.Borrowed))
          {
            TimeSpan span = DateTime.Now - borrow.BorrowDate;
            if ((int)span.TotalDays <= 15)
            {
              fine = 0;
            }
            else
            {
              fine = (int)span.TotalDays - 15;
            }
            System.Console.WriteLine($"|{borrow.BorrowID}|{borrow.BookID}|{borrow.UserID}|{borrow.BorrowDate.ToShortDateString}|{borrow.BorrowBookCount}|{borrow.Status}|{borrow.PaidFIneAmount}");

          }


        }
        flag = false;
        System.Console.WriteLine("Enter the borrow ID you wish to cancel");
        string borrowedID = Console.ReadLine();
        foreach (BorrowDetails borrow in borrowList)
        {
          if (borrow.UserID.Equals(currentLoggedIn.UserID) && borrow.Status.Equals(Status.Borrowed) && borrow.BorrowID.Equals(borrowedID))
          {
            flag = true;
            TimeSpan span = DateTime.Now - borrow.BorrowDate;
            if ((int)span.TotalDays <= 15)
            {
              fine = 0;
            }
            else
            {
              fine = (int)span.TotalDays - 15;
            }
            if (currentLoggedIn.WalletBalance >= fine)
            {
              //currentLoggedIn.DeductWalletBalance(fine);
              borrow.Status = Status.Returned;
              borrow.PaidFIneAmount = fine;
              foreach (BookDetails book in bookList)
              {
                if (borrow.BookID.Equals(book.BookID))
                {
                  book.BookCount += borrow.BorrowBookCount;
                  break;
                }

              }
              System.Console.WriteLine("Book return successfully");
            }
            else
            {
              System.Console.WriteLine("Insufficient balance please Recharge and proceed");
              break;
            }
          }
        }
        if (flag == false)
        {
          System.Console.WriteLine("Enter Valid Borrow ID");
        }
      }
      else
      {
        System.Console.WriteLine("User didn't borrow any books to return");
      }
    }


  }
}

