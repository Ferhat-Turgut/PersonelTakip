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
    public partial class frmgiris : Form
    {
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-SKDKUH5\\SQLEXPRESS;Initial Catalog=personelveritabani;Integrated Security=True");
        public frmgiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand denetle = new SqlCommand("Select * From KullaniciTablosu where KullaniciAdi=@p1 and Sifre=@p2",baglanti);
            denetle.Parameters.AddWithValue("@p1",txtkadi.Text);
            denetle.Parameters.AddWithValue("@p2",txtsifre.Text);
            SqlDataReader rd = denetle.ExecuteReader();

            if (rd.Read())
            {
                frmAnaform anaform = new frmAnaform();
                anaform.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Geçersiz Giriş");
                txtkadi.Clear();
                txtsifre.Clear();
            }
            baglanti.Close();

        }
    }
}
