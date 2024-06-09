using HospitalManagement.BusinnesLayer;//BusinessLayer'a ulaşmak için gerekli. 
using HospitalManagement.DataLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;//Yazdırma işlemleri için gerekli.
using System.Linq;
using System.Text;//StringBuilder kullanımı için gerekli.
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagement.PresentationLayer
{
    public partial class DoctorForm : Form
    {
        public DoctorForm()
        {
            InitializeComponent();
        }
        int appointmentId = 0;
        AppointmentDetailsController appointmentDetails; //RandevuDetay için controller referansı oluşturuluyor.
        DoctorControl doctor;
        Doctor doctorSession;

        private void DoctorForm_Load(object sender, EventArgs e)
        {
            appointmentDetails = new AppointmentDetailsController(); //RandevuDetay için controller oluşturuluyor.
            doctor = new DoctorControl(); //Doctor için controller oluşturuluyor.            
            doctorSession = doctor.GetDoctorSession();//oturum açan doktor bilgisi alındı.
            this.Text += " - " + doctorSession.DName + " " +
                doctorSession.DLastName;//doktor ismi form başlığına yazıldı.
                                        //Controller aracılığıyla RandevuDetay tablsou DGW'a yazdırılıyor.
            dtGVAppointmentDetails.DataSource = appointmentDetails.GetAppointmentListbyDoctor(doctorSession.DoctorId);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPatientNote.Text != "")
            {
                if (appointmentId > 0)
                {
                    if (appointmentDetails.AddAppointmentNote(appointmentId, txtPatientNote.Text))
                    {
                        MessageBox.Show("Kayıt Başarılı");
                        DoctorFormClear();
                    }
                }
                else
                    MessageBox.Show("Öncelikle randevu seçimi yapmalısınız.", "Uyarı",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
                MessageBox.Show("Boş not kaydedilemez.");
        }

        private void DoctorFormClear() //Form ekranını temizler.
        {
            appointmentId = 0;
            txtPatientNote.Text = "";
            txtPatientName.Text = "";
            txtPatientLastName.Text = "";
            txtPatientPhone.Text = "";
            txtPatientEmail.Text = "";
            txtPatientDate.Text = "";
        }

        private void dtGVAppointmentDetails_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtPatientName.Text != "" && txtPatientLastName.Text != "" && txtPatientPhone.Text != "" &&
                   txtPatientDate.Text != "")
            {
                printPreviewDialog1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Lütfen bir randevu kaydı seçiniz." +
                    "(Seçim işlemini randevu bilgisine çift tıklayarak yapabilirsiniz.)", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //doktor görüşlerinin yer aldığı textbox'ın içeriğini pdf'e dönüştürürken tek satır
        //halinde değil de paragraf halinde yazmasını sağlamak amacıyla kullanılacak method
        public static string AddLineBreaks(string input, int maxLength)
        {
            StringBuilder sb = new StringBuilder();
            string[] words = input.Split(' ');
            int lineLength = 0;
            foreach (string word in words)
            {
                if (lineLength + word.Length > maxLength)
                {
                    sb.AppendLine();
                    lineLength = 0;
                }
                sb.Append(word + " ");
                lineLength += word.Length + 1;
            }
            return sb.ToString();
        }

        //Yazdırma işlemi için sayfa düzeni oluşturuluyor.
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font font = new Font("Arial", 10);  //font nesnesi oluşturuluyor.
                SolidBrush firca = new SolidBrush(Color.Black); //yazıyı yazması için fırça nesnesi oluşturuluyor
                Pen kalem = new Pen(Color.Black); //çizgi çizilmesi için kalem nesnesi oluşturuluyor.

                //drawstring methoduyla istenilen yazı yazdırılıyor
                e.Graphics.DrawString($"Rapor Tarihi: {DateTime.Now.ToString("dd.MM.yyyy")}", font, firca, 50, 25);

                font = new Font("Arial", 18, FontStyle.Bold);
                e.Graphics.DrawString("Hasta Randevu Detayları - Sonuçları", font, firca, 195, 100);

                e.Graphics.DrawLine(kalem, 50, 190, 780, 190);
                e.Graphics.DrawLine(kalem, 50, 365, 780, 365);
                e.Graphics.DrawLine(kalem, 50, 190, 50, 365);
                e.Graphics.DrawLine(kalem, 780, 190, 780, 365);
                font = new Font("Arial", 16, FontStyle.Bold);
                e.Graphics.DrawString("Hasta Bilgileri", font, firca, 60, 200);

                int x = 60;
                int y = 240;
                font = new Font("Arial", 14, FontStyle.Bold);
                e.Graphics.DrawString("Adı Soyadı: ", font, firca, x, y);
                e.Graphics.DrawString("E-mail: ", font, firca, x, y + 30);
                e.Graphics.DrawString("Telefon Numarası: ", font, firca, x, y + 60);
                e.Graphics.DrawString("Randevu Tarihi: ", font, firca, x, y + 90);

                x = 300;
                font = new Font("Arial", 14);
                e.Graphics.DrawString(txtPatientName.Text + " " + txtPatientLastName.Text, font, firca, x, y);
                e.Graphics.DrawString(txtPatientEmail.Text, font, firca, x, y + 30);
                e.Graphics.DrawString(txtPatientPhone.Text, font, firca, x, y + 60);
                Patient patient = appointmentDetails.GetPatientInfoByAppointmentId(appointmentId);
                e.Graphics.DrawString(dtGVAppointmentDetails.SelectedRows[0].Cells[2].Value.ToString(), font, firca, x, y + 90);

                e.Graphics.DrawLine(kalem, 50, 420, 780, 420);
                e.Graphics.DrawLine(kalem, 50, 900, 780, 900);
                e.Graphics.DrawLine(kalem, 50, 420, 50, 900);
                e.Graphics.DrawLine(kalem, 780, 420, 780, 900);
                y = 430;
                font = new Font("Arial", 16, FontStyle.Bold);
                e.Graphics.DrawString("Doktor Görüşleri", font, firca, 60, y);

                y = 470;
                string input = txtPatientNote.Text;
                int maxLength = 85;
                string output = AddLineBreaks(input, maxLength);
                font = new Font("Arial", 14);
                e.Graphics.DrawString(output, font, firca, 60, y);

                font = new Font("Arial", 14, FontStyle.Bold);
                e.Graphics.DrawString("Doktor Ad Soyad", font, firca, 600, 950);
                e.Graphics.DrawString("İmza", font, firca, 660, 975);
                font = new Font("Arial", 14);
                e.Graphics.DrawString("Dr. " + doctorSession.DName + " " + doctorSession.DLastName, font, firca, 600, 1010);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Hata :" + exception.Message);
            }
        }

        private void btnMail_Click(object sender, EventArgs e)
        {
            if (txtPatientName.Text != "" && txtPatientLastName.Text != "" && txtPatientPhone.Text != "" &&
                   txtPatientDate.Text != "" && txtPatientNote.Text != "")
            {
                DialogResult dialog = MessageBox.Show("Hasta görüşlerini göndermek istiyor musunuz?",
                    "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    MailSender.SendMail(
                        txtPatientEmail.Text,
                        txtPatientName.Text + " " + txtPatientLastName.Text + " Randevu Sonucu",
                        txtPatientNote.Text,
                        null);
                }
                else
                    MessageBox.Show("Gönderme işlemi iptal edildi.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen bir randevu kaydı seçiniz." +
                    "(Seçim işlemini randevu bilgisine çift tıklayarak yapabilirsiniz.)", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dtGVAppointmentDetails_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtGVAppointmentDetails_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dtGVAppointmentDetails.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    appointmentId = Convert.ToInt32(dtGVAppointmentDetails.Rows[e.RowIndex].Cells[0].Value);
                    if (appointmentId > 0)
                    {
                        Patient patient = appointmentDetails.GetPatientInfoByAppointmentId(appointmentId);
                        txtPatientName.Text = patient.PName;
                        txtPatientLastName.Text = patient.PLastName;
                        txtPatientPhone.Text = patient.PhoneNum;
                        txtPatientEmail.Text = patient.Email;
                        txtPatientDate.Text = patient.RecordDate.ToShortDateString();
                        PatientRecord record = appointmentDetails.GetAppointmentNoteByAppointmentId(appointmentId);
                        txtPatientNote.Text = record.Note;


                    }
                }
            }
        }

        private void printDocument1_PrintPage_1(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font font = new Font("Arial", 10);  //font nesnesi oluşturuluyor.
                SolidBrush firca = new SolidBrush(Color.Black); //yazıyı yazması için fırça nesnesi oluşturuluyor
                Pen kalem = new Pen(Color.Black); //çizgi çizilmesi için kalem nesnesi oluşturuluyor.

                //drawstring methoduyla istenilen yazı yazdırılıyor
                e.Graphics.DrawString($"Rapor Tarihi: {DateTime.Now.ToString("dd.MM.yyyy")}", font, firca, 50, 25);

                font = new Font("Arial", 18, FontStyle.Bold);
                e.Graphics.DrawString("Hasta Randevu Detayları - Sonuçları", font, firca, 195, 100);

                e.Graphics.DrawLine(kalem, 50, 190, 780, 190);
                e.Graphics.DrawLine(kalem, 50, 365, 780, 365);
                e.Graphics.DrawLine(kalem, 50, 190, 50, 365);
                e.Graphics.DrawLine(kalem, 780, 190, 780, 365);
                font = new Font("Arial", 16, FontStyle.Bold);
                e.Graphics.DrawString("Hasta Bilgileri", font, firca, 60, 200);

                int x = 60;
                int y = 240;
                font = new Font("Arial", 14, FontStyle.Bold);
                e.Graphics.DrawString("Adı Soyadı: ", font, firca, x, y);
                e.Graphics.DrawString("E-mail: ", font, firca, x, y + 30);
                e.Graphics.DrawString("Telefon Numarası: ", font, firca, x, y + 60);
                e.Graphics.DrawString("Randevu Tarihi: ", font, firca, x, y + 90);

                x = 300;
                font = new Font("Arial", 14);
                e.Graphics.DrawString(txtPatientName.Text + " " + txtPatientLastName.Text, font, firca, x, y);
                e.Graphics.DrawString(txtPatientEmail.Text, font, firca, x, y + 30);
                e.Graphics.DrawString(txtPatientPhone.Text, font, firca, x, y + 60);
                Patient patient = appointmentDetails.GetPatientInfoByAppointmentId(appointmentId);
                e.Graphics.DrawString(dtGVAppointmentDetails.SelectedRows[0].Cells[2].Value.ToString(), font, firca, x, y + 90);

                e.Graphics.DrawLine(kalem, 50, 420, 780, 420);
                e.Graphics.DrawLine(kalem, 50, 900, 780, 900);
                e.Graphics.DrawLine(kalem, 50, 420, 50, 900);
                e.Graphics.DrawLine(kalem, 780, 420, 780, 900);
                y = 430;
                font = new Font("Arial", 16, FontStyle.Bold);
                e.Graphics.DrawString("Doktor Görüşleri", font, firca, 60, y);

                y = 470;
                string input = txtPatientNote.Text;
                int maxLength = 85;
                string output = AddLineBreaks(input, maxLength);
                font = new Font("Arial", 14);
                e.Graphics.DrawString(output, font, firca, 60, y);

                font = new Font("Arial", 14, FontStyle.Bold);
                e.Graphics.DrawString("Doktor Ad Soyad", font, firca, 600, 950);
                e.Graphics.DrawString("İmza", font, firca, 660, 975);
                font = new Font("Arial", 14);
                e.Graphics.DrawString("Dr. " + doctorSession.DName + " " + doctorSession.DLastName, font, firca, 600, 1010);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Hata :" + exception.Message);
            }
        }
    }
    }

