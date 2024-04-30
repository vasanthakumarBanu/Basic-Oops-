using System;
namespace StudentAdmission; // File scoped Namespace

class Program
{
    public static void Main(string[] args)
    {
        FileHandling.Create();
        //Operations.AddingDefaultData();
        FileHandling.ReadFromCSV();
        Operations.Mainmenu();
        FileHandling.WriteToCSV();
    }
}