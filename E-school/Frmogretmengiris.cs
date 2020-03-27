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
    public partial class Frmogretmengiris : Form
    {
        public Frmogretmengiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_ogretmen1 where tc = @p1 and sifre = @p2",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", txtsifre.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                Frmogretmendetay frt = new Frmogretmendetay();
                frt.tc = msktc.Text;
                frt.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış Tc yada şifre.");
               
            }
        }
    }
}
