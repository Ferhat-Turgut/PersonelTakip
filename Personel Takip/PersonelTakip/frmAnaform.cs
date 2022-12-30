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
    public partial class frmAnaform : Form
    {
        public frmAnaform()
        {
            InitializeComponent();
        }

      SqlConnection   baglanti = new SqlConnection ("Data Source=DESKTOP-SKDKUH5\\SQLEXPRESS;Initial Catalog=personelveritabani;Integrated Security=True");

        void temizle()
        {
            txtid.Clear();
            txtisim.Clear();
            txtmeslek.Clear();
            txtsoyisim.Clear();
            cmbsehir.SelectedIndex = -1;
            mskmaas.Clear();
            radioButton1.Checked=false;
            radioButton2.Checked = false;
            txtisim.Focus();
        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelveritabaniDataSet1.Tbl_Personel' table. You can move, or remove it, as needed.
            this.tbl_PersonelTableAdapter.Fill(this.personelveritabaniDataSet1.Tbl_Personel);
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'personelveritabaniDataSet1.Tbl_Personel' table. You can move, or remove it, as needed.
            PersonelListele();
        }

        private void PersonelListele()
        {
            this.tbl_PersonelTableAdapter.Fill(this.personelveritabaniDataSet1.Tbl_Personel);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Personel (Perad,Persoyad,Persehir,Permaas,Permeslek,Perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1",txtisim.Text);
            komut.Parameters.AddWithValue("@p2",txtsoyisim.Text);
            komut.Parameters.AddWithValue("@p3",cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4",mskmaas.Text);
            komut.Parameters.AddWithValue("@p5",txtmeslek.Text);

            if (radioButton1.Checked)
            {
                komut.Parameters.AddWithValue("@p6","true");
            }
            if (radioButton2.Checked)
            {
                komut.Parameters.AddWithValue("@p6","false");
            }
            komut.ExecuteNonQuery();
            MessageBox.Show("KAYIT BAŞARILI");
            baglanti.Close();

            PersonelListele();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilengrid = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilengrid].Cells[0].Value.ToString();
            txtisim.Text= dataGridView1.Rows[secilengrid].Cells[1].Value.ToString();
            txtsoyisim.Text= dataGridView1.Rows[secilengrid].Cells[2].Value.ToString();
            cmbsehir.Text= dataGridView1.Rows[secilengrid].Cells[3].Value.ToString();
            mskmaas.Text= dataGridView1.Rows[secilengrid].Cells[4].Value.ToString();
            txtmeslek.Text= dataGridView1.Rows[secilengrid].Cells[6].Value.ToString();
            string durum= dataGridView1.Rows[secilengrid].Cells[5].Value.ToString(); 
            
            if (durum=="True")
                {
                  radioButton1.Checked = true;
                }

            else
                {
                  radioButton2.Checked = true;
                }

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete From Tbl_personel where Perid=@s1",baglanti);
            komutsil.Parameters.AddWithValue("@s1",txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();

            PersonelListele();
            MessageBox.Show("Kayıt Silindi");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("Update Tbl_Personel Set Perad=@g1,Persoyad=@g2,Persehir=@g3,Permaas=@g4,Perdurum=@g5,Permeslek=@g6 where Perid=@g7",baglanti);
            komutguncelle.Parameters.AddWithValue("@g1",txtisim.Text);
            komutguncelle.Parameters.AddWithValue("@g2", txtsoyisim.Text);
            komutguncelle.Parameters.AddWithValue("@g3", cmbsehir.Text);
            komutguncelle.Parameters.AddWithValue("@g4", mskmaas.Text);
            komutguncelle.Parameters.AddWithValue("@g6", txtmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@g7",txtid.Text);

            if (radioButton1.Checked == true)
            {
                
                komutguncelle.Parameters.AddWithValue("@g5", true);
            }
            else
            {
                
                komutguncelle.Parameters.AddWithValue("@g5", false);
            }
            komutguncelle.ExecuteNonQuery();
            baglanti.Close();

            PersonelListele();
            MessageBox.Show("Güncelleme Yapıldı");
        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            frmistatistik fistatistik = new frmistatistik();
            fistatistik.Show();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            frmgrafik grafik = new frmgrafik();
            grafik.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmRaporlar rpr = new frmRaporlar();
            rpr.Show();
        }
    }
}
