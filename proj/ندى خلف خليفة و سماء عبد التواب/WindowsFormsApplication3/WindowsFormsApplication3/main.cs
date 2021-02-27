using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            huffman hf = new huffman();
            hf.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            adabtive_hulfman adb = new adabtive_hulfman();
            adb.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LZW lzw = new LZW();
            lzw.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Arthmatic AA = new Arthmatic();
            AA.ShowDialog();
            
        }
    }
}
