using System;
using System.Collections.Generic;

namespace Lab_1_IT_def
{
    class library
    {
        public List<Book> books = new List<Book> { };

        private string filterAuthor;
        private string filterName;
        private int filterYear;
        private int filterCopies;
        private int filtergenreid;
        private bool flag = false;

        public delegate void MethodContainer();
        //Событие OnDel и OnAdd c типом делегата MethodContainer
        public event MethodContainer onDel;
        public event MethodContainer onAdd;

        public List<Book> fnd(string author)
        {
            filterAuthor = author;
            List<Book> res = books.FindAll(PredicateAuthor);
            return res;
        }

        public void del(string author) // удаление книг
        {
            filterAuthor = author;
            books.RemoveAll(PredicateAuthor);
            onDel();
        }

        public void add_book(Book bk) // добавление книги
        {
            filterAuthor = bk.author;
            filterName = bk.name;
            filterYear = bk.year;
            filterCopies = bk.copies;
            filtergenreid = bk.genreid;
            List<Book> res = books.FindAll(PredicateBook);
            foreach (Book b in res)
            {
                flag = true;
                b.copies = filterCopies + b.copies;
            }
            if (!flag)
            {
                books.Add(bk);
                onAdd();
            }
            else
            {
                Console.WriteLine("Книга уже есть в библиотеке. Кол-во экземпляров увеличено.");
            }

        }

        private bool PredicateBook(Book bk)
        {
            if (bk.author == filterAuthor && bk.name == filterName && bk.year == filterYear && bk.genreid == filtergenreid)
                return true;
            else
                return false;
        }

        private bool PredicateAuthor(Book bk)
        {
            if (bk.author == filterAuthor)
                return true;
            else
                return false;
        }
    }
}