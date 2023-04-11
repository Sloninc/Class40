using System.Collections.Generic;
using System.Collections;

namespace Class40
{
    internal class Program
    {
        static void Main()
        {
            TopIntTest ti = new TopIntTest();
            ti.TopInt(30, 34, 0, 80);

            TopPeopleTest tp = new TopPeopleTest();
            tp.TopPeople(40, 47, 0, 90);
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
            if (source == null) throw new ArgumentNullException("source");
            var _orderedsource = source.OrderByDescending(x => x);
            int _count = source.Count();
            int _index = -1;
            int _elements = _count * percentoflist % 100 != 0 ? _count * percentoflist / 100 + 1 : _count * percentoflist / 100;
            foreach (int element in _orderedsource)
            {
                _index++;
                if (element < 0 || element > 100)
                    throw new ArgumentException("element");
                if (_index < _elements)
                    yield return element;
            }
        }
        public static IEnumerable<TSource> Top<TSource>(this IEnumerable<TSource> source, int percentoflist, Func<TSource, int> selector)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");
            var b = source.GetType().GetProperties().First().PropertyType == typeof(int);
            if (!b) throw new ArgumentException("SourceProperty");
            var _orderedsource = source.OrderByDescending(selector);
            var _sourceelements = _orderedsource.Select(selector).ToList();
            int _count = source.Count();
            int _index = -1;
            int _elements = _count * percentoflist % 100 != 0 ? _count * percentoflist / 100 + 1 : _count * percentoflist / 100;
            foreach (var element in _orderedsource)
            {
                _index++;
                if (_sourceelements[_index] < 0 || _sourceelements[_index] > 100)
                    throw new ArgumentException("OutOfRangeProperty");
                if (_index < _elements)
                    yield return element;
            }

        }
    }

    public class TopIntTest
    {
        public void TopInt(int count, int percent, int min, int max)
        {
            try
            {
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
