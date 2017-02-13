namespace _06.BookLibraryModification
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    class BookLibraryModification
    {
        static void Main()
        {
            int booksCount = int.Parse(Console.ReadLine());
            Library authors = new Library();

            for (int i = 0; i < booksCount; i++)
            {
                authors.AddBook(Console.ReadLine().Split(' '));
            }

            DateTime date = DateTime.ParseExact(Console.ReadLine(), "d.MM.yyyy", CultureInfo.InvariantCulture);
            PrintAllBooksAfterDate(authors, date);

            //PrintAuthorsEarning(authors);
        }

        /*
        public static void PrintAuthorsEarning(Library authors)
        {
            var SortedAutors = authors.GetAndSortByAuthorAndPrice();

            foreach (KeyValuePair<string, List<Book>> author in SortedAutors)
                Console.WriteLine($"{author.Key} -> {authors.GetBooksPriceSum(author.Key).ToString("0.00")}");
        }
        */

        public static void PrintAllBooksAfterDate(Library authors, DateTime date)
        {
            var BooksAfterDate = authors.GetBooksAfterDate(date);

            foreach (KeyValuePair<string, DateTime> book in BooksAfterDate)
                Console.WriteLine($"{book.Key} -> {book.Value.ToString("d.MM.yyyy")}");
        }
    }
}
