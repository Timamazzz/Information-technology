using System;

namespace Lab_1_IT_def
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book("Война и мир", 1, "Л.Н. Толстой", 1869, 1);
            Book b2 = new Book();
            Book b3 = new Book("1984", 6, "Джордж Оруэлл ", 1949, 1);
            Book b4 = new Book("1984", 6, "Джордж Оруэлл ", 1949, 1);

            library bibl1 = new library(); // создание новой библиотеки

            Handler1 h1 = new Handler1();
            bibl1.onDel += h1.Message_delb;
            bibl1.onAdd += h1.Message_addb;

            //добавление книг в коллекцию библиотеки
            bibl1.add_book(b1);
            bibl1.add_book(b2);
            bibl1.add_book(b3);
            bibl1.add_book(b4);

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


            Employee e1 = new Employee();
            Employee e2 = new Employee("Галкин", "Артем", "Директор", 10000);
            Employee e3 = new Employee("Уланский", "Никита", "Продавец-кассир", 100);

            Group gr1 = new Group();
            gr1.onDel += h1.Message_dele;
            gr1.onAdd += h1.Message_adde;

            gr1.add_employee(e1);
            gr1.add_employee(e2);
            gr1.add_employee(e3);

            Console.WriteLine("\t\t");
            foreach (Employee e in gr1.employees)
            {
                e.GetInformation();
            }
            Console.WriteLine("\t\t");

            gr1.del("Уланский", "Никита");
            Console.WriteLine("\t\t");

            foreach (Employee e in gr1.employees)
            {
                e.GetInformation();
            }
            Console.WriteLine("\t\t");
        }
    }
}
