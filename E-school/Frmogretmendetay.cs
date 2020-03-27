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
    public partial class Frmogretmendetay : Form
    {
        public Frmogretmendetay()
        {
            InitializeComponent();
        }
        public string tc;
        sqlbaglantisi bgl = new sqlbaglantisi();
        private void Frmogretmendetay_Load(object sender, EventArgs e)
        {
            lbltc.Text = tc;
            SqlCommand komut = new SqlCommand("select adsoyad from tbl_ogretmen1 where tc = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", lbltc.Text);
            
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                lbladsoyad.Text = dr[0].ToString();
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("insert into tblduyurular (duyuru,ogretmen) values (@p1,@p2)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", richTextBox1.Text);
            komut2.Parameters.AddWithValue("@p2", lbladsoyad.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru eklendi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbllink (link,ogretmen) values (@p1,@p2)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtlink.Text);
            komut.Parameters.AddWithValue("@p2", lbladsoyad.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.ColumnCount = 3;
            dataGridView1.Columns[0].Name = "id";
            dataGridView1.Columns[1].Name = "Mesaj";
            dataGridView1.Columns[2].Name = "Öğrenci";
            SqlCommand komut2 = new SqlCommand("select * from tblmesaj where ogretmen = @p1", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", lbladsoyad.Text);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                int i = dataGridView1.Rows.Add();
                i = 0;
               
                dataGridView1.Rows[i].Cells[0].Value = dr2[0].ToString();
                dataGridView1.Rows[i].Cells[1].Value = dr2[1].ToString();
                dataGridView1.Rows[i].Cells[2].Value = dr2[3].ToString();


            }
        }
    }
}
