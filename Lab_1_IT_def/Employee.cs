using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1_IT_def
{
    class Employee
    {
        public string name;
        public string surname;
        public string position;
        public int salary;


        public Employee()
        {
            name = "Иван";
            surname = "Иванов";
            position = "Продавец-кассир";
            salary = 1;

        }

        public Employee(string _name, string _surname, string _position, int _salary)
        {
            name = _name;
            surname =_surname;
            position = _position;
            salary = _salary;

        }

        public void GetInformation()
        {
            Console.WriteLine($"Имя: {name} |  Фамилия: {surname}|  Должность: {position} |  З/п: {salary}$");
        }
    }
}
