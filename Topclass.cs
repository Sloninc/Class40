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
            if (percentoflist is < 0 or > 100) //Проверка входного параметра процентов
                throw new ArgumentException("Значение процентов задаются в диапазоне от 0 до 100"); 
            if (source == null) 
                throw new ArgumentNullException("source");
            var orderedSource = source.OrderByDescending(x => x); //Сортировка элементов коллекции в порядке убывания
            int count = source.Count();  //Количество элементов коллекции
            int index = -1; //счетчик элеметов коллекции
            int elements = count * percentoflist % 100 != 0 ? count * percentoflist / 100 + 1 : count * percentoflist / 100; //вычисление количества элементов для возврата
            foreach (int element in orderedSource)
            {
                index++; 
                if (index < elements)
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
            if (percentoflist is < 0 or > 100) //Проверка входного параметра процентов
                throw new ArgumentException("Значение процентов задаются в диапазоне от 0 до 100"); 
            if (source == null) 
                throw new ArgumentNullException("source");
            if (selector == null) 
                throw new ArgumentNullException("selector");
            var orderedSource = source.OrderByDescending(selector);  //Сортировка элементов коллекции в порядке убывания по заданному свойству
            var sourceElements = orderedSource.Select(selector).ToList();
            int count = source.Count();  //Количество элементов коллекции
            int index = -1;  //счетчик элеметов коллекции
            int elements = count * percentoflist % 100 != 0 ? count * percentoflist / 100 + 1 : count * percentoflist / 100;  //вычисление количества элементов для возврата
            foreach (var element in orderedSource)
            {
                index++;
                if (index < elements)
                    yield return element;
            }

        }
    }
    #endregion
}
