using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Draw draw;
        public Form2 f2;
        public int l23r;
        public int l23g;
        public int l67g;
        public int tsn;
        public int tew;
        public Form1(Form2 f2)
        {
            InitializeComponent();
            this.f2 = f2;
            l23r = int.Parse(f2.textBox1.Text);
            l23g = int.Parse(f2.textBox2.Text);
            l67g = int.Parse(f2.textBox3.Text);
            tsn = int.Parse(f2.textBox4.Text);
            tew = int.Parse(f2.textBox5.Text);
        }


        private void PictureBox2_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            draw = new Draw(pictureBox2,l23r,l23g,l67g,tsn,tew);
            draw.init();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            draw.init();
        }
    }
}
