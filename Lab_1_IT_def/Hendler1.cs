using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1_IT_def
{
    class Handler1 // Класс, реагирующий на событие (удаляются/добавляются книги) записью строки в консоли.
    {
        public void Message_delb()
        {
            //для вывода в консольном приложении
            Console.WriteLine("Книги удалены");
        }

        public void Message_addb()
        {
            //для вывода в консольном приложении
            Console.WriteLine("Книги добавлены");
        }

        public void Message_dele()
        {
            //для вывода в консольном приложении
            Console.WriteLine("Сотрудник уволен");
        }

        public void Message_adde()
        {
            //для вывода в консольном приложении
            Console.WriteLine("Сотрудник нанят");
        }
    }
}
