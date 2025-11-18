using System;

namespace LibraryManagementSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            int choice;

            do
            {
                Console.WriteLine("\n===== LIBRARY MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. List Books");
                Console.WriteLine("3. Search Book");
                Console.WriteLine("4. Add Member");
                Console.WriteLine("5. Borrow Book");
                Console.WriteLine("6. Return Book");
                Console.WriteLine("7. Exit");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: library.AddBook(); break;
                    case 2: library.ListBooks(); break;
                    case 3: library.SearchBook(); break;
                    case 4: library.AddMember(); break;
                    case 5: library.BorrowBook(); break;
                    case 6: library.ReturnBook(); break;
                    case 7: Console.WriteLine("Exiting..."); break;
                    default: Console.WriteLine("Invalid choice"); break;
                }

            } while (choice != 7);
        }
    }
}
