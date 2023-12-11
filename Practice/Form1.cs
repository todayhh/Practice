using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            //textBox1.Text = Class1.Hi().ToString();
            //Environment.Exit(0);            

            //Process.Start("\"C:\\Program Files (x86)\\Kakao\\KakaoTalk\\KakaoTalk.exe\"");
            //Process.Start("https://www.kfhi.or.kr/mypage/translation");

            //DisplayRotto();
            //textBox1.Text = RockSiserPaper();

            //object x = "하이";
            ////if (x is string)
            ////    textBox1.Text = "True";
            //string s = x as string;
            //textBox1.Text = s;

            string x = "hi";
            string y = "HI";            
            textBox1.Text = (x.CompareTo(y) == -1) ? "True" : "False";
            //if(x.Equals(y, StringComparison.OrdinalIgnoreCase))
            //    textBox1.Text = x.ToUpper();
        }

        private string RockSiserPaper()
        {
            string[] choice = { "가위", "바위", "보" };
            //가위 - 1, 바위 -2 , 보 -3
            Random random = new Random();            

            int x1 = Array.IndexOf(choice, "가위");
            int x2 = Array.IndexOf(choice, "바위");
            int x3 = Array.IndexOf(choice, "보");

            int result = random.Next(1, 4);
            string x = string.Empty;           
            if (result == x1 || result == x2 || result == x3)
                x = "비김";
            
            return x;
        }

        private void DisplayRotto()
        {
            Random random = new Random();
            int[] number = new int[6];
            int temp = 0;
            for (int i = 0; i < 6; i++)
            {                
                temp = random.Next(10) + 1; // 0~9 + 1               
                for (int j = 0; j <= i; j++)
                {
                    if (number[j] == temp)
                    {
                        --i;
                        break;
                    }                        
                    else
                    {
                        if( i == j)
                            number[i] = temp;
                    }                        
                }                                
            }

            string x = "";
            foreach (var item in number)
            {
                x += $"{item}, ";
            }
            textBox1.Text = x;
        }


        public class Class1
        {
            public static int Hi()
            {
                return 3;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string s = "안녕,하세,요";
            //string[] x = s.Split(',');
            //foreach (var item in x)
            //{
            //    textBox1.Text +=  $"{item}\r\n";
            //}

            //string x = "안녕하세요";
            //string y = x.Substring(0, 2) + "하이루" + x.Substring(2, 3);
            //textBox1.Text = x.Insert(2, "하이루");
            //textBox1.Text = y;

            //StringBuilder builder = new StringBuilder();
            //builder.Append("1\r\n");
            //builder.Append("2\r\n");
            //builder.Append("3\r\n");
            //textBox1.Text = builder.ToString();

            //DateTime start = DateTime.Now;
            //string msg = string.Empty;
            //for (int i = 0; i < 10000; i++)
            //{
            //    msg += "안녕하세요";
            //}
            //DateTime End = DateTime.Now;
            //textBox1.Text = (End - start).TotalMilliseconds.ToString();

            //DateTime start = DateTime.Now;
            //StringBuilder msg2 = new StringBuilder();
            //for (int i = 0; i < 10000; i++)
            //{
            //    msg2.Append("안녕하세요");
            //}
            //DateTime End = DateTime.Now;
            //textBox1.Text = (End - start).TotalMilliseconds.ToString();

            string[] arr = { "10", "20", "30" };
            int[] a = Array.ConvertAll(arr, int.Parse);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stack stack = new Stack();
            stack.Push(1234);
            int x = Convert.ToInt32(stack.Pop());

            Stack<int> stack1 = new Stack<int>();
            stack1.Push(1234);
            int y = stack1.Pop();

            var arr = Enumerable.Range(1, 100).Where(i => i % 2 == 0).Take(10);

            int[] number = { 1, 2, 3 };
            Double sum = number.Average();

            IEnumerable<int> s2 = number.Where(i => i < 2);
            List<int> s1 = number.Where(i => i < 2).ToList();
            var s3 = number.Where(i => i % 2 == 0);

            bool[] b1 = { true, false, true };
            var r1 = b1.Any(w => w == true);

            int[] b2 = { 1, 2, 2, 2 };
            var r2 = b2.Any(s => s % 2 == 1);
            int r3 = b2.Distinct().Sum();

            List<string> list = new List<string>{ "apple", "cat", "dog" };
            var result = list.Where(s => s.Contains("a"));

            int[] nums = { 1, 2, 4, 5, 6 };
            var num2 = nums.Select(i => i * i);
            var num3 = num2.Sum();

            var lists = new List<string> { "하이", "헬로" };
            lists.ForEach(s => textBox1.Text += s.ToString());

        }
    }
}
