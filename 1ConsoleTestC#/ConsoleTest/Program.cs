using System;
using System.Collections.Generic;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        { 
            var names = new List<String> { "AAAA" , "DDDD" , "HHHH" , "cCCC" , "BBBB"};
            names.Add("my name is hamid.");
            names.Add(2.ToString());
            //names.RemoveAt(2);
            names.Sort();
            foreach (String name in names)
            {
                Console.WriteLine($"Hello {name}");
            }
            Console.WriteLine(names.ToString());

        }
    }
}
