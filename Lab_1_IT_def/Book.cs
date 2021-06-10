using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1_IT_def
{
    class Book
    {
        public string name;
        public string author;
        public int year;
        public int copies;
        public int genreid;

        string[] genre = {"Сказка", "Художественная литература", "Научная литература", "Фентези", "Триллер", "История", "Фантастика"};

        public Book(string name, int genreid, string author, int year, int copies )
        {
            this.name = name;
            this.author = author;
            this.year = year;
            this.copies = copies;
            this.genreid = genreid;
        }

        public Book()
        {
            name = "Евгений Онегин";
            author = "А.С. Пушкин";
            year = 1833;
            copies = 1;
            genreid = 1;
            
        }

        public void GetInformation()
        {
            Console.WriteLine($"Книга: {name} |  Жанр: {genre[genreid]}|  Автор: {author} |  Год издания: {year} | Экземпляров: {copies}" );
        }

    }
}
