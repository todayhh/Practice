using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practice
{
    public partial class frmPractice2 : Form
    {        

        public frmPractice2()
        {
            InitializeComponent();            
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            //익명형식
            //var People = new Person[] { new Person { Name = "하현" }, null };

            //people에 3가지 종류의 Person 클래스 있음
            IEnumerable<Person> people = new Person[] {
                                new Person { Name = "하현", Address = new Address { Street = "현대3차"} },
                                new Person { Name = "하현1"},
                                null };

            Proess(people);

            //Person per = new Person();
            //per.Name = "철수";
            //per.Address.Street = "사근1길";
            //per.Address.Number = 3;


            var Other = null as Person[];
            textBox1.Text = $"{Other?[0]?.Name ?? "아무개"}";
        }

        private void Proess(IEnumerable<Person> peopleArray)
        {
            string Text = string.Empty;
            foreach (var p in peopleArray)
            {
                Text += $"{p?.Name ?? "이름없음"}은 " +
                                $"{p?.Address?.Street ?? "집없음"}, ";
            }
            textBox1.Text = Text;
            //하현은 현대3차, 
            //하현1은 집없음
            //이름없음은 집없음
        }

        class Person
        {
            public string Name { get; set; }
            public Address Address { get; set; } //Street, Number 사용가능
        }

        class Address
        {
            public string Street { get; set; } = "기본주소";
            public int Number { get; set; }
        }           
    }
}
