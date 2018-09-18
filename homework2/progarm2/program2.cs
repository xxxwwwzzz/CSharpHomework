using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace progarm2
{
    class program2
    {
        static void Main(string[] args)
        {
            double aver;
            int[] a = new int[7] { 34, 5, 78, 87, 3, 4, 9 };
            int min=a[0], max=a[0], s=0, i;
            
            for( i=0;i<a.Length;i++)
            {
                if (min > a[i])
                    min = a[i];
                if (max < a[i])
                    max = a[i];
                s += a[i];
            }
            aver = s / a.Length;
            Console.WriteLine("The max is:" + max);
            Console.WriteLine("The min is:" + min);
            Console.WriteLine("The sum is:" + s);
            Console.WriteLine("The average is:" + aver);
        }
    }
}
