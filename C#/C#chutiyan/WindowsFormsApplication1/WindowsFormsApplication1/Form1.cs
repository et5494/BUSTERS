using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = textBox1.Text;
            if (str == "") return;
            Int64 cs = Int64.Parse(str);
            Boolean aa = Git(cs);
            if (aa)  MessageBox.Show("O");
            else MessageBox.Show("J");
        }

        static Boolean Git(Int64 a)
        {
            if (a % 2 == 0) return true;
            else return false;
         }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {


            if ("1234567890".IndexOf(e.KeyChar) == -1 && e.KeyChar != '\b') 
            {
                e.Handled = true; 
            }
        }
    }
}
