using program1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace databinding
{
    public partial class Form2 : Form
    {
        public Order order;
        public Form2()
        {
            InitializeComponent();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<OrderDetails> od = new List<OrderDetails>();

            string  aa1=null,ab1=null,ac1=null;//商品名称
            String pattern1 = @"^[a-zA-Z0-9]+$";
            Regex rx = new Regex(pattern1);
            Match m1 = rx.Match(textBox2.Text);
            if (m1.Success) aa1 = textBox2.Text;
            Match m2= rx.Match(textBox3.Text);
            if (m2.Success) ab1 = textBox3.Text;
            Match m3= rx.Match(textBox4.Text);
            if (m3.Success) ac1 = textBox4.Text;

            int aa2=0, ab2=0, ac2=0;//商品数量，只能为整数
            String pattern2 = @"^[0-9]+$";
            Regex rx2 = new Regex(pattern2);
            Match mm1 = rx2.Match(textBox5.Text);
            if (mm1.Success) aa2 = int.Parse(textBox5.Text);
            Match mm2 = rx2.Match(textBox6.Text);
            if (mm2.Success) ab2 = int.Parse(textBox6.Text);
            Match mm3 = rx2.Match(textBox7.Text);
            if (mm3.Success) ac2 = int.Parse(textBox7.Text);

            float aa3=0, ab3=0, ac3=0;//商品价格，只能为小数
            String pattern3 = @"^[0-9]+.[0-9]+$";
            Regex rx3 = new Regex(pattern3);
            Match mmm1 = rx3.Match(textBox8.Text);
            if (mmm1.Success) aa3 = float.Parse(textBox8.Text);
            Match mmm2 = rx3.Match(textBox9.Text);
            if (mmm2.Success) ab3 = float.Parse(textBox9.Text);
            Match mmm3 = rx3.Match(textBox10.Text);
            if (mmm3.Success) ac3 = float.Parse(textBox10.Text);

            //int aa2 = int.Parse(textBox5.Text);
            //float aa3 = float.Parse(textBox8.Text);
            //string ab1 = textBox3.Text;
            //int ab2 = int.Parse(textBox6.Text);
            //float ab3 = float.Parse(textBox9.Text);
            //string ac1 = textBox4.Text;
            //int ac2 = int.Parse(textBox7.Text);
            //float ac3 = float.Parse(textBox10.Text);
            OrderDetails a1 = new OrderDetails(aa1, aa2, aa3);
            OrderDetails a2 = new OrderDetails(ab1, ab2, ab3);
            OrderDetails a3 = new OrderDetails(ac1, ac2, ac3);
            od.Add(a1);
            od.Add(a2);
            od.Add(a3);

            int numm = 0;//= int.Parse();//订单号，只能为“年月日+三位流水号”的形式，不能为空格
            String pattern4 = @"^\d{2}\d{1,2}\d{1,2}\d{3}$";
            Regex rx4 = new Regex(pattern4);
            Match nummatch = rx4.Match(textBox11.Text);
            if (nummatch.Success) numm = int.Parse(textBox11.Text);

            string nammme = null;//客户名称
            Match nammatch = rx.Match(textBox1.Text);
            if (nammatch.Success) nammme = textBox1.Text;
            //string nammme = textBox1.Text;
            order = new Order(numm, nammme, od);

            this.Close();
        }
    }
}
