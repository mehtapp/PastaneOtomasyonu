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

namespace pastane
{
    public partial class Musteriler : Form
    {
        SqlConnection con = new SqlConnection("Server=.;Database=Pastane;Integrated Security=true");

        public Musteriler()
        {
            InitializeComponent();
        }
        public void MusListele(string baglan)
        {
            SqlDataAdapter dr = new SqlDataAdapter(baglan, con);
            DataSet doldur = new DataSet();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur.Tables[0];
        }
        public void temizle()
        {
            txt_adSoyad.Clear();
            txt_musNo.Clear();
            txt_tel.Clear();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 anasayfa= new Form1();
            anasayfa.Show();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void button4_Click(object sender, EventArgs e) //insert 
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "insert into [Musteriler](MusteriAdSoyad, MusteriTelefon) values " +
                    "(@adsoyad, @tel)";
                cmd.Parameters.AddWithValue("@adsoyad", txt_adSoyad.Text);
                cmd.Parameters.AddWithValue("@tel", txt_tel.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MusListele("Select * from Musteriler"); 
                temizle();

            }catch (Exception ex)
            {
                MessageBox.Show(ex+"İşlem başarısız.");
            }
        }
        private void button8_Click(object sender, EventArgs e) //rapor
        {
            SqlCommand cmd = new SqlCommand("Select count(MusteriNo) as [Toplam Müşteri] from Musteriler ", con);
            SqlDataAdapter dA = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dA.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button7_Click(object sender, EventArgs e) //search
        {
            SqlCommand komut = new SqlCommand("Select * from Musteriler where MusteriNo=@musNo", con);
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            komut.Parameters.AddWithValue("@MusNo", txt_musNo.Text);

            DataSet doldur = new DataSet();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur.Tables[0];
        }
        private void button6_Click(object sender, EventArgs e)  //del
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Delete from Musteriler where MusteriNo=@musNo", con);
            komut.Parameters.AddWithValue("@musNo",txt_musNo.Text);
            komut.ExecuteNonQuery();
            con.Close();
            MusListele("Select * from Musteriler");temizle();
        }
        private void button5_Click(object sender, EventArgs e) //Update
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Update  Musteriler set MusteriAdSoyad=@adSoyad, MusteriTelefon=@tel " +
                "where MusteriNo=@musNo", con);
            komut.Parameters.AddWithValue("@adSoyad", txt_adSoyad.Text );
            komut.Parameters.AddWithValue("@tel", txt_tel.Text);
            komut.Parameters.AddWithValue("@musNo", txt_musNo.Text);
            komut.ExecuteNonQuery();
            con.Close();
            MusListele("Select * from Musteriler");temizle();
        }
        private void button3_Click(object sender, EventArgs e) //listele
        {
            MusListele("Select * from Musteriler");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            txt_musNo.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            txt_adSoyad.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            txt_tel.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
        }
    }
}
