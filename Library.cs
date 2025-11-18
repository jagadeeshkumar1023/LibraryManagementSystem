using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryManagementSystem
{
    public class Library
    {
        private List<Book> books;
        private List<Member> members;

        private string bookFile = "books.txt";
        private string memberFile = "members.txt";

        public Library()
        {
            books = new List<Book>();
            members = new List<Member>();
            LoadData();
        }


        private void LoadData()
        {
            // Load Books
            if (File.Exists(bookFile))
            {
                var lines = File.ReadAllLines(bookFile);
                foreach (var line in lines)
                {
                    string[] data = line.Split(',');
                    books.Add(new Book(
                        int.Parse(data[0]),
                        data[1],
                        data[2],
                        int.Parse(data[3])
                    ));
                }
            }

            // Load Members
            if (File.Exists(memberFile))
            {
                var lines = File.ReadAllLines(memberFile);
                foreach (var line in lines)
                {
                    string[] data = line.Split(',');
                    members.Add(new Member(
                        int.Parse(data[0]),
                        data[1]
                    ));
                }
            }
        }

        private void SaveData()
        {
            File.WriteAllLines(bookFile,
                books.Select(b => $"{b.BookId},{b.Title},{b.Author},{b.CopiesAvailable}")
            );

            File.WriteAllLines(memberFile,
                members.Select(m => $"{m.MemberId},{m.Name}")
            );
        }

        
        public void AddBook()
        {
            Console.Write("Enter Book ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Title: ");
            string title = Console.ReadLine();

            Console.Write("Enter Author: ");
            string author = Console.ReadLine();

            Console.Write("Enter Copies: ");
            int copies = int.Parse(Console.ReadLine());

            books.Add(new Book(id, title, author, copies));
            SaveData();
            Console.WriteLine("Book added successfully!");
        }

        
        public void ListBooks()
        {
            Console.WriteLine("\n--- ALL BOOKS ---");
            foreach (var b in books)
                Console.WriteLine($"{b.BookId} - {b.Title} by {b.Author} | Copies: {b.CopiesAvailable}");
        }

        
        public void SearchBook()
        {
            Console.Write("\nEnter title or author to search: ");
            string input = Console.ReadLine().ToLower();

            var results = books.Where(b =>
                b.Title.ToLower().Contains(input) ||
                b.Author.ToLower().Contains(input)).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No books found.");
            }
            else
            {
                Console.WriteLine("\n--- SEARCH RESULTS ---");
                foreach (var b in results)
                    Console.WriteLine($"{b.BookId} - {b.Title} by {b.Author} | Copies: {b.CopiesAvailable}");
            }
        }

        public void AddMember()
        {
            Console.Write("Enter Member ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Member Name: ");
            string name = Console.ReadLine();

            members.Add(new Member(id, name));
            SaveData();
            Console.WriteLine("Member added successfully!");
        }

        
        public void BorrowBook()
        {
            Console.Write("Enter Member ID: ");
            int memberId = int.Parse(Console.ReadLine());

            Console.Write("Enter Book ID: ");
            int bookId = int.Parse(Console.ReadLine());

            Book book = books.FirstOrDefault(b => b.BookId == bookId);

            if (book == null)
            {
                Console.WriteLine("Book not found!");
                return;
            }

            if (book.CopiesAvailable <= 0)
            {
                Console.WriteLine("No copies available!");
                return;
            }

            book.CopiesAvailable--;
            SaveData();

            Console.WriteLine("Book borrowed successfully!");
            Console.WriteLine($"Return Due Date: {DateTime.Now.AddDays(7).ToShortDateString()}");
        }

        
        public void ReturnBook()
        {
            Console.Write("Enter Book ID: ");
            int bookId = int.Parse(Console.ReadLine());

            Book book = books.FirstOrDefault(b => b.BookId == bookId);

            if (book == null)
            {
                Console.WriteLine("Book not found!");
                return;
            }

            book.CopiesAvailable++;
            SaveData();

            Console.WriteLine("Book returned successfully!");
        }
    }
}

