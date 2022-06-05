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
    public partial class Saticilar : Form
    {
        SqlConnection con = new SqlConnection("Server=.;Database=Pastane;Integrated Security=true");
        public Saticilar()
        {
            InitializeComponent();
        }
        private void button11_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 anasayfa = new Form1();
            anasayfa.Show();
        }
        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        public void SatListele(string baglan)
        {
            SqlDataAdapter dr = new SqlDataAdapter(baglan, con);
            DataSet doldur = new DataSet();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur.Tables[0];
        }
        private void button4_Click(object sender, EventArgs e) //insert
        {
            con.Open();
            SqlCommand komut = new SqlCommand("insert into [Satici] (SaticiAdSoyad, SaticiAdres,Saticiİl, Saticiİlce) " +
                "values (@adSoyad, @adres, @il, @ilce)" , con);
            komut.Parameters.AddWithValue("@adSoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@adres", txt_adres.Text);
            komut.Parameters.AddWithValue("@il", txt_il.Text);
            komut.Parameters.AddWithValue("@ilce", txt_ilce.Text);
            komut.ExecuteNonQuery(); 
            con.Close();
            SatListele("Select * from [Satici]");
        }
        private void button5_Click(object sender, EventArgs e) //update
        {
            con.Open();
            SqlCommand komut = new SqlCommand("update [Satici] set SaticiAdSoyad=@adSoyad, SaticiAdres=@adres," +
                "Saticiİl=@il, Saticiİlce=@ilce where SaticiNo=@satNo" ,con);
            komut.Parameters.AddWithValue("@satNo", txt_satNo.Text);
            komut.Parameters.AddWithValue("@adSoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@adres", txt_adres.Text);
            komut.Parameters.AddWithValue("@il", txt_il.Text);
            komut.Parameters.AddWithValue("@ilce", txt_ilce.Text);
            komut.ExecuteNonQuery();
            con.Close();
            SatListele("Select * from [Satici]");
        }
        private void button3_Click(object sender, EventArgs e) //list
        {
            SatListele("Select * from [Satici]");
        }
        private void button6_Click(object sender, EventArgs e)  //del
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Delete from [Satici] where SaticiNo=@SaticiNo", con);
            komut.Parameters.AddWithValue("@SaticiNo", txt_satNo.Text);
            komut.ExecuteNonQuery();
            con.Close();
            SatListele("Select * from [Satici]");
        }
        private void button7_Click(object sender, EventArgs e)  //search
        {
            SqlCommand komut = new SqlCommand("Select * from [Satici] where SaticiNo=@SaticiNo", con);
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            komut.Parameters.AddWithValue("@SaticiNo", txt_satNo.Text);
            DataSet doldur = new DataSet();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur.Tables[0];
        }
        private void button8_Click(object sender, EventArgs e)  //report
        {
            SqlCommand cmd = new SqlCommand("Select count(SaticiNo) as [Sistemdeki Satıcılar] from [Satici] ", con);
            SqlDataAdapter dA = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dA.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            txt_satNo.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            txtAdSoyad.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            txt_adres.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            txt_il.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            txt_ilce.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
        }
    }
}
