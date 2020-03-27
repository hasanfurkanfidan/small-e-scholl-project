using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace E_school
{
    public partial class frmogrencigiris : Form
    {
        public frmogrencigiris()
        {
            InitializeComponent();
        }
        
        public void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmuyeol fru = new frmuyeol();
            fru.Show();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        frmogrencidetay frd = new frmogrencidetay();
       
        private void button1_Click(object sender, EventArgs e)
        {
            frmogrencidetay frd = new frmogrencidetay();
            SqlCommand komut = new SqlCommand("select * from tbl_ogrenci1 where tc = @p1 and sifre = @p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                frd.tc = msktc.Text;
               
                frd.Show();
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("Yanlış Tc yada şifre");
            }
            
        }

        private void frmogrencigiris_Load(object sender, EventArgs e)
        {
           
        }
    }
}
