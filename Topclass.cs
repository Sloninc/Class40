using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class40
{
    /// <summary>
    /// Класс реализует методы расширения для дженерик коллекций
    /// </summary>
    public static class Topclass
    {
        #region Метод Top принимающий коллекцию элементов int
        /// <summary>
        /// Метод принимает коллекцию элементов типа int и проценты, 
        /// возвращает заданное количество процентов от выборки с округлением количества элементов в большую сторону.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="percentoflist">заданное количество процентов от выборки</param>
        /// <returns>коллекцию элементов int</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<int> Top(this IEnumerable<int> source, int percentoflist)
        {
            if (percentoflist < 0 || percentoflist > 100) //Проверка входного параметра процентов
                throw new ArgumentException("Значение процентов задаются в диапазоне от 0 до 100"); 
            if (source == null) 
                throw new ArgumentNullException("source");
            var _orderedsource = source.OrderByDescending(x => x); //Сортировка элементов коллекции в порядке убывания
            int _count = source.Count();  //Количество элементов коллекции
            if(_orderedsource.First()>100||_orderedsource.Last()<1) //проверка значения элементов коллекции на вхождение в заданный диапазон
                throw new ArgumentException($"Ваше значение: {source}, диапазон значений должен быть от 1 до 100");
            int _index = -1; //счетчик элеметов коллекции
            int _elements = _count * percentoflist % 100 != 0 ? _count * percentoflist / 100 + 1 : _count * percentoflist / 100; //вычисление количества элементов для возврата
            foreach (int element in _orderedsource)
            {
                _index++; 
                if (_index < _elements)
                    yield return element;  
            }
        }
        #endregion

        #region Метод Top принимающий коллекцию элементов Person
        /// <summary>
        /// Метод принимает коллекцию элементов типа Person, проценты и функцию селектора, 
        /// возвращает заданное количество процентов от выборки с округлением количества элементов Person в большую сторону.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="percentoflist">заданное количество процентов от выборки</param>
        /// <param name="selector">функция селектора</param>
        /// <returns>коллекцию элементов Person</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<TSource> Top<TSource>(this IEnumerable<TSource> source, int percentoflist, Func<TSource, int> selector)
        {
            if (percentoflist < 0 || percentoflist > 100) //Проверка входного параметра процентов
                throw new ArgumentException("Значение процентов задаются в диапазоне от 0 до 100"); 
            if (source == null) throw new ArgumentNullException("source");
            if (selector == null) throw new ArgumentNullException("selector");
            try
            {
                var b = typeof(TSource).GetProperties().First().PropertyType == typeof(int); //проверка элементов коллекции - содержат ли они свойство
                if (!b) throw new ArgumentException("Коллекция должна состоять из элементов со свойством типа int");  //проверка элементов коллекции - содержат ли они свойство типа int
            }
            catch (Exception ex)
            {
                if (ex is ArgumentException) Console.WriteLine(ex.Message);
                if (ex is InvalidOperationException) Console.WriteLine("Элементы вашей коллекции не содержат свойств");
            }
            var _orderedsource = source.OrderByDescending(selector);  //Сортировка элементов коллекции в порядке убывания по заданному свойству
            var _sourceelements = _orderedsource.Select(selector).ToList();
            if(_sourceelements.First()>100||_sourceelements.Last()<1)  //проверка значения элементов коллекции на вхождение в заданный диапазон
                throw new ArgumentException($"Значение свойства {source} - вне диапазона от 1 до 100");
            int _count = source.Count();  //Количество элементов коллекции
            int _index = -1;  //счетчик элеметов коллекции
            int _elements = _count * percentoflist % 100 != 0 ? _count * percentoflist / 100 + 1 : _count * percentoflist / 100;  //вычисление количества элементов для возврата
            foreach (var element in _orderedsource)
            {
                _index++;
                if (_index < _elements)
                    yield return element;
            }

        }
    }
    #endregion
}
