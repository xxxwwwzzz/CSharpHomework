using Microsoft.VisualStudio.TestTools.UnitTesting;
using program1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void addorderTest()
        {
            int a = 3,b=3;
            OrderService ordall = new OrderService();
            ordall.addorder(a,b);
        }
        [TestMethod()]
        public void addorderTest2()
        {
            OrderService ordall = new OrderService();
            ordall.addorder(1, 4) ;
        }
        [TestMethod()]
        public void addorderTest3()
        {
            OrderService ordall = new OrderService();
            ordall.addorder(0, 3);
        }
        [TestMethod()]
        public void suborderTest()
        {
            OrderService ordall = new OrderService();
            ordall.suborder(2);
        }
        [TestMethod()]
        public void suborderTest2()
        {
            OrderService ordall = new OrderService();
            ordall.suborder(0);
        }

        [TestMethod()]
        public void changeorderTest()
        {
            OrderService ordall = new OrderService();
            ordall.changeorder(2);
        }
        [TestMethod()]
        public void changeorderTest2()
        {
            OrderService ordall = new OrderService();
            ordall.changeorder(0);
        }

        [TestMethod()]
        public void showorderTest()
        {
            OrderService ordall = new OrderService();
            ordall.showorder(2);
        }
        public void showorderTest2()
        {
            OrderService ordall = new OrderService();
            ordall.showorder(0);
        }
        [TestMethod()]
        public void showorderupTest()
        {
            OrderService ordall = new OrderService();
            ordall.showorderup();
        }

        [TestMethod()]
        public void ExportTest()
        {
            OrderService ordall = new OrderService();
            ordall.Export();
        }

        [TestMethod()]
        public void ImportTest()
        {
            OrderService ordall = new OrderService();
            ordall.Import();
        }
    }
}