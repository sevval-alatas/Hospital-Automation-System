﻿using HospitalManagement.DataLayer;
using System;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;

namespace HospitalManagement.BusinnesLayer
{
    class AppointmentDetailsController
    {
        public DataTable GetAppointmentListbyDoctor(int doctorId) //Randevu Detay tablosunu geriye döndürür
        {
            try
            {
                OleDbCommand sqlCommand = Database.SqlCommand(
                    "SELECT " +
                    "Appointment.AppointmentId AS [Randevu ID]," +
                    "Patient.PName & ' ' & Patient.PLastName AS [Hasta Adı]," +
                    "Appointment.DateTime AS[Randevu Zamanı] " +
                    "FROM(Appointment " +
                    "INNER JOIN Patient ON Appointment.PatientId = Patient.PatientId)" +
                    "WHERE Appointment.DoctorId = @DoctorId");
                sqlCommand.Parameters.AddWithValue("@DoctorId", doctorId);
                DataTable table = new DataTable();
                table.Load(sqlCommand.ExecuteReader());
                return table;
            }
            catch (OleDbException exception)
            {
                System.Windows.Forms.MessageBox.Show("Hata :" + exception.Message);
                return null;
            }
        }

        public Patient GetPatientInfoByAppointmentId(int appointmentId) //randevu ID'sine göre hasta tipinde veri geriye döndürür.
        {
            try
            {
                OleDbCommand sqlCommand = Database.SqlCommand(
                    "SELECT * FROM(Patient " +
                    "INNER JOIN Appointment ON Appointment.PatientId = Patient.PatientId)" +
                    "WHERE Appointment.AppointmentId = @AppointmentId");
                sqlCommand.Parameters.AddWithValue("@AppointmentId", appointmentId);
                OleDbDataReader dataReader = sqlCommand.ExecuteReader();
                dataReader.Read();
                Patient patient = new Patient(
                    Convert.ToInt32(dataReader[0]),
                    dataReader[1].ToString(),
                    dataReader[2].ToString(),
                    dataReader[3].ToString(),
                    dataReader[4].ToString(),
                    DateTime.Parse(dataReader[5].ToString()));
                dataReader.Close();
                return patient;
            }
            catch (OleDbException exception)
            {
                System.Windows.Forms.MessageBox.Show("Hata :" + exception.Message);
                return null;
            }
        }

        public bool AddAppointmentNote(int appointmentId, string note) //yeni randevu notu ekleme methodu
        {
            try
            {
                OleDbCommand sqlCommand = Database.SqlCommand("SELECT * FROM PatientRecord WHERE AppointmentId = @AppointmentId");
                sqlCommand.Parameters.AddWithValue("@AppointmentId", appointmentId);
                OleDbDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    OleDbCommand sqlCommand3 = Database.SqlCommand(
                        "UPDATE PatientRecord SET [Note] = @Note WHERE AppointmentId = @AppointmentId");
                    sqlCommand3.Parameters.AddWithValue("@Note", note);
                    sqlCommand3.Parameters.AddWithValue("@AppointmentId", appointmentId);
                    if (sqlCommand3.ExecuteNonQuery() > 0)
                        return true;
                }
                else
                {
                    OleDbCommand sqlCommand2 = Database.SqlCommand(
                        "INSERT INTO PatientRecord (AppointmentId, [Note]) " +
                        "VALUES (@AppointmentId, @Note)");
                    sqlCommand2.Parameters.AddWithValue("@AppointmentId", appointmentId);
                    sqlCommand2.Parameters.AddWithValue("@Note", note);
                    if (sqlCommand2.ExecuteNonQuery() > 0)
                        return true;
                }
            }
            catch (OleDbException exception)
            {
                System.Windows.Forms.MessageBox.Show("Hata :" + exception.Message);
                return false;
            }
            return false;
        }

        public PatientRecord GetAppointmentNoteByAppointmentId(int appointmentId) //randevu notlarını, randevu ID'sine göre geriye döndürür.
        {
            try
            {
                OleDbCommand sqlCommand = Database.SqlCommand(
                    "SELECT * FROM PatientRecord " +
                    "WHERE AppointmentId = @AppointmentId");
                sqlCommand.Parameters.AddWithValue("@AppointmentId", appointmentId);
                OleDbDataReader dataReader = sqlCommand.ExecuteReader();
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    PatientRecord patient = new PatientRecord(
                        Convert.ToInt32(dataReader[0]),
                        Convert.ToInt32(dataReader[1]),
                        dataReader[2].ToString());
                    dataReader.Close();
                    return patient;
                }
                else
                {
                    PatientRecord nullpatient = new PatientRecord(0, 0, "");
                    return nullpatient;
                }

            }
            catch (OleDbException exception)
            {
                System.Windows.Forms.MessageBox.Show("Hata :" + exception.Message);
                return null;
            }
        }
    }
}
