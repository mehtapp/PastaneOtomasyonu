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
    public partial class Urunler : Form
    {
       SqlConnection con1 = new SqlConnection("Server=.;Database=Pastane;Integrated Security=true");
        public Urunler()
        {
            InitializeComponent();
        }
        public void Listele(string baglan)
        {
            SqlDataAdapter dr=new SqlDataAdapter(baglan, con1);
            DataSet doldur= new DataSet();              
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur.Tables[0];
        }
        private void button3_Click(object sender, EventArgs e) //Select
        {
            Listele("Select * from Urunler");
        }
        private void button4_Click(object sender, EventArgs e) //insert
        {
            con1.Open();
            SqlCommand komut = new SqlCommand("insert into Urunler (UrunAdi, UrunFiyat, KullanimTarihi, UretimTarihi) values (" +
                "@UrunAdi, @UrunFiyat, @KullanimTarihi, @UretimTarihi)", con1);
            komut.Parameters.AddWithValue("@UrunAdi", textBox2.Text);
            komut.Parameters.AddWithValue("@UrunFiyat", textBox3.Text);
            komut.Parameters.AddWithValue("@KullanimTarihi", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@UretimTarihi", dateTimePicker2.Text);
            komut.ExecuteNonQuery();
            con1.Close();
            Listele("Select * from Urunler");
        }
        private void button5_Click(object sender, EventArgs e) //Update
        {
            con1.Open();
            SqlCommand komut = new SqlCommand("Update Urunler set UrunAdi=@UrunAdi, UrunFiyat=@UrunFiyat, KullanimTarihi=@KullanimTarihi, UretimTarihi=@UretimTarihi where UrunNo=@UrunNo", con1);
            komut.Parameters.AddWithValue("@UrunAdi", textBox2.Text);
            komut.Parameters.AddWithValue("@UrunFiyat", textBox3.Text);
            komut.Parameters.AddWithValue("@KullanimTarihi", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@UretimTarihi", dateTimePicker2.Text);
            komut.Parameters.AddWithValue("@UrunNo", textBox1.Text);

            komut.ExecuteNonQuery();
            con1.Close();
            Listele("Select * from Urunler");
        }
        private void button6_Click(object sender, EventArgs e) //Del
        {
            con1.Open();
            SqlCommand komut = new SqlCommand("Delete from Urunler where UrunNo='" + textBox1.Text.ToString() + "'", con1);
            komut.ExecuteNonQuery();
            con1.Close();
            Listele("Select * from Urunler");
        }
        private void button7_Click(object sender, EventArgs e) //Search
        {
            SqlCommand komut = new SqlCommand();
            SqlDataAdapter dr = new SqlDataAdapter("Select * from Urunler where UrunNo='" + textBox1.Text.ToString() + "'", con1);
            DataSet doldur = new DataSet();                     
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur.Tables[0];
        }
        private void button8_Click(object sender, EventArgs e) //Report
        {
            SqlCommand cmd = new SqlCommand("Select count(UrunNo) as [Satıştaki Ürün Çeşit] from Urunler ", con1);
            SqlDataAdapter dA = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable(); 
            dA.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString();
            dateTimePicker2.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString();
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
    }
}
