using System.Collections.Generic;
using System.Collections;

namespace Class40
{
    internal class Program
    {
        static void Main()
        {
            int[] ints = new int[95];
            for (int i = 0; i < ints.Length; i++)
            {
                ints[i] = i;
            }
            var result = ints.Top(34);
            Console.WriteLine(String.Join<int>(',', result));
            Console.WriteLine(95*0.34);
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
        public static IEnumerable<TResult> Top<TResult>(this IEnumerable<TSource> source, int percentoflist, Func<TSource, TResult> predicate)
        {
            var _orderedsource = source.OrderByDescending(x => x.Age);
            int _count = source.Count();
            int _index = -1;
            int _elements = _count * percentoflist % 100 != 0 ? _count * percentoflist / 100 + 1 : _count * percentoflist / 100;
            foreach (var element in source)
            {
                _index++;
                if (element.Age < 0 || element.Age > 100)
                    throw new ArgumentException();
                if (_index >_elements)
                    yield return element;
            }
        }
    }
}