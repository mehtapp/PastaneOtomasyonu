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
    public partial class KullaniciGiris : Form
    {
        SqlConnection con= new SqlConnection("Server=.;Database=Pastane;integrated Security=true;");
        public KullaniciGiris()
        {
            InitializeComponent();
        }
        private void KullaniciGiris_Load(object sender, EventArgs e)
        {
            gBox_KayitOl.Visible = false;
            gBoxGirisYap.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e) //login
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "Select * from KullaniciGiris where KullaniciAd=@kullaniciad and KullaniciSifre=@sifre";
            cmd.Parameters.AddWithValue("@kullaniciad", log_username.Text );
            cmd.Parameters.AddWithValue("@sifre", log_password.Text);
            con.Open();
            SqlDataReader re=cmd.ExecuteReader();
            if (re.Read())
            {
                Form1 anasayfa = new Form1();
                anasayfa.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adınız veya şifreniz hatalı. Tekrar Deneyiniz.","Başarısız", MessageBoxButtons.OKCancel);
            }
            con.Close();
            log_password.Clear();
            log_username.Clear();
        }
        private void button1_Click(object sender, EventArgs e) //open gbBox Sign UP
        {
            gBox_KayitOl.Visible = true;
        }
        public bool UserNameCheck()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from KullaniciGiris where KullaniciAd=@username", con);
                cmd.Parameters.AddWithValue("@username", txt_userName.Text);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return true;
                }
                else
                {   
                    return false;
                }
            }
            catch (Exception)
            { return false; }
            finally
            {
                con.Close();
            } 
        }
        private void button4_Click(object sender, EventArgs e) // insert user
        {
            if (!UserNameCheck())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("insert into KullaniciGiris(KullaniciAd, KullaniciSifre, Email, Telefon) " +
                    "values (@kullaniciAd, @kullaniciSifre, @mail, @telefon)");
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@kullaniciAd", txt_userName.Text);
                    cmd.Parameters.AddWithValue("@kullaniciSifre", txtPssword.Text);
                    cmd.Parameters.AddWithValue("@mail", txt_mail.Text);
                    cmd.Parameters.AddWithValue("@telefon", txphone.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Kaydınız Yapıldı. Giriş Yapabilirsiniz.");

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex + "İşlem Başarısız. Daha sonra tekrar deneyiniz.");
                }
                txt_userName.Clear();
                txtPssword.Clear();
                txt_mail.Clear();
                txphone.Clear();
            }
            else
            {
                MessageBox.Show("Bu kullanıcı adı alınmış. Başka bir kullanıcı adı deneyiniz.");
            }
            
        }
    }
}
