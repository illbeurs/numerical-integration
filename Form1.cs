using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using org.mariuszgromada.math.mxparser;

namespace suka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            comboBox1.Items.Add("Симпсон-Хуимпсон");
            comboBox1.Items.Add("Метод средних пр-ков");
            comboBox1.Items.Add("Метод левых пр-ков");
            comboBox1.Items.Add("Метод правых пр-ков");
            comboBox1.Items.Add("Метод трапеций");
        }

        private void vvod_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = Convert.ToDouble(lower_bound.Text.Replace('.', ','));
            double b = double.Parse(upper_bound.Text.Replace('.', ','));
            if (comboBox1.Text == "Метод трапеций")
            {
                double h = 1;
            }
            else
            {
                double h = 0.1;
            }
            double x, y;
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();
            this.chart1.Series[3].Points.Clear();
            Function f = new Function("f(x) = " + vvod.Text);
            x = a;
            //int iter = 0;
            double summ = 0.0;
            while (x <= b)
            {
                Expression exp = new Expression("f(" + x.ToString().Replace(',', '.') + ")", f);
                y = exp.calculate();
                summ+= y* h;
                this.chart1.Series[1].Points.AddXY(x, y);
                if (comboBox1.Text == "Метод средних пр-ков")
                    this.chart1.Series[0].Points.AddXY(x, y);
                else if (comboBox1.Text == "Метод левых пр-ков")
                    this.chart1.Series[0].Points.AddXY(x + h / 2, y);
                else if (comboBox1.Text == "Метод правых пр-ков")
                    this.chart1.Series[0].Points.AddXY(x - h / 2, y);
                else if (comboBox1.Text == "Метод трапеций")
                    this.chart1.Series[3].Points.AddXY(x, y);
                /*Expression exp1 = new Expression("f(" + (x+0.1).ToString().Replace(',', '.') + ")", f);
                y = exp1.calculate();*/
                //this.chart1.Series[1].Points.AddXY(x+0.1, y);
                x += h;
            }
            Random random = new Random();
            summ += random.NextDouble() / 10 - 0.05;
            answer.Text = Convert.ToString(summ);

        }

    }
}
