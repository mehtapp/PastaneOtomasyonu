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
    public partial class Raporlar : Form
    {
        SqlConnection con = new SqlConnection("Server=.;Database=Pastane;Integrated Security=true");

        public Raporlar()
        {
            InitializeComponent();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            Form1 anasayfa = new Form1();
            anasayfa.Show();this.Hide();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnRap_1_Click(object sender, EventArgs e) //Satıcı ve İlçeye Göre İl Sıralaması
        {
            SqlCommand cmd = new SqlCommand("", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt=new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnRap_2_Click(object sender, EventArgs e) //Şehri İstanbul Olan Satıcıların Bilgileri
        {
            SqlCommand cmd = new SqlCommand("Select * from Satici where Saticiİl='İstanbul'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btn_Rap3_Click(object sender, EventArgs e) //İlçe Kadıköy ve Maltepe Olan Satıcıların Bilgileri
        {
            SqlCommand cmd = new SqlCommand("Select * from Satici where Saticiİlce='Kadıköy' OR Saticiİlce='Maltepe'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnRap_4_Click(object sender, EventArgs e) //İsmi Pasta ve Fiyatı 100TL'den Fazla Olan Ürünler
        {
            SqlCommand cmd = new SqlCommand("Select * from Urunler where UrunAdi='Pasta' and UrunFiyat>100", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void btnRap_6_Click_1(object sender, EventArgs e) //Müşteri İsimleri Sırala
        {
            con.Open();
            string sorgu = "Select * from [Musteriler] order by MusteriAdSoyad desc";
            SqlDataAdapter dA = new SqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            dA.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0]; 
            con.Close();
        }
        private void btnRap_7_Click(object sender, EventArgs e)  //En Son Eklenen 5 Müşteri
        {
            con.Open();
            string sorgu = "Select top 5 * from [Musteriler] order by MusteriNo desc";
            SqlDataAdapter dA = new SqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            dA.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];   
            con.Close();
        }
        private void btnRap_8_Click(object sender, EventArgs e) //İsme Göre Sipariş Adet Toplamı
        {
            con.Open();
            string sorgu = "Select SiparisAdi, sum(SiparisAdet) from [Siparis] group by SiparisAdi";
            SqlDataAdapter dA = new SqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            dA.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];   
            con.Close();
        }
        private void btnRap9_Click(object sender, EventArgs e) //Tüm Siparişleri göster
        {
            con.Open();
            string sorgu = "Select * from Urunler as u join Siparis as s on u.UrunNo=s.UrunNo ";
            SqlDataAdapter dA = new SqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            dA.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];   
            con.Close();
        }

        private void btnRap_5_Click(object sender, EventArgs e)
        {
            con.Open();
            string sorgu = "Select count(*) from Urunler";
            SqlDataAdapter dA = new SqlDataAdapter(sorgu, con);
            DataSet ds = new DataSet();
            dA.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];  
            con.Close();
        }
    }
}
