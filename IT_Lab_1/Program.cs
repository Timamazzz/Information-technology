using System;
using System.Collections.Generic;


class library
{
    public List<Book> books = new List<Book> { };
    private string filterAuthor;
    private string filterName;
    private int filterYear;
    private int filterCopies;
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

        flag = false;

    }

    private bool PredicateBook(Book bk)
    {
        if (bk.author == filterAuthor && bk.name == filterName && bk.year == filterYear)
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

class Handler1 // Класс, реагирующий на событие (удаляются/добавляются книги) записью строки в консоли.
{
    public void Message()
    {
        //для вывода в консольном приложении
        Console.WriteLine("Книги удалены");
    }

    public void Message_add()
    {
        //для вывода в консольном приложении
        Console.WriteLine("Книги добавлены");
    }
}

class Book
{
    public string name;
    public string author;
    public int year;
    public int copies;

    public Book(string name, string author, int year, int copies)
    {
        this.name = name;
        this.author = author;
        this.year = year;
        this.copies = copies;
    }

    public Book()
    {
        name = "Евгений Онегин";
        author = "А.С. Пушкин";
        year = 1833;
        copies = 1;
    }

    public void GetInformation()
    {
        Console.WriteLine("Книга: '{0}' |  Автор: {1} |  Год издания: {2} | Экземпляров: {3}", name, author, year, copies);
    }

}

class Program
{
    static void Main(string[] args)
    {
        Book b1 = new Book("Война и мир", "Л.Н. Толстой", 1869, 1);
        Book b2 = new Book();
        Book b3 = new Book("1984", "Джордж Оруэлл ", 1949, 1);
        Book b4 = new Book("1984", "Джордж Оруэлл ", 1949, 1);
        Book b5 = new Book("1984", "Джордж Оруэлл ", 1949, 1);
   

        library bibl1 = new library(); // создание новой библиотеки

        Handler1 h1 = new Handler1();
        bibl1.onDel += h1.Message;
        bibl1.onAdd += h1.Message_add;

        //добавление книг в коллекцию библиотеки
        bibl1.add_book(b1);
        bibl1.add_book(b2);
        bibl1.add_book(b3);
        bibl1.add_book(b4);
        bibl1.add_book(b5);
   




        Console.WriteLine("\t\t");
        foreach (Book b in bibl1.books)
        {
            b.GetInformation();
        }
        Console.WriteLine("\t\t");

        bibl1.del("Л.Н. Толстой"); // удаление книг

        Console.WriteLine("\t\t");
        foreach (Book b in bibl1.books)
        {
            b.GetInformation();
        }
    }
}
