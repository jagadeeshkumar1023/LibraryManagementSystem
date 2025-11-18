using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Book
    {
        public int BookId {  get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int CopiesAvailable {  get; set; }

        public  Book(int id,string title,string author,int copies)
        {
            BookId = id;
            Title = title;
            Author = author;
            CopiesAvailable = copies;
        }
    }
}
