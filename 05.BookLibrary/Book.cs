namespace _05.BookLibrary
{
    using System;

    class Book
    {
        public string Name, Publisher, ISBN;
        public DateTime ReleaseDate;
        public double Price;

        public Book(string name, string publisher, DateTime releaseDate, string isbn, double price)
        {
            Name = name;
            Publisher = publisher;
            ReleaseDate = releaseDate;
            ISBN = isbn;
            Price = price;
        }
    }
}
