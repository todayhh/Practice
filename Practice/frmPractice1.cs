using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class frmPractice1 : Form
    {
        public frmPractice1()
        {
            InitializeComponent();
        }

        int z = 3;
        private void button1_Click(object sender, EventArgs e)
        {
            int x = 1;
            textBox1.Text = Run(x).ToString();
            textBox1.Text = x.ToString();   //1

            int y = 2;
            Run1(ref y);
            textBox1.Text = y.ToString();       //102
            
            Run2();
            textBox1.Text = z.ToString();  //103

            int a;
            textBox1.Text = Run3(out a).ToString();        //5

            SumAll(2, 4, 5);
            SumAll(3, 4, 5, 7);

            Message("안녕", "   하세요");
            Message("졸리다", "피곤하다");

            Age(4);
            textBox1.Text = Age1(3).ToString();

            textBox1.Text = Sum(3).ToString();  //16
            textBox1.Text = Sum(3, 14).ToString();  //17
        }


        #region value 형식, ref, out
        private int Run(int i)
        {
            i += 100;
            return i;   //101
        }

        private void Run1(ref int i)
        {
            i += 100;
            textBox1.Text = i.ToString();       //102
        }

        private void Run2()
        {
            z += 100;
            textBox1.Text = z.ToString();   //103
        }

        private int Run3(out int i)
        {            
            i = 5;
            return i;
        }
        #endregion



        #region params
        private void SumAll(params int[] numbers)
        {
            //int sum = 0;
            //foreach (var item in numbers)
            //{
            //    sum += item;
            //}
            int sum = numbers.Sum();
            textBox1.Text = sum.ToString();
        }

        private void Message(params string[] messgaes)
        {
            textBox1.Text = string.Empty;
            foreach (var item in messgaes)
            {
                textBox1.Text += $"{item} , ";
            }            
        }
        #endregion

        private void Age(int i) => textBox1.Text = (i + 1).ToString();

        private int Age1(int i) => i + 1;

        private int Sum(int x, int y = 13) => x + y;



        Car car = new Car();
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = car.CarName;            
            car.Wheel = "17인치";
            car.WindowNum = 3;
            
            textBox1.Text = car.PassWord;
            //car.PassWord = "오류";

            //textBox1.Text = car.ID; = > 오류
            car.ID = "LHH";
        }     
    }

    class Car
    {
        public string CarName {get; set; } = "하현이차";
        public string Wheel { get; set; }
        public int WindowNum { get; set; }
        public string PassWord { get; private set; } = "읽기";
        public string ID { private get; set; }  //쓰기전용
    }
}
