using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class40
{
    /// <summary>
    /// Тестовый класс для создания тестовой коллекции элементов типа int и вызова метода расширения Top
    /// </summary>
    public class TopIntTest
    {
        /// <summary>
        /// Метод генерирует коллекцию элементов int, вызывает метод Top и выводит результат на консоль
        /// </summary>
        /// <param name="count">задает количество элементов коллекции</param>
        /// <param name="percent">задает количество процентов</param>
        /// <param name="min">задает минимальное значение диапазона</param>
        /// <param name="max">задает максимальное значение диапазона</param>
        public void TopInt(int count, int percent, int min, int max)
        {
            try
            {
                Console.WriteLine("Вывод элементов коллекции типа int");
                if(count<=0) 
                    throw new ArgumentException("количество элементов должно быть больше нуля");
                if (max <= min) 
                    throw new ArgumentException("аргумент max должен быть болше аргумента min");
                int[] ints = new int[count];   //создание коллекции элементов типа int
                for (int i = 0; i < ints.Length; i++) //наполнение коллекции элементов с случайными значениями свойств
                {
                    ints[i] = new Random().Next(min, max);
                }
                var result = ints.Top(percent);     //вызов метода Top
                Console.WriteLine(String.Join<int>(' ', result));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
