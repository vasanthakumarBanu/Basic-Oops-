using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;


namespace EBBiollCalculation{
class Program
{
    public static void Main(string[] args)
    {
        List<EbCalc> EbList = new List<EbCalc>();
        int choice;
        do{
            Console.WriteLine("Enter \n1.Registration\n2.Login\n3.Exit");
            choice = int.Parse(Console.ReadLine());

            switch(choice)
            {
                case 1:
                {
                    Console.WriteLine("Registration Process");
                    Console.WriteLine("Enter your UserName");
                    string username = Console.ReadLine();
                    Console.WriteLine("Enter your Phonenumber");
                    string phonenumber = Console.ReadLine();
                    Console.WriteLine("Enter your MailID");
                    string mailID = Console.ReadLine();
                    EbCalc obj = new EbCalc(username,phonenumber,mailID,0);
                    EbList.Add(obj);
                    Console.WriteLine("Your Info Saved");
                    Console.WriteLine("Your ID :" +obj.MeterId);
                    break;
                }
                case 2:
                {
                    System.Console.WriteLine("Welcome to Login");
                    System.Console.WriteLine("Please ENter your MeterID");
                    string meterid = Console.ReadLine().ToUpper();
                    foreach(EbCalc id in EbList)
                    {
                        int choice2=0;
                        if(meterid.Equals(id.MeterId))
                        {
                            do{
                                System.Console.WriteLine("Select Option\n1.Calculate amount\n2.Display user Details\n3.Exit");
                                choice2 = int.Parse(Console.ReadLine());
                                switch(choice2)
                                {
                                    case 1:
                                    {
                                        System.Console.WriteLine("please enter the unit Consumed");
                                        double unit= double.Parse(Console.ReadLine());
                                        double amount = unit*5;
                                        System.Console.WriteLine("|BillID|User name|unit consumed|Amount|");
                                        System.Console.WriteLine($"|{id.BillId}|{id.UserName}|{unit}|{amount}|");
                                        break;
                                    }
                                    case 2:
                                    {
                                        System.Console.WriteLine("|MeterID|User name|Phone|MailId|");
                                        System.Console.WriteLine($"|{id.MeterId}| {id.UserName}|{id.Mobile}|{id.MailId}|");

                                        break;
                                    }
                                    case 3:
                                    {
                                        break;
                                    }
                                }
                            }while(choice2 != 3);
                        }
                        else{
                            System.Console.WriteLine("Invalid MeterID");
                        }
                    }
                    


                    
                    
                    break;
                }

            }
        }while(choice!=3);
        
    }
}
}