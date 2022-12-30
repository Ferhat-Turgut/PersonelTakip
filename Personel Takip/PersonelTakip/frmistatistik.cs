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

namespace WindowsFormsApp19
{
    public partial class frmistatistik : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-SKDKUH5\\SQLEXPRESS;Initial Catalog=personelveritabani;Integrated Security=True");
        public frmistatistik()
        {
            InitializeComponent();
        }

        private void frmistatistik_Load(object sender, EventArgs e)
        {
            //toplam personel sayısı
            baglanti.Open();
            SqlCommand komuttoplampersonel = new SqlCommand("Select Count(*) From Tbl_Personel",baglanti);
            SqlDataReader dr1 = komuttoplampersonel.ExecuteReader();
            while (dr1.Read())
            {
                lbltoplampersonel.Text = dr1[0].ToString();
            }
            
            
            baglanti.Close();

            //evli personel sayısı
            baglanti.Open();
            SqlCommand evlipersonel = new SqlCommand("Select Count(*) From Tbl_Personel where Perdurum=1", baglanti);
            dr1 = evlipersonel.ExecuteReader();
            while (dr1.Read())
            {
                lblevlipersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //bekar personel sayısı
            baglanti.Open();
            SqlCommand bekarpersonel = new SqlCommand("Select Count(*) From Tbl_Personel where Perdurum=0",baglanti);
            dr1 = bekarpersonel.ExecuteReader();
            while (dr1.Read())
            {
                lblbekarpersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //şehir sayısı
            baglanti.Open();
            SqlCommand sehirsayisi = new SqlCommand("Select Count(distinct(Persehir)) From Tbl_Personel",baglanti);
            dr1 = sehirsayisi.ExecuteReader();
            while (dr1.Read())
            {
                lblsehirsayisi.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //toplam maaş

            baglanti.Open();
            SqlCommand toplammaas = new SqlCommand("Select Sum(Permaas) From Tbl_Personel",baglanti);
            dr1 = toplammaas.ExecuteReader();
           
            while (dr1.Read())
            {
                lbltoplammaas.Text = dr1[0].ToString();
            }
            baglanti.Close();

            //ortalama maaş

            baglanti.Open();

            SqlCommand ortalamamaas = new SqlCommand("Select Avg(Permaas) From Tbl_Personel",baglanti);
            dr1 = ortalamamaas.ExecuteReader();
            while (dr1.Read())
            {
                lblortalamamaas.Text = dr1[0].ToString();
            }
            baglanti.Close();
        }
    }
}
