using System;
using _1.BankAccount;
using System.Collections.Generic;
class Program
{
    static List<BankAccount> accountList = new List<BankAccount>();
    public static void Main(string[] args)
    {
        bool flag = true;
        do
        {


            //Account Files
            int option1 = 0;
            System.Console.WriteLine("Welcome to HDFC");
            System.Console.WriteLine("1.Registaration");
            System.Console.WriteLine("2.Login");
            System.Console.WriteLine("3.Exit");
            option1 = int.Parse(Console.ReadLine());

            switch (option1)
            {
                case 1:
                    {   
                        Console.WriteLine("Welcome to Registration Process");
                        System.Console.WriteLine("Enter your Name:");
                        string customername = Console.ReadLine();
                        System.Console.WriteLine("Enter your Gender ");
                        Gender gender = Gender.Parse<Gender>(Console.ReadLine(), true);
                        System.Console.WriteLine("Enter your phone number");
                        long phone = long.Parse(Console.ReadLine());
                        System.Console.WriteLine("Enter your MailID:");
                        string mailId = Console.ReadLine();
                        System.Console.WriteLine("Enter your Date of birth dd/MM/yyyy");
                        DateTime dob = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);
                        System.Console.WriteLine("Enter the amount to Deposit");
                        double balance = double.Parse(Console.ReadLine());

                        BankAccount account = new BankAccount(customername, gender, phone, mailId, dob, balance);
                        accountList.Add(account);

                        System.Console.WriteLine("Your Registration done sucessfully");
                        System.Console.WriteLine("New CutomerID is : " + account.CustomerId);
                        break;
                    }
                case 2:
                    {
                        Login();
                        break;
                    }
                case 3:
                    {
                        
                        flag = false;
                        break;
                    }
            }
        }while(flag);


    }


    
    public static void Login()
    {
        System.Console.WriteLine("Enter the CustomerId");
        string CustomerId = Console.ReadLine();

        foreach (BankAccount id in accountList)
        {

            if (id.CustomerId == CustomerId)
            {
                 bool flag = true;
        do{
        int option2 = 0;
        System.Console.WriteLine("Logged in as  " +CustomerId);
        System.Console.WriteLine("1.Deposit");
        System.Console.WriteLine("2.Withdraw");
        System.Console.WriteLine("3.Diplay Current Balance");
        System.Console.WriteLine("4.Exit");
        option2 = int.Parse(Console.ReadLine());
        switch (option2)
        {
            case 1:
                {
                    System.Console.WriteLine("Enter the amount to Deposit");
                    double depositAmount = double.Parse(Console.ReadLine());
                    id.Deposit(depositAmount);
                    break;
                }
            case 2:
                {
                    System.Console.WriteLine("Enter the amount to WithDraw");
                    double withDrawAmount = double.Parse(Console.ReadLine());

                    id.WithDraw(withDrawAmount);
                    break;
                }
            case 3:
                {
                    Console.WriteLine(id.Balance);
                    break;
                }
            case 4:
                {
                    flag = false;
                    break;
                }
        }
        }while(flag);
                
            }
            else
            {
                System.Console.WriteLine("Invalid UserID,Retry");
            }
        }

    }
  

}

