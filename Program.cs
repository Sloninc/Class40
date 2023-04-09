using System.Collections.Generic;
using System.Collections;

namespace Class40
{
    internal class Program
    {
        static void Main()
        {
            int[] ints = new int[10];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = new Random().Next(0, 100);
            }
            var result = ints.Top(50);

            Person[] people = new Person[10];
            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person() { Age = new Random().Next(90, 110) };
            }   
            var peoples = people.Top(50, x => x.Age);
            Console.WriteLine(String.Join<int>(',', result));
            foreach(var person in peoples)
                Console.Write(person.Age+" ");
            Console.WriteLine();
            Console.ReadLine();
        }
    }
    public class Person
    {
        public int Age { get; set; }
    }
    public static class Topclass
    {
        public static IEnumerable<int> Top(this IEnumerable<int> source, int percentoflist)
        {
            var _orderedsource=source.OrderByDescending(x => x);
            int _count = source.Count();
            int _index = -1;
            int _elements = _count * percentoflist % 100 != 0 ? _count * percentoflist / 100 + 1 : _count * percentoflist / 100;
            foreach (int element in _orderedsource)
            {
                _index++;
                if (element < 0 || element > 100)
                    throw new ArgumentException();  
                if(_index<_elements)
                    yield return element;
            }
        }
        public static IEnumerable<TSource> Top<TSource>(this IEnumerable<TSource> source, int percentoflist, Func<TSource, int> selector)
        {
            var _orderedsource = source.OrderByDescending(selector);
            var _sourceelements = _orderedsource.Select(selector).ToList();
            int _count = source.Count();
            int _index = -1;
            int _elements = _count * percentoflist % 100 != 0 ? _count * percentoflist / 100 + 1 : _count * percentoflist / 100;
            foreach (var element in _orderedsource)
            {
                _index++;
                if (_sourceelements[_index] < 0 || _sourceelements[_index] > 100)
                    throw new ArgumentException();
                if (_index < _elements)
                    yield return element;
            }
        }
    }
}