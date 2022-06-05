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
    public partial class Siparisler : Form
    {
        SqlConnection con = new SqlConnection("Server=.;Database=Pastane;Integrated Security=true");
        public Siparisler()
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
        public void SiparisListe(string sorgu)
        {
            SqlDataAdapter Adapter=new SqlDataAdapter(sorgu,con);
            DataTable dt=new DataTable();
            Adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button4_Click(object sender, EventArgs e) //insert
        {
            SqlCommand cmd = new SqlCommand("insert into [Siparis](SiparisAdi, SiparisAdres, SiparisAdet," +
                "SiparisFiyat, Tutar, UrunNo, MusteriNo, SaticiNo) values (@sipAdi, @sipAdres, @sipAdet, @sipFiyat, @tutar, @urunNo, " +
                "@musNo, @saticiNo)", con);
            cmd.Parameters.AddWithValue("@sipAdi", txt_SipIsim.Text );
            cmd.Parameters.AddWithValue("@sipAdres", txt_adres.Text );
            cmd.Parameters.AddWithValue("@sipAdet", txt_adet.Text);
            cmd.Parameters.AddWithValue("@sipFiyat", txt_fiyat.Text);
            cmd.Parameters.AddWithValue("@tutar",  txt_tutar.Text);
            cmd.Parameters.AddWithValue("@urunNo", comboBoxUrunNo.SelectedValue);
            cmd.Parameters.AddWithValue("@musNo", comboBoxMusNo.SelectedValue);
            cmd.Parameters.AddWithValue("@saticiNo", comboBoxSaticino.SelectedValue);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            SiparisListe("Select * from [Siparis]");
        }

        private void button5_Click(object sender, EventArgs e) //update
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Update [Siparis] set SiparisAdi=@sipAdi, SiparisAdres=@sipAdres, " +
            "SiparisAdet=@sipAdet, SiparisFiyat=@sipFiyat, Tutar=@tutar, UrunNo=@UrunNo,MusteriNo=@MusteriNo, SaticiNo=@SaticiNo" +
            " where SiparisNo=@sipNo",  con);
            cmd.Parameters.AddWithValue("@sipNo", txt_sipNo.Text);
            cmd.Parameters.AddWithValue("@sipAdi", txt_SipIsim.Text);
            cmd.Parameters.AddWithValue("@sipAdres", txt_adres.Text);
            cmd.Parameters.AddWithValue("@sipAdet", txt_adet.Text);
            cmd.Parameters.AddWithValue("@sipFiyat", txt_fiyat.Text);
            cmd.Parameters.AddWithValue("@tutar", txt_tutar.Text);
            cmd.Parameters.AddWithValue("@UrunNo", comboBoxUrunNo.SelectedValue);
            cmd.Parameters.AddWithValue("@MusteriNo", comboBoxMusNo.SelectedValue);
            cmd.Parameters.AddWithValue("@SaticiNo", comboBoxSaticino.SelectedValue);

            cmd.ExecuteNonQuery(); 
            con.Close();
            SiparisListe("Select * from [Siparis]");
        }

        private void button3_Click(object sender, EventArgs e)  ///list
        {
            SiparisListe("Select * from [Siparis]");
        }

        private void button6_Click(object sender, EventArgs e)  //del
        {
            con.Open();
            SqlCommand komut = new SqlCommand("Delete from [Siparis] where SiparisNo=@sipNo", con);
            komut.Parameters.AddWithValue("@sipNo", txt_sipNo.Text);
            komut.ExecuteNonQuery();
            con.Close();
            SiparisListe("Select * from [Siparis]");
        }
        private void button7_Click(object sender, EventArgs e) //search
        {
            SqlCommand komut = new SqlCommand("Select * from [Siparis] where SiparisNo=@sipNo", con); 
            SqlDataAdapter dr = new SqlDataAdapter(komut);
            komut.Parameters.AddWithValue("@sipNo",txt_sipNo.Text.ToString());
            DataSet doldur = new DataSet();
            dr.Fill(doldur);
            dataGridView1.DataSource = doldur.Tables[0];
        }
        private void button8_Click(object sender, EventArgs e)  //report
        {
            SqlCommand cmd = new SqlCommand("Select count(SiparisNo) as [Toplam Sipariş] from Siparis ", con);
            SqlDataAdapter dA = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dA.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secim = dataGridView1.SelectedCells[0].RowIndex;
            txt_sipNo.Text = dataGridView1.Rows[secim].Cells[0].Value.ToString();
            txt_SipIsim.Text = dataGridView1.Rows[secim].Cells[1].Value.ToString();
            txt_adres.Text = dataGridView1.Rows[secim].Cells[2].Value.ToString();
            txt_adet.Text = dataGridView1.Rows[secim].Cells[3].Value.ToString(); ;
            txt_fiyat.Text = dataGridView1.Rows[secim].Cells[4].Value.ToString(); 
            txt_tutar.Text = dataGridView1.Rows[secim].Cells[5].Value.ToString();

            string UrunNo = dataGridView1.Rows[secim].Cells[6].Value.ToString();
            comboBoxUrunNo.Text = UrunAdiCek(UrunNo);
            string MusNo= dataGridView1.Rows[secim].Cells[7].Value.ToString();
            comboBoxMusNo.Text = MusteriAdSoyadCek(MusNo);
            string SaticiNo = dataGridView1.Rows[secim].Cells[8].Value.ToString();
            comboBoxSaticino.Text = SaticiAdSoyadCek(SaticiNo);
            
        }
        public string UrunAdiCek(string urunNo)
        {
            try
            { 
                SqlCommand command = new SqlCommand("Select * from Urunler where UrunNo=@urunNo", con);
                command.Parameters.AddWithValue("@urunNo",urunNo);
                con.Open();
                SqlDataReader rdr= command.ExecuteReader();
                while (rdr.Read())
                {
                    return rdr["UrunAdi"].ToString();
                }
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                con.Close();
            }
            return "";  

        }

        public string MusteriAdSoyadCek(string musteriNo)
        {
            try
            {
                SqlCommand command = new SqlCommand("Select * from Musteriler where MusteriNo=@musteriNo", con);
                command.Parameters.AddWithValue("@musteriNo", musteriNo);
                con.Open();
                SqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    return rdr["MusteriAdSoyad"].ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                con.Close();
            }
            return "";

        }
        public string SaticiAdSoyadCek(string saticiNo)
        {
            try
            {
                SqlCommand command = new SqlCommand("Select * from Satici where SaticiNo=@saticiNo", con);
                command.Parameters.AddWithValue("@saticiNo", saticiNo);
                con.Open();
                SqlDataReader rdr = command.ExecuteReader();
                while (rdr.Read())
                {
                    return rdr["SaticiAdSoyad"].ToString();
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                con.Close();
            }
            return "";

        }

        private void Siparisler_Load(object sender, EventArgs e)
        {
            comboBoxUrunNo.DataSource=ComboboxVeriler("Urunler");
            comboBoxMusNo.DataSource = ComboboxVeriler("Musteriler");
            comboBoxSaticino.DataSource = ComboboxVeriler("Satici");
            

        }
        public DataTable ComboboxVeriler(string tabloAdi)
        {
            try
            {
                SqlCommand command = new SqlCommand("Select * from " + tabloAdi , con);
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {con.Close();}
           
            
           
        }

        private void comboBoxUrunNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
