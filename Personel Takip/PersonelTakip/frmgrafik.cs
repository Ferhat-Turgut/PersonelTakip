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
    public partial class frmgrafik : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-SKDKUH5\\SQLEXPRESS;Initial Catalog=personelveritabani;Integrated Security=True");
        public frmgrafik()
        {
            InitializeComponent();
        }

        private void frmgrafik_Load(object sender, EventArgs e)
        {
            //meslek ve kişi sayısı grafik
            baglanti.Open();
            SqlCommand mesleksayisi = new SqlCommand("Select Persehir,Count(*) From Tbl_Personel Group by Persehir",baglanti);
            SqlDataReader dr1 = mesleksayisi.ExecuteReader();
            while (dr1.Read())
            {
                chart1.Series["sehirler"].Points.AddXY(dr1[0],dr1[1]);
            }
            baglanti.Close();

            //meslek ve ortalama maaş

            baglanti.Open();
            SqlCommand meslekortalamamaas = new SqlCommand("Select Permeslek,Avg(Permaas) From Tbl_Personel group by Permeslek",baglanti);
            dr1 = meslekortalamamaas.ExecuteReader();
            while (dr1.Read())
            {
                chart2.Series["meslek-maas"].Points.AddXY(dr1[0],dr1[1]);
            }
            baglanti.Close();
        }
    }
}
