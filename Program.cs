using System.Collections.Generic;
using System.Collections;
using System.Reflection;

namespace Class40
{
    internal class Program
    {
        static void Main()
        {
            TopIntTest ti = new TopIntTest();         //Класс реализует тестовый вызов метода Top для коллекции элементов int
            ti.TopInt(56, 67, 11, 80);                  
            Console.WriteLine(new String('=', 120));

            TopPeopleTest tp = new TopPeopleTest();   //Класс реализует тестовый вызов метода Top для коллекции элементов Person
            tp.TopPeople(40, 56, -67, 23);
            Console.ReadLine();
        }

    }

}
