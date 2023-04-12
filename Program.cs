using System.Collections.Generic;
using System.Collections;
using System.Reflection;

namespace Class40
{
    internal class Program
    {
        static void Main()
        {
            TopIntTest ti = new TopIntTest();
            ti.TopInt(30, 20, 0, 80);
            Console.WriteLine(new String('=', 80));
            TopPeopleTest tp = new TopPeopleTest();
            tp.TopPeople(40, 47, 0, 100);
            Console.ReadLine();
        }

    }

}
