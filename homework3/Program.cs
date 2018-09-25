using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework3
{
   abstract class Chart
    {
        public abstract void area();
        public virtual void setdata(double a,double b,double c) { }
    }
    class Triangel : Chart
    {
        double a, b, c;
        public Triangel()
        {
            
            Console.WriteLine("Init a triangel" );
        }
        public override void setdata(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        public override void  area()
        {
          
            double p = 0.5 * (a + b + c);
            double ss = p * (p - a) * (p - b) * (p - c);
            double s = Math.Sqrt(ss);
            Console.WriteLine("The area of this triangel is " + s);
        }
    }
    class Circle:Chart
    {
        double radius;
        public Circle()
        {
            Console.WriteLine("Init a circle");
        }
        public override void setdata(double radius,double b,double c)
        {
            this.radius = radius;
        }
        public override void area()
        {
           
            double s = radius * radius * System.Math.PI;
            Console.WriteLine("The area of this circle is " + s);
        }
    }
    class Square : Chart
    {
        double side;
        public Square()
        {
            Console.WriteLine("Init a square");
        }
        public override void setdata(double side,double b,double c)
        {
            this.side = side;
        }
        public override void area()
        {
            double s = side * side;
            Console.WriteLine("The area of this squrae is " + s);
        }
    }
    class Rectangel : Chart
    {
        double a, b;
        public Rectangel()
        {      
            Console.WriteLine("Init a rectangel");
        }
        public override void setdata(double a, double b,double c)
        {
            this.a = a;
            this.b = b;
        }
        public override void area()
        {
            double s = a * b;
            Console.WriteLine("The area of this rectangel is " + s);
        }
    }
    class Factory
    {

        public static Chart getChart(String type)
        {
            Chart chart = null;
            try
            {
                if (type.Equals("triangel"))
                {
                    chart = new Triangel();
                }
                else if (type.Equals("circle"))
                {
                    chart = new Circle();
                }
                else if (type.Equals("square"))
                {
                    chart = new Square();
                }
                else if(type.Equals("rectangel"))
                {
                    chart = new Rectangel();
                }
            }
            catch
            {
                Console.WriteLine("Error Input!");
            };
            return chart;
        }
    }
    class Text
    {
        public static void Main(string[] args)
        {
            Chart chart;
            chart = Factory.getChart("triangel");
            chart.setdata(3,4,5);
            chart.area();
            chart = Factory.getChart("circle");
            chart.setdata(2,0,0);
            chart.area();
            chart = Factory.getChart("square");
            chart.setdata(3, 0, 0);
            chart.area();
            chart = Factory.getChart("rectangel");
            chart.setdata(4, 5, 0);
            chart.area();
        }
    }
}
