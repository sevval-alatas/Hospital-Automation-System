using System;

using System.Windows.Forms;

namespace HospitalManagement.PresentationLayer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        BusinnesLayer.SecretaryControl secretary = new BusinnesLayer.SecretaryControl(); //Sekreter için controller oluşturuluyor.
        BusinnesLayer.DoctorControl doctor = new BusinnesLayer.DoctorControl(); //Doktor için controller oluşturuluyor.
        private short auth_type = 0;
        //Sekreter ve Doktor girişini ayırt etmek için değişken tanımı
        //auth_type 0 --> Tanımsız
        //auth_type 1 --> Sekreter
        //auth_type 2 --> Doktor

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPhoneNumber.Text != "" && txtPassword.Text != "")
            {
                if (auth_type == 1)
                {
                    if (secretary.SecretaryAuth(txtPhoneNumber.Text, txtPassword.Text))
                    {
                        Sekreter secretary = new Sekreter();
                        this.Hide();
                        secretary.ShowDialog();
                        ClearAuthForm();
                        this.Show();
                    }
                    else
                        MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı.");
                }
                else if (auth_type == 2)
                {
                    if (doctor.DoctorAuth(txtPhoneNumber.Text, txtPassword.Text))
                    {
                        DoctorForm doctor = new DoctorForm();
                        this.Hide();
                        doctor.ShowDialog();
                        ClearAuthForm();
                        this.Show();
                    }
                    else
                        MessageBox.Show("Kullanıcı Adı veya Şifre Hatalı.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Kullanıcı Adı ve Şifre Giriniz.");
            }
        }

        private void btnSecretary_Click(object sender, EventArgs e)
        {
            grpAuth.Visible = true;
            auth_type = 1;
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            grpAuth.Visible = true;
            auth_type = 2;
        }

        private void ClearAuthForm()
        {
            txtPhoneNumber.Text = "";
            txtPassword.Text = "";
            grpAuth.Visible = false;
        }
    }
}
