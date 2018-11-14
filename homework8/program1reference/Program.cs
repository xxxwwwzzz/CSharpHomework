using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace program1
{
    public class Program
    {
        static int ornum = 0;
        static void Main(string[] args)
        {

            int ans = 1;
            string ans2;

            Console.WriteLine("开始填写订单");
            OrderService ordall = new OrderService();
            while (ans != 4)
            {
                ornum += 1;
                ordall.addorder(ornum, ans);
                try  
                {
                    Console.WriteLine("若开始下一个订单填写输入3，若结束本次填写输入4：");
                    ans = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e0)
                {
                    Console.WriteLine("您的输入存在格式问题：{0}", e0);
                }

            }
            Console.WriteLine("完成增删查改功能请单独输入相应功能字\"增\"\"删\"\"查\"\"改\"");
            ans2 = Console.ReadLine();
            switch (ans2)
            {
                case "增":
                    ordall.addorder(ornum, ans);
                    break;
                case "删":
                    Console.WriteLine("请输入要删除的订单号，不知道请先查询");
                    int x = Convert.ToInt32(Console.ReadLine());
                    ordall.suborder(x);
                    break;
                case "查":
                    Console.WriteLine("按照订单号查询请输入1，按照客户名称查询请输入2，按照商品名称查询请输入3：");
                    int d = Convert.ToInt32(Console.ReadLine());
                    ordall.showorder(d);
                    break;
                case "改":
                    Console.WriteLine("请输入要修改的订单号，不知道请先查询");
                    int c = Convert.ToInt32(Console.ReadLine());
                    ordall.changeorder(c);
                    break;
                default:
                    Console.WriteLine("您输入了错误信息！");
                    break;
            }
            Console.WriteLine("查询到订单金额大于一万元的订单：");
            ordall.showorderup();
            ordall.Export();
            ordall.Import();
          }

    }
    [Serializable]
   public  class Order
    {
        public int ordernum { get; set; }
        public string customename { get; set; }
        public List<OrderDetails> detaillist { get; set; }
        public float totalmoney { get; set; }
        public Order() { }
        public Order(int a, string b, List<OrderDetails> list)
        {
            ordernum = a;
            customename = b;
            detaillist = list;
            foreach (OrderDetails x in list)
            {
                float c = x.goodsprice;
                int d = x.goodsnum;
                totalmoney += c * d;
            }
        }
    }
    [Serializable]
    public class OrderDetails
    {
        public string goodsname { get; set; }
        public int goodsnum { get; set; }
        public float goodsprice { get; set; }
        public OrderDetails() { }
        public OrderDetails(string goname, int gonum, float goprice)
        {
            goodsname = goname;
            goodsnum = gonum;
            goodsprice = goprice;
        }
    }
    
   public class OrderService
    {
        private List<Order> orderlist = new List<Order>();

        //增
        public void addorder(int aaaa, int ans)
        {
            Console.WriteLine("订单号:" + aaaa);
            int aaa = aaaa;
            Console.WriteLine("客户姓名：");
            string bbb = Console.ReadLine();
            List<OrderDetails> ccc = new List<OrderDetails>();
            while (ans != 2)
            {
                Console.WriteLine("商品名称：");
                string aa = Console.ReadLine();
                try
                {
                    Console.WriteLine("商品数量：");
                    int bb = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("商品价格：");
                    float cc = Convert.ToSingle(Console.ReadLine());
                    OrderDetails ord = new OrderDetails(aa, bb, cc);
                    ccc.Add(ord);
                    Console.WriteLine("若开始下一个商品输入1，若结束该订单填写输入2：");
                    ans = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e1)
                {
                    Console.WriteLine("您的输入存在格式问题：{0}", e1);
                }
            }
            Order ord1 = new Order(aaa, bbb, ccc);
            orderlist.Add(ord1);
        }
        //删
        public void suborder(int x)
        {
                orderlist.RemoveAt(x - 1);
        }
        //改
        public void changeorder(int x)
        {

                int ans = 1;
                
                var query = orderlist
                            .Where(s => s.ordernum == x);
                Console.WriteLine("待修改订单：");
                foreach (var y in query)
                {
                    Console.WriteLine($"{y.ordernum}\t{y.customename}");
                    foreach (var z in y.detaillist)
                    {
                        Console.WriteLine($"{z.goodsname}");
                        Console.WriteLine($"{z.goodsnum}");
                        Console.WriteLine($"{z.goodsprice}");
                    }
                }
                Console.WriteLine("请填写修改后订单：");
                orderlist.RemoveAt(x - 1);
                Console.WriteLine("订单号:" + x);
                Console.WriteLine("客户姓名：");
                string bbb = Console.ReadLine();
                List<OrderDetails> ccc = new List<OrderDetails>();
                while (ans != 2)
                {
                    Console.WriteLine("商品名称：");
                    string aa = Console.ReadLine();
                    Console.WriteLine("商品数量：");
                    int bb = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("商品价格：");
                    float cc = Convert.ToSingle(Console.ReadLine());
                    OrderDetails ord = new OrderDetails(aa, bb, cc);
                    ccc.Add(ord);
                    Console.WriteLine("若开始下一个商品输入1，若结束该订单填写输入2：");
                    ans = Convert.ToInt32(Console.ReadLine());
                }
                Order ord1 = new Order(x, bbb, ccc);
                orderlist.Insert(x - 1, ord1);
            
        }
        //查
        public void showorder(int d)
        {
                switch (d)
                {
                    case 1:
                        {
                            Console.WriteLine("请输入订单号：");
                            int x = Convert.ToInt32(Console.ReadLine());

                            var query3 = orderlist
                                .Where(s => s.ordernum == x);
                            foreach (var y in query3)
                            {
                                Console.WriteLine($"{y.ordernum}\t{y.customename}");
                                foreach (var z in y.detaillist)
                                {
                                    Console.Write($"{z.goodsname}\t");
                                    Console.Write($"{z.goodsnum}\t");
                                    Console.WriteLine($"{z.goodsprice}\t");
                                }
                            }

                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("请输入客户名称：");
                            string x = Console.ReadLine();

                            var query3 = orderlist
                                .Where(s => s.customename == x);
                            foreach (var y in query3)
                            {
                                Console.WriteLine($"{y.ordernum}\t{y.customename}");
                                foreach (var z in y.detaillist)
                                {
                                    Console.Write($"{z.goodsname}\t");
                                    Console.Write($"{z.goodsnum}\t");
                                    Console.WriteLine($"{z.goodsprice}\t");
                                }
                            }

                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("请输入商品名称：");
                            string x = Console.ReadLine();
                            foreach (Order t in orderlist)
                            {
                                var query3 = (t.detaillist)
                                .Where(s => s.goodsname == x);
                                Console.WriteLine($"{t.ordernum}\t{t.customename}");
                                foreach (var z in query3)
                                {
                                    Console.Write($"{z.goodsname}\t");
                                    Console.Write($"{z.goodsnum}\t");
                                    Console.WriteLine($"{z.goodsprice}\t");
                                }
                            }

                        }
                        break;
                    default:
                        Console.WriteLine("您输入了错误信息！");
                        break;

                };
        }
            
        //查询订单大于一万元的
       public void showorderup()
        {
            var query3 = orderlist
                                .Where(s => s.totalmoney > 10000);
            foreach (var y in query3)
            {
                Console.WriteLine($"{y.ordernum}\t{y.customename}");
                foreach (var z in y.detaillist)
                {
                    Console.Write($"{z.goodsname}\t");
                    Console.Write($"{z.goodsnum}\t");
                    Console.WriteLine($"{z.goodsprice}\t");
                }
                Console.WriteLine($"{y.totalmoney}");
            }
        }
        public void Export()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("x.xml", FileMode.Create))
            {
                xml.Serialize(fs, orderlist);
            }
            Console.WriteLine(File.ReadAllText("x.xml"));
        }
        public void Import()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream fs = new FileStream("x.xml", FileMode.Open))
            {
                List<Order> orderlist = (List<Order>)xml.Deserialize(fs);
                foreach (Order a in orderlist)
                {
                    Console.WriteLine(a);
                }
            }
        }
        
    }
}

