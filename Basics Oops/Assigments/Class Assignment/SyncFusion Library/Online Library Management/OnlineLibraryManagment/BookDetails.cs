using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Library_Management
{
    public class BookDetails
    {
        private static int s_bookID = 1000;
        public string BookID {get;}
        public string BookName{get;set;}
        public string AutorName{get;set;}
        public int BookCount{get;set;}
        //Constructor
        public  BookDetails(string bookName,string autorName,int bookCount)
        {
            ++s_bookID;
            BookID = "BID"+s_bookID;
            BookName = bookName;
            AutorName = autorName;
            BookCount =bookCount;
        }
        
        
    }
}

