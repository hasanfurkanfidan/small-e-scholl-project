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
    public partial class frmogrencidetay : Form
    {
        public frmogrencidetay()
        {
            InitializeComponent();
        }
        public string tc;
        public string adsoyad;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void frmogrencidetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;
            SqlCommand komut = new SqlCommand("select ad,soyad from tbl_ogrenci1 where tc = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                lbladsoyad.Text= dr[0] + " " + dr[1];
            }
            SqlCommand komut2 = new SqlCommand("select adsoyad from tbl_ogretmen1", bgl.baglanti());
            SqlDataReader dr1 = komut2.ExecuteReader();
            while(dr1.Read())
            {
                cmbogretmen.Items.Add(dr1[0]);
                cmbogretmen2.Items.Add(dr1[0]);
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblduyurular ",bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            

            

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("insert into tblmesaj (mesaj,ogretmen,ogrenci) values (@p1,@p2,@p3)", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", richTextBox1.Text);
            komut3.Parameters.AddWithValue("@p2", cmbogretmen2.Text);
            komut3.Parameters.AddWithValue("@p3", lbladsoyad.Text);
            komut3.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("mesajınız iletildi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("select link from tbllink where ogretmen = @p1", bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1", cmbogretmen.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();

            while (dr3.Read())
            {
                webBrowser1.Navigate(dr3[0].ToString());
            }
        }
    }
}
