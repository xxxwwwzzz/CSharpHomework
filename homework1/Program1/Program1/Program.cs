using System;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "";
            double a,b;
            Console.Write("Please input two number:");
            s = Console.ReadLine();
            a = double.Parse(s);
            s = Console.ReadLine();
            b = double.Parse(s);
            Console.WriteLine("a*b=" + a * b);
        }
    }
}
