using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_1_IT_def
{
    class Group
    {
        public List<Employee> employees = new List<Employee> { };

        private string filtername;
        private string filtersurname;
        private string filterposition;
        private int filtersalary;
        private bool flag = false;

        public delegate void MethodContainer();
        //Событие OnDel и OnAdd c типом делегата MethodContainer
        public event MethodContainer onDel;
        public event MethodContainer onAdd;

        public List<Employee> fnd(string name, string surname)
        {
            filtername = name;
            filtersurname = surname;
            List<Employee> res = employees.FindAll(PredicateName);
            return res;
        }

        public void del(string name, string surname) // удаление книг
        {
            filtername = name;
            filtersurname = surname;
            employees.RemoveAll(PredicateName);
            onDel();
        }

        public void add_employee(Employee emp) // добавление книги
        {
            filtername = emp.name;
            filtersurname = emp.surname;
            filterposition = emp.position;
            filtersalary = emp.salary;

            List<Employee> res = employees.FindAll(PredicateName);

            foreach (Employee e in res)
            {
                flag = true;
                
            }

            if (!flag)
            {
                employees.Add(emp);
                onAdd();
            }
            else
            {
                Console.WriteLine("Сотрудник уже нанят");
            }

        }

        private bool PredicateName(Employee emp)
        {
            if (emp.name == filtername && emp.surname == filtersurname && emp.position == filterposition && emp.salary == filtersalary)
                return true;
            else
                return false;
        }
    }
}
