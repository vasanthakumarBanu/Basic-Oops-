using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicOops
{
    public class Student
    {
        public int roll;
         public string name;
         public int score;

        public Student()
        {
        }

        public Student(int roll,string name,int score)//Arguments
         {
            this.roll = roll;//"this" is implicit Object reference.
            this.name = name;
            this.score = score;
         }
         
         public void Set_Data()
         {
            Console.Write("Enter Roll:");
            roll = int.Parse(Console.ReadLine());
            Console.Write("Enter Name:");
            name = Console.ReadLine();
            Console.Write("Enter Score:");
            score = int.Parse(Console.ReadLine());

         }
         public void GetData()
         {
            Console.WriteLine("Roll     :"+roll);
            Console.WriteLine("Name     :"+name);
            Console.WriteLine("Score    :"+score);
         }
        public override string ToString()
        {
            return $"{roll}\t{name}\t{score}";
        }

    }
}