using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework4
{
    public delegate void AlertHandler(object sender, ClickEventArgs args);
    public class ClickEventArgs : EventArgs
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public string M { get; set; }
    }
    public class TimeAlert
    {
        public event AlertHandler OnClick;
        public void Click(int x, int y, int z,string m)
        {
            ClickEventArgs args = new ClickEventArgs();
            args.X = x;
            args.Y = y;
            args.Z = z;
            args.M = m;
            OnClick(this, args);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            TimeAlert btn = new TimeAlert();
            btn.OnClick += new AlertHandler(btn_OnClick);
            Console.WriteLine("当前系统时间是：{0}", DateTime.Now);
            Console.WriteLine("设置小时：");
            string s1 = Console.ReadLine();
            int hour = int.Parse(s1);
            Console.WriteLine("设置分钟：");
            string s2 = Console.ReadLine();
            int minute = int.Parse(s2);
            Console.WriteLine("设置秒：");
            string s3 = Console.ReadLine();
            int second = int.Parse(s3);
            Console.WriteLine("信息：");
            string message = Console.ReadLine();
            btn.Click(hour, minute,second,message);
        }
        static void btn_OnClick(object sender, ClickEventArgs args)
        {
            if (DateTime.Now.Hour ==args.X  && DateTime.Now.Minute== args.Y && DateTime.Now.Second == args.Z)
            {
                Console.WriteLine("闹钟响啦:" + args.M);
            }
        }
    }
}
