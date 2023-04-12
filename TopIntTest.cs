using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class40
{
    public class TopIntTest
    {
        public void TopInt(int count, int percent, int min, int max)
        {
            try
            {
                Console.WriteLine("Вывод элементов коллекции типа int");
                int[] _ints = new int[count];
                for (int i = 0; i < _ints.Length; i++)
                {
                    _ints[i] = new Random().Next(min, max);
                }
                var result = _ints.Top(percent);
                Console.WriteLine(String.Join<int>(',', result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
    public class TopPeopleTest
    {
        public void TopPeople(int count, int percent, int min, int max)
        {
            try
            {
                Console.WriteLine("Вывод элементов коллекции типа Person");
                Person[] people = new Person[count];
                for (int i = 0; i < people.Length; i++)
                {
                    people[i] = new Person() { Age = new Random().Next(min, max) };
                }
                var peoples = people.Top(percent, x => x.Age);

                foreach (var person in peoples)
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
