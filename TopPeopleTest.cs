using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class40
{
    /// <summary>
    /// Тестовый класс для создания тестовой коллекции элементов типа Person и вызова метода расширения Top
    /// </summary>
    public class TopPeopleTest
    {
        /// <summary>
        /// Метод генерирует коллекцию элементов тип Person, вызывает метод Top и выводит результат на консоль
        /// </summary>
        /// <param name="count">задает количество элементов коллекции</param>
        /// <param name="percent">задает количество процентов</param>
        /// <param name="min">задает минимальное значение диапазона для сойства Person</param>
        /// <param name="max">задает максимальное значение диапазона для сойства Person</param>
        public void TopPeople(int count, int percent, int min, int max)
        {
            try
            {
                Console.WriteLine("Вывод элементов коллекции типа Person");
                if (count <= 0) throw new ArgumentException("количество элементов должно быть больше нуля");
                if (max <= min) throw new ArgumentException("аргумент max должен быть болше аргумента min");
                Person[] people = new Person[count];     //создание коллекции элементов типа Person
                for (int i = 0; i < people.Length; i++)  //наполнение коллекции элементов с случайными значениями свойств
                {
                    people[i] = new Person() { Age = new Random().Next(min, max) };
                }
                var peoples = people.Top(percent, x => x.Age);  //вызов метода Top

                foreach (var person in peoples)         //вызов метода Top
                    Console.Write(person.Age + " ");
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
