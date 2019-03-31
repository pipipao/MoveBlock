using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoveBlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const int N = 4;
        Button[,] buttens = new Button[N, N];
        private void Form1_Load(object sender, EventArgs e)
        {
            //load all btns
            generateAllButtens();
        }
        void generateAllButtens() {
            int x0 = 100, y0 = 10, w = 45, d = 50;
            for (int r=0;r<N;r++) {
                for (int c=0;c<N;c++) {
                    int num = r * N + c;
                    Button btn = new Button();
                    btn.Text = (num + 1).ToString();
                    btn.Top = y0 + c * d;
                    btn.Left = x0 + d * r;
                    btn.Height = w;
                    btn.Width = w;
                    btn.Tag = r * N + c;
                  //  btn.Click += Btn_Click;   此代码为vs按tab键自动生成的
                    btn.Click += new EventHandler(Btn_Click);
                   btn.Visible = true;
                    buttens[r, c] = btn;
                    this.Controls.Add(btn);
                }
            }
            buttens[N - 1, N - 1].Visible = false;
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Button blank = FindBlank();
            if (isNebhior(btn,blank)) {
                swap(btn,blank);

            }
            if (vic()) {
                MessageBox.Show("victriory");
            }
            
        }

        private bool vic()
        {
            for (int r=0;r<N;r++) {
                for (int c=0;c<N; c++) {
                    if (buttens[r,c].Text!=(r*N+c+1).ToString()) {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isNebhior(Button a,Button b)
        {
            int anum = (int)a.Tag;
            int bnum = (int)b.Tag;
            if (anum+1==bnum||anum-1==bnum||anum+4==bnum||anum-4==bnum) {
                return true;
            }
            return false;
            
        }

        private Button FindBlank()
        {
            for (int r=0;r<N;r++) {
                for (int c=0;c<N;c++) {
                    if (!buttens[r,c].Visible) {
                        return buttens[r,c];
                    }
                }
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //打乱顺序
            
                Shuffle();
            
            
        }
        void Shuffle() {
            Random r = new Random();
            int[] a = new int[4];
            for (int i=0;i<a.Length; i++) {
                a[i] = r.Next(4);

            }
            swap(buttens[a[0],a[1]],buttens[a[2],a[3]]);
        }

        private void swap(Button a,Button b)
        {
            string name = a.Text;
            a.Text = b.Text;
            b.Text = name;

            bool v = b.Visible;
            b.Visible = a.Visible;
            a.Visible = v;
            
        }
        
    }
}
