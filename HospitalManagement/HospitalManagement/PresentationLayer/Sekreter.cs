using HospitalManagement.BusinnesLayer; //BusinessLayer'a ulaşmak için gerekli. 
using HospitalManagement.DataLayer; //DataLayer'a' ulaşmak için gerekli. 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace HospitalManagement.PresentationLayer
{
    public partial class Sekreter : Form
    {
        public Sekreter()
        {
            InitializeComponent();
        }
        SecretaryControl secretary; //secretary parametresi oluşturuldu.
        PatientController patient; //patient parametresi oluşturuldu.
        AppointmentController appointment; //appointment parametresi oluşturuldu.
        DoctorControl doctor;//doctor paramatresi oluşturuldu
        Secretary secretarySession;//Oturum açan sekter parametresi oluşturuldu.
        int secretaryId = 0, patientId = 0, appointmentId = 0, doctorId = 0;

        private void btnAppointment_Click(object sender, EventArgs e)//Randevu Butonuna Tıklandığında
        {
            groupBoxAppointment.Visible = true; //groupBoxAppointment görünür yap
            groupBoxDoctor.Visible = false; //groupBoxDoctor görünürlüğü kapat
            groupBoxPatient.Visible = false; //groupBoxPatient.Visible görünürlüğü kapat
            groupBoxSecretary.Visible = false; //groupBoxSecretar görünürlüğü kapat
            dataGridViewAppointment.DataSource = appointment.GetAppointmentList(); // dataGridViewAppointment'e randevu bilgilerini göster.
            cmbBranch.Items.Clear(); //cmb temizleme
            cmbPatient.Items.Clear();//cmb temizleme
            cmbBranch.Items.AddRange(BranchControl.getBranchs().ToArray()); //seçilen branşa göre doktor gelmesi 
            cmbPatient.Items.AddRange(PatientController.getPatients().ToArray()); //hasta isimlerinin cmb de gözükmesi 
            dataGridViewAppointment.Visible = true; // dataGridViewAppointment i görünür yap.
            dataGridViewDoctor.Visible = false; //dataGridViewDoctor görünürlüğü kapat
            dataGridViewPatient.Visible = false;//dataGridViewPatient görünürlüğü kapat
            dataGridViewSecretary.Visible = false;//dataGridViewSecretary görünürlüğü kapat
            chart_branch.Visible = false; //istatikleri gizle
            chart_doctor.Visible = false; //istatikleri gizle

        }

        private void btnSecretary_Click(object sender, EventArgs e)//Sekreter Butonuna Tıklandığında
        {
            groupBoxAppointment.Visible = false; //groupBoxAppointment görünürlüğü kapat
            groupBoxDoctor.Visible = false; //groupBoxDoctor görünürlüğü kapat
            groupBoxPatient.Visible = false; //groupBoxPatient görünürlüğü kapat
            groupBoxSecretary.Visible = true;//groupBoxSecretary görünürlüğü aç
            dataGridViewSecretary.DataSource = secretary.GetSecretarysList();//dataGridViewSecretary sekreter bilgileri göster
            dataGridViewAppointment.Visible = false;//dataGridViewAppointment görünürlüğü kapat
            dataGridViewDoctor.Visible = false;//dataGridViewDoctor görünürlüğü kapat
            dataGridViewPatient.Visible = false;//dataGridViewPatient görünürlüğü kapat
            dataGridViewSecretary.Visible = true;//dataGridViewSecretary görünürlüğü aç
            chart_branch.Visible = false;//istatikleri gizle
            chart_doctor.Visible = false;//istatikleri gizle


        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)//Branş seçimine göre doktor combobox'ına ilgili doktorları yazar.
        {
            cBoxDoctor.Text = ""; 
            cBoxDoctor.Items.Clear();
            if (cmbBranch.SelectedItem != null)
            {
                cBoxDoctor.Items.AddRange(
                    doctor.getDoctorsByBranch(
                        ((Branch)cmbBranch.SelectedItem).BranchId).ToArray());
                cBoxDoctor.Enabled = true;
            }
        }

        private void btnAppointmentCreate_Click(object sender, EventArgs e) //Yeni RANDEVU oluşturma event'i
        {
            if (cmbBranch.SelectedItem != null && cBoxDoctor.SelectedItem != null &&
               cmbPatient.SelectedItem != null && cmbClock.SelectedItem != null &&
               dtDate.Value != null) //bilgiler boş değilse 
            {
                int branchId = ((Branch)cmbBranch.SelectedItem).BranchId; //id bilgileri alma
                int doctorId = ((Doctor)cBoxDoctor.SelectedItem).DoctorId;
                int patientId = ((Patient)cmbPatient.SelectedItem).PatientId;
                DateTime dateTime = dtDate.Value.Date + TimeSpan.Parse(cmbClock.SelectedItem.ToString());
                appointment.CreateAppointment(branchId, doctorId, patientId, secretarySession.SecretaryId, dateTime);
                MessageBox.Show("Randevu oluşturuldu.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                AppointmentFormClear();
            }
        }
       
       
        private void PatientFormClear() //Hasta formunu temizler
        {
            patientId = 0;
            txtPatientName.Text = "";
            txtPatientLastName.Text = "";
            txtPatientEmail.Text = "";
            txtPatientPhoneNumber.Text = "";
            dataGridViewPatient.DataSource = patient.GetPatientsList();
        }

        private void btnAppointmentDelete_Click(object sender, EventArgs e) //Randevu silme event'i
        {
            if (appointmentId > 0) //id sıfırdan büyükse 
            {
                DialogResult dialog = MessageBox.Show(appointmentId + " numaralı randevuyu iptal etmek istiyor musunuz?",
                    "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    if (appointment.DeleteAppointmentRecord(appointmentId))
                    {
                        MessageBox.Show(appointmentId + " numaralı randevu iptal edildi.", "Bilgi",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                        AppointmentFormClear();
                    }
                }
                else
                    MessageBox.Show("Randevu iptal etme işlemi iptal edildi.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("İptal etmek istediğiniz randevu için tablodan randevu seçiniz." +
                    "(Seçim işlemini randevu bilgisine çift tıklayarak yapabilirsiniz.)", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AppointmentFormClear() //Formu temizler.
        {
            cmbBranch.Text = "";
            cBoxDoctor.Text = "";
            cmbPatient.Text = "";
            dtDate.Value = DateTime.Today;
            appointmentId = 0;
            dataGridViewAppointment.DataSource = appointment.GetAppointmentList();
        }

       

        private void btnPatientSave_Click(object sender, EventArgs e) //Hasta Kaydetme
        {

            if (txtPatientName.Text != "" && txtPatientLastName.Text != "" &&
                txtPatientEmail.Text != "" && txtPatientPhoneNumber.Text != "")
            {

                if (patient.AddPatientRecord(txtPatientName.Text, txtPatientLastName.Text,
                    txtPatientPhoneNumber.Text, txtPatientEmail.Text))
                {
                    MessageBox.Show("Kayıt Başarılı");
                    PatientFormClear();
                }
            }
        }

        private void btnPatientUpdate_Click(object sender, EventArgs e)//Hasta Kayıt Güncelleme
        {
            if (txtPatientName.Text != "" && txtPatientLastName.Text != "" &&
                txtPatientEmail.Text != "" && txtPatientPhoneNumber.Text != "" && patientId > 0)
            {

                if (patient.UpdatePatientRecord(patientId, txtPatientName.Text,
                    txtPatientLastName.Text, txtPatientPhoneNumber.Text, txtPatientEmail.Text))
                {
                    MessageBox.Show("Güncelleme Başarılı");
                    PatientFormClear();
                }
            }
        }

        private void btnPatientDelete_Click(object sender, EventArgs e) //Hasta Kayıt Silme
        {
            if (patientId > 0)
            {
                DialogResult dialog = MessageBox.Show(patientId + " numaralı hastayı silmek istiyor musunuz?",
                    "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    if (patient.DeletePatientRecord(patientId))
                    {
                        MessageBox.Show(patientId + " numaralı hasta silindi.", "Bilgi",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PatientFormClear();
                    }
                }
                else
                    MessageBox.Show("Silme işlemi iptal edildi.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Silmek istediğiniz veri için tablodan hasta seçiniz." +
                    "(Seçim işlemini hasta bilgisine çift tıklayarak yapabilirsiniz.)", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridViewAppointment_CellContentClick(object sender, DataGridViewCellEventArgs e)//Randevu DGV işlemleri
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {

                if (dataGridViewAppointment.Rows[e.RowIndex].Cells[0].Value != null)
                {                  
                   appointmentId = Convert.ToInt32(dataGridViewAppointment.Rows[e.RowIndex].Cells[0].Value);
   
                }
            }
        }

        private void dataGridViewPatient_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)//HAsta DGV 2 kere tıklandığında texte yazdırma işlemleri
        {

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {

                if (dataGridViewPatient.Rows[e.RowIndex].Cells[0].Value != null)
                {                  
                    patientId = Convert.ToInt32(dataGridViewPatient.Rows[e.RowIndex].Cells[0].Value);
                    txtPatientName.Text = dataGridViewPatient.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtPatientLastName.Text = dataGridViewPatient.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtPatientPhoneNumber.Text = dataGridViewPatient.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtPatientEmail.Text = dataGridViewPatient.Rows[e.RowIndex].Cells[4].Value.ToString();
                    
                }
            }
        }

        private void dataGridViewSecretary_CellDoubleClick(object sender, DataGridViewCellEventArgs e)//DGW'da veriye çift tıklayınca txtbox'lara bilgiler yazılıyor.
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridViewSecretary.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    secretaryId = Convert.ToInt32(dataGridViewSecretary.Rows[e.RowIndex].Cells[0].Value);
                    txtSecreterName.Text = dataGridViewSecretary.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtSecreterLastName.Text = dataGridViewSecretary.Rows[e.RowIndex].Cells[2].Value.ToString();
                    txtSecreterPhoneNumber.Text = dataGridViewSecretary.Rows[e.RowIndex].Cells[3].Value.ToString();
                    txtSecreterPassword.Text = dataGridViewSecretary.Rows[e.RowIndex].Cells[4].Value.ToString();
                }
            }
        }

        private void dataGridViewDoctor_CellDoubleClick(object sender, DataGridViewCellEventArgs e) ///DGW'da veriye çift tıklayınca txtbox'lara bilgiler yazılıyor.
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridViewDoctor.Rows[e.RowIndex].Cells[0].Value != null)
                {
                    doctorId = Convert.ToInt32(dataGridViewDoctor.Rows[e.RowIndex].Cells[0].Value);
                    txtDoctorName.Text = dataGridViewDoctor.Rows[e.RowIndex].Cells[1].Value.ToString();
                    txtDoctorLastName.Text = dataGridViewDoctor.Rows[e.RowIndex].Cells[2].Value.ToString();
                    cmbDoctorBranch.SelectedItem = cmbDoctorBranch.Items[cmbDoctorBranch.FindStringExact(
                        dataGridViewDoctor.Rows[e.RowIndex].Cells[3].Value.ToString())];
                    txtDoctorPhoneNumber.Text = dataGridViewDoctor.Rows[e.RowIndex].Cells[4].Value.ToString();
                    txtDoctorPassword.Text = dataGridViewDoctor.Rows[e.RowIndex].Cells[5].Value.ToString();
                }
            }
        }

        private void btnDoctorSave_Click(object sender, EventArgs e) //Doktor kaydetme butonu 
        {
            if (txtDoctorName.Text != "" && txtDoctorLastName.Text != "" &&
               txtDoctorPhoneNumber.Text != "" && txtDoctorPassword.Text != "" && cmbDoctorBranch.SelectedItem != null)
            {
                int branchId = ((Branch)cmbDoctorBranch.SelectedItem).BranchId;

                if (doctor.AddDoctorRecord(txtDoctorName.Text, txtDoctorLastName.Text,
                    branchId, txtDoctorPhoneNumber.Text, txtDoctorPassword.Text))
                {
                    MessageBox.Show("Kayıt Başarılı");
                    DoctorFormClear();
                }
            }
        }

        private void btnDoctorUpdate_Click(object sender, EventArgs e) //doktor bilgileri güncelleme
        {
            if (txtDoctorName.Text != "" && txtDoctorLastName.Text != "" &&
              txtDoctorPhoneNumber.Text != "" && txtDoctorPassword.Text != "" && cmbDoctorBranch.SelectedItem != null && doctorId > 0)
            {
                int branchId = ((Branch)cmbDoctorBranch.SelectedItem).BranchId;

                if (doctor.UpdateDoctorRecord(doctorId, txtDoctorName.Text,
                    txtDoctorLastName.Text, branchId, txtDoctorPhoneNumber.Text, txtDoctorPassword.Text))
                {
                    MessageBox.Show("Güncelleme Başarılı");
                    DoctorFormClear();
                }
            }
        }

        private void btnDoctorDelete_Click(object sender, EventArgs e) // doktor silme 
        {
            if (doctorId > 0)
            {
                DialogResult dialog = MessageBox.Show(doctorId + " numaralı doktoru silmek istiyor musunuz?",
                    "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    if (doctor.DeleteDoctorRecord(doctorId))
                    {
                        MessageBox.Show(doctorId + " numaralı doktor silindi.", "Bilgi",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DoctorFormClear();
                    }
                }
                else
                    MessageBox.Show("Silme işlemi iptal edildi.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Silmek istediğiniz veri için tablodan doktor seçiniz." +
                    "(Seçim işlemini doktor bilgisine çift tıklayarak yapabilirsiniz.)", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DoctorFormClear() //Formu temizler
        {
            doctorId = 0;
            txtDoctorName.Text = "";
            txtDoctorLastName.Text = "";
            txtDoctorPhoneNumber.Text = "";
            txtDoctorPassword.Text = "";
            cmbDoctorBranch.Text = "";
            dataGridViewDoctor.DataSource = doctor.GetDoktorsList();
        }

        private void btnSecreterSave_Click(object sender, EventArgs e) //sekreter kaydetme 
        {
            if (txtSecreterName.Text != "" && txtSecreterLastName.Text != "" &&
                txtSecreterPhoneNumber.Text != "")
            {

                if (secretary.AddSecretaryRecord(txtSecreterName.Text, txtSecreterLastName.Text,
                    txtSecreterPhoneNumber.Text, txtSecreterPassword.Text))
                {
                    MessageBox.Show("Kayıt Başarılı");
                    SecretaryFormClear();
                }
            }
        }

        private void btnSecreterUpdate_Click(object sender, EventArgs e)//sekreter güncelleme 
        {
            if (txtSecreterName.Text != "" && txtSecreterLastName.Text != "" &&
                txtSecreterPhoneNumber.Text != "" && txtSecreterPhoneNumber.Text != "" && secretaryId > 0)
            {

                if (secretary.UpdateSecretaryRecord(secretaryId, txtSecreterName.Text,
                    txtSecreterLastName.Text, txtSecreterPhoneNumber.Text, txtSecreterPhoneNumber.Text))
                {
                    MessageBox.Show("Güncelleme Başarılı");
                    SecretaryFormClear();
                }
            }
        }

        private void btnSecreterDelete_Click(object sender, EventArgs e) //sekreter silme 
        {
            if (secretaryId > 0)
            {
                DialogResult dialog = MessageBox.Show(secretaryId + " numaralı sekreteri silmek istiyor musunuz?",
                    "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    if (secretary.DeleteSecretaryRecord(secretaryId))
                    {
                        MessageBox.Show(secretaryId + " numaralı sekreter silindi.", "Bilgi",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);
                        SecretaryFormClear();
                    }
                }
                else
                    MessageBox.Show("Silme işlemi iptal edildi.", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Silmek istediğiniz veri için tablodan sekreter seçiniz." +
                    "(Seçim işlemini sekreter bilgisine çift tıklayarak yapabilirsiniz.)", "Bilgi",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void SecretaryFormClear() //Formu temizler
        {
            secretaryId = 0;
            txtSecreterName.Text = "";
            txtSecreterLastName.Text = "";
            txtSecreterPhoneNumber.Text = "";
            txtSecreterPassword.Text = "";
            dataGridViewSecretary.DataSource = secretary.GetSecretarysList();
        }

        private void btnPatient_Click(object sender, EventArgs e)//Hasta Butonuna Tıklandığında
        {
            groupBoxAppointment.Visible = false;
            groupBoxDoctor.Visible = false;
            groupBoxPatient.Visible = true;
            groupBoxSecretary.Visible = false;
            dataGridViewPatient.DataSource = patient.GetPatientsList();
            dataGridViewAppointment.Visible = false;
            dataGridViewDoctor.Visible = false;
            dataGridViewPatient.Visible = true;
            dataGridViewSecretary.Visible = false;
            chart_branch.Visible = false;
            chart_doctor.Visible = false;

        }

        private void button5_Click(object sender, EventArgs e) //istatikleri gösterme butonu 
        {
            GetStatistic();
            groupBoxAppointment.Visible = false;
            groupBoxDoctor.Visible = false;
            groupBoxPatient.Visible = false;
            groupBoxSecretary.Visible = false;
            dataGridViewAppointment.Visible = false;
            dataGridViewDoctor.Visible = false;
            dataGridViewPatient.Visible = false;
            dataGridViewSecretary.Visible = false;
            chart_branch.Visible = true;
            chart_doctor.Visible = true;
        }


        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnDoctor_Click(object sender, EventArgs e) //Doktor Butonuna Tıklandığında 
        {
            groupBoxAppointment.Visible = false;
            groupBoxDoctor.Visible = true;
            groupBoxPatient.Visible = false;
            groupBoxSecretary.Visible = false;
            dataGridViewDoctor.DataSource = doctor.GetDoktorsList(); //Controller aracılığıyla Doktor tablsou DGW'a yazdırılıyor.
            cmbDoctorBranch.Items.Clear();
            cmbDoctorBranch.Items.AddRange(BranchControl.getBranchs().ToArray());
            dataGridViewAppointment.Visible = false;
            dataGridViewDoctor.Visible = true;
            dataGridViewPatient.Visible = false;
            dataGridViewSecretary.Visible = false;
            chart_branch.Visible = false;
            chart_doctor.Visible = false;
        }

        private void Sekreter_Load(object sender, EventArgs e) //Form yüklenirken çalışanlar 
        {
            secretary = new SecretaryControl(); //Sekreter için controller oluşturuluyor.
            patient = new PatientController(); //Hasta için controller oluşturuluyor.
            appointment = new AppointmentController(); //Randevu için controller oluşturuluyor.
            dataGridViewAppointment.DataSource = appointment.GetAppointmentList();
            doctor = new DoctorControl(); //Doktor için controller oluşturuluyor.
            groupBoxAppointment.Visible = true;
            dataGridViewAppointment.Visible = true;
            dtDate.MinDate = DateTime.Today; //DateTime öğesi için seçilebilecek ilk tarih
                                             //bugünden itibaren olacak şekilde ayarlanıyor.
            cmbBranch.Items.AddRange(BranchControl.getBranchs().ToArray());
            cmbPatient.Items.AddRange(PatientController.getPatients().ToArray());
            secretarySession = secretary.GetSecretarySession();//oturum açan sekreter bilgisi alındı.
            this.Text += " - " + secretarySession.Name + " " +
                secretarySession.LastName;//sekreter ismi form başlığına yazıldı.
        }

         private void GetStatistic() // istatik bilgileri 
        {
            chart_branch.DataSource = secretary.GetNumberofPatientsbyBranch();
            chart_branch.Series[0].XValueMember = "Branch";
            chart_branch.Series[0].YValueMembers = "Count";
            chart_branch.Invalidate();

            chart_doctor.DataSource = secretary.GetNumberofPatientsbyDoctor();
            chart_doctor.Series[0].XValueMember = "Doktor Adı";
            chart_doctor.Series[0].YValueMembers = "Count";
            chart_doctor.Invalidate();


        }
    }
}
