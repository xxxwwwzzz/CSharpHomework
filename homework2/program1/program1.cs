using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework1
{
    class Program
    {
        static void Main(string[] args)
        {
            String s;
            int n;
            Console.Write("Please input a number:");
            s = Console.ReadLine();
            n = int.Parse(s);
            int i = 2;
            while(i<=n)
            {
                if(n%i==0)
                {
                    Console.Write(i + " ");
                    n /= i;
                    continue;
                }
                i++;
            }
        }
    }
}
