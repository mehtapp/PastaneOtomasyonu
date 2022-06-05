using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pastane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e) //müşteri
        {
            Musteriler m1= new Musteriler();
            m1.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e) //ürün
        {
            Urunler urun= new Urunler();
            urun.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e) //sipariş
        {
            Siparisler siparis= new Siparisler();   
            siparis.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e) //satıcı
        {
            Saticilar satici= new Saticilar();
            satici.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e) //raporlar
        {
            Raporlar rapor = new Raporlar();
            rapor.Show();
            this.Hide();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            KullaniciGiris hg = new KullaniciGiris();
            this.Hide();
            hg.Show();
        }
    }
}
