using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace E_school
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmogrencigiris fro = new frmogrencigiris();
            fro.Show();
            this.Hide();
            

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Frmogretmengiris frr = new Frmogretmengiris();
            frr.Show();
            this.Hide();
        }
    }
}
