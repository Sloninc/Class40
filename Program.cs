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
            Console.ReadLine();
        }
    }
    public static class Topclass
    {
        public static IEnumerable<int> Top(this IEnumerable<int> source, int percentoflist)
        {
            int _count = source.Count();
            int _index = -1;
            int _elements = _count * percentoflist % 100 != 0 ? _count * percentoflist / 100 + 1 : _count * percentoflist / 100;
            foreach (int element in source)
            {
                _index++;
                if (element < 0 || element > 100)
                    throw new ArgumentException();  
                if(_index>=(source.Count()-_elements))
                    yield return element;
            }
        }
    }
}