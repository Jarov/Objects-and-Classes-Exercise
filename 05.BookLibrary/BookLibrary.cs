﻿namespace _05.BookLibrary
{
    using System;
    using System.Collections.Generic;

    class BookLibrary
    {
        static void Main()
        {
            int booksCount = int.Parse(Console.ReadLine());
            Library authors = new Library();

            for (int i = 0; i < booksCount; i++)
            {
                authors.AddBook(Console.ReadLine().Split(' '));
            }

            PrintAuthorsEarning(authors);
        }
        
        public static void PrintAuthorsEarning(Library authors)
        {
            var SortedAutors = authors.GetAndSortByAuthorAndPrice();

            foreach (KeyValuePair<string, List<Book>> author in SortedAutors)
                Console.WriteLine($"{author.Key} -> {authors.GetBooksPriceSum(author.Key).ToString("0.00")}");
        }
    }
}
