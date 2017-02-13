namespace _06.BookLibraryModification
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    class Library
    {
        public Dictionary<string, List<Book>> Authors = new Dictionary<string, List<Book>>();

        public Library()
        {

        }

        public void AddBook(string[] inPut)
        {
            if (!Authors.ContainsKey(inPut[1]))
                Authors[inPut[1]] = new List<Book>();

            Authors[inPut[1]].Add(new Book(inPut[0], inPut[2], DateTime.ParseExact(inPut[3], "d.MM.yyyy", CultureInfo.InvariantCulture), inPut[4], double.Parse(inPut[5])));
        }

        public double GetBooksPriceSum(string author)
        {
            return Authors[author].Sum(x => x.Price);
        }

        public IOrderedEnumerable<KeyValuePair<string, List<Book>>> GetAndSortByAuthorAndPrice()
        {
            return Authors.OrderByDescending(x => x.Value.Sum(y => y.Price)).ThenBy(x => x.Key);
        }

        public IOrderedEnumerable<KeyValuePair<string, DateTime>> GetBooksAfterDate(DateTime date)
        {
            Dictionary<string, DateTime> booksAfterDate = new Dictionary<string, DateTime>();

            foreach (List<Book> books in Authors.Values)
                foreach (Book book in books)
                    if (book.ReleaseDate > date)
                        booksAfterDate.Add(book.Name, book.ReleaseDate);

            return booksAfterDate.OrderBy(x => x.Value.Date).ThenBy(x => x.Key);
        }
    }
}
