using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class40
{
    public static class Topclass
    {
        public static IEnumerable<int> Top(this IEnumerable<int> source, int percentoflist)
        {
            if (percentoflist < 0 || percentoflist > 100) throw new ArgumentException("Значение процентов задаются в диапазоне от 0 до 100");
            if (source == null) throw new ArgumentNullException("source");
            var _orderedsource = source.OrderByDescending(x => x);
            int _count = source.Count();
            int _index = -1;
            int _elements = _count * percentoflist % 100 != 0 ? _count * percentoflist / 100 + 1 : _count * percentoflist / 100;
            foreach (int element in _orderedsource)
            {
                _index++;
                if (element < 0 || element > 100)
                    throw new ArgumentException($"Ваше значение: {element}, диапазон значений должен быть от 0 до 100");
                if (_index < _elements)
                    yield return element;
            }
        }
        public static IEnumerable<TSource> Top<TSource>(this IEnumerable<TSource> source, int percentoflist, Func<TSource, int> selector)
        {
            if (percentoflist < 0 || percentoflist > 100) throw new ArgumentException("Значение процентов задаются в диапазоне от 0 до 100");
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");
            try
            {
                var b = typeof(TSource).GetProperties().First().PropertyType == typeof(int);
                if (!b) throw new ArgumentException("Коллекция должна состоять из элементов со свойством типа int");
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException) Console.WriteLine(ex.Message);
                if (ex is InvalidOperationException) Console.WriteLine("Элементы вашей коллекции не содержат свойств");
            }

            var _orderedsource = source.OrderByDescending(selector);
            var _sourceelements = _orderedsource.Select(selector).ToList();
            int _count = source.Count();
            int _index = -1;
            int _elements = _count * percentoflist % 100 != 0 ? _count * percentoflist / 100 + 1 : _count * percentoflist / 100;
            foreach (var element in _orderedsource)
            {
                _index++;
                if (_sourceelements[_index] < 0 || _sourceelements[_index] > 100)
                    throw new ArgumentException($"Значение свойства {_sourceelements[_index]} - вне диапазона от 0 до 100");
                if (_index < _elements)
                    yield return element;
            }

        }
    }
}
