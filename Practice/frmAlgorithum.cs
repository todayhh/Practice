using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Windows.Forms;

namespace Practice
{
    public partial class frmAlgorithum : Form
    {
        public frmAlgorithum()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] number1 = { 1, 3, 40, 10, 23, 32 };

            //textBox1.Text = SumMethod(number1).ToString();
            //textBox1.Text = CountMethod(number1).ToString();]
            //MaxMethod1(number1);
            //NearMethod();
            //SearchMethod();
            //MergeLinq();
            //MergeMethod1();
            MergeMethod2();
        }

        #region merge
        private void MergeMethod()
        {
            //merge1 과 merge2 는 이미 정렬된 상태
            int[] merge1 = { 1, 3, 4 }; 
            int[] merge2 = { 2, 6, 7 };
            int m1 = merge1.Length;     //3
            int m2 = merge2.Length;     //3
            int[] merge = new int[m1 + m2];

            int a = 0; int b = 0; int c = 0;
            //오름차순으로 저장하기
            while (a < m1 && b < m2)    //merge1 먼저 저장 끝나버림
            {
                if (merge1[a] <= merge2[b])
                    merge[c++] = merge1[a++];
                else
                    merge[c++] = merge2[b++];
            }
            //1 <= 2 => {1}, a=1, b=0, c=1
            //3 > 2 => {1,2}, a=1, b=1, c=2
            //3 <= 6 => {1,2,3}, a=2, b=1, c=3
            //4 <= 6 => {1,2,3,4}, a=3, b=1, c=4
            while (a < m1)      //merge1은 이미 저장 끝났으므로 안탐
            {
                merge[c++] = merge1[a++];
            }   
            while ( b < m2)     
            {
                merge[c++] = merge2[b++];
            }
            //{1, 2, 3, 4, 6}, a=3, b=2, c=5
            //{1, 2, 3, 4, 6, 7}, a=3, b=3, c=6
        }

        private void MergeMethod1()
        {
            int[] merge1 = { 1, 3, 4 };
            int[] merge2 = { 2, 6, 7 };
            int[] merge = new int[merge1.Length + merge2.Length];
            Array.Copy(merge1, merge, merge1.Length);
            Array.Copy(merge2, 0, merge, merge1.Length, merge2.Length);           
        }

        private void MergeMethod2()
        {
            int[] merge1 = { 1, 3, 4 };
            int[] merge2 = { 2, 6, 7 };
            int m1 = merge1.Length; //사이즈 조정하기 전 merg1의 크기
            //merge1의 크기를 merge1 + merge2 크기로 재조정
            Array.Resize<int>(ref merge1, m1 + merge2.Length);
            Array.Copy(merge2, 0, merge1, m1, merge2.Length);
        }

        private void MergeLinq()
        {
            int[] merge1 = { 1, 3, 4 };
            int[] merge2 = { 2, 6, 7 };
            int[] result = (from x in merge1 select x).Union(from y in merge2 select y).OrderBy(z => z).ToArray();
            int[] result1 = merge1.Union(merge2).OrderByDescending(z => z).ToArray();
        }

        #endregion

        #region 검색
        private void SearchMethod()
        {
            //이진검색은 오름차순으로 정려
            int[] data = { 1, 3, 5, 9, 12, 15};
            int search = 12;     //찾으려는 값
            int low = 0;
            int high = data.Length - 1;     //5 
            while (low <= high) 
            {
                int index = (low + high) / 2;   //중간값
                if (!(data[index] == search))    //못 찾았으면
                {
                    if (data[index] > search)   //찾으려는 값보다 크면
                        high = index - 1;
                    else                    //찾으려는 값보다 작으면
                        low = index + 1;
                }
                else    //찾았으면 빠져나오기
                {
                    textBox1.Text = $"위치 : {index}";
                    break;
                }                    
            }
        }
        #endregion


        #region 근삿값
        private void NearMethod()
        {
            int[] list = { -2, 2, 4, 5, 7, 8, 12 };
            int target = 0;     //0에 가까운 값 구하기
            int result = int.MaxValue;     //0과 얼마만큼 차이나는지
            List<int> nearlist = new List<int>();       //근삿값 리스트들
            int Abs(int value) => (value > 0) ? value : -value;
            foreach (var item in list)
            {
                if (Abs(item - target) <= result)
                {
                    result = Abs(item - target);
                    nearlist.Add(item);
                }                    
            }
        }
        #endregion


        #region Max
        private void MaxMethod1(params int[] items)
        {
            int max = int.MinValue;
            foreach (var item in items)
            {
                if(item > max)                
                    max = item;                
            }
            textBox1.Text = max.ToString();
        }
        private void MaxMethod(params int[] items) => textBox1.Text = items.Max().ToString();
        #endregion


        #region Average
        private void AverageMethod(params int[] items) => textBox1.Text = items.Average().ToString();
        #endregion
        

        #region 개수세기
        private int CountMethod(int[] items) => items.Where(x => x % 10 == 0).Count();
        private int CounthMehod => Enumerable.Range(1, 100).Where(x => x % 3 == 0).Count(); //3의 배수
        #endregion


        #region 합계
        private int SumMethod(params int[] items) => items.Where(x => x > 30).Sum();
        //private int SumMethod(params int[] items)
        //{
        //    return items.Where(x => x > 30).Sum();
        //}
        #endregion
    }
}
