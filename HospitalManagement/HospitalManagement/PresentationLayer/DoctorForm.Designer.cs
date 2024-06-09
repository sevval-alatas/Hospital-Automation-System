namespace HospitalManagement.PresentationLayer
{
    partial class DoctorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoctorForm));
            this.dtGVAppointmentDetails = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPatientPhone = new System.Windows.Forms.MaskedTextBox();
            this.txtPatientDate = new System.Windows.Forms.TextBox();
            this.txtPatientEmail = new System.Windows.Forms.TextBox();
            this.txtPatientLastName = new System.Windows.Forms.TextBox();
            this.txtPatientName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPatientNote = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnMail = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dtGVAppointmentDetails)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGVAppointmentDetails
            // 
            this.dtGVAppointmentDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGVAppointmentDetails.Location = new System.Drawing.Point(12, 12);
            this.dtGVAppointmentDetails.Name = "dtGVAppointmentDetails";
            this.dtGVAppointmentDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGVAppointmentDetails.Size = new System.Drawing.Size(442, 150);
            this.dtGVAppointmentDetails.TabIndex = 0;
            this.dtGVAppointmentDetails.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVAppointmentDetails_CellContentClick);
            this.dtGVAppointmentDetails.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGVAppointmentDetails_CellContentDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPatientPhone);
            this.groupBox1.Controls.Add(this.txtPatientDate);
            this.groupBox1.Controls.Add(this.txtPatientEmail);
            this.groupBox1.Controls.Add(this.txtPatientLastName);
            this.groupBox1.Controls.Add(this.txtPatientName);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(292, 322);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hasta Bilgileri";
            // 
            // txtPatientPhone
            // 
            this.txtPatientPhone.Enabled = false;
            this.txtPatientPhone.Location = new System.Drawing.Point(129, 140);
            this.txtPatientPhone.Mask = "(999) 000-0000";
            this.txtPatientPhone.Name = "txtPatientPhone";
            this.txtPatientPhone.Size = new System.Drawing.Size(100, 20);
            this.txtPatientPhone.TabIndex = 10;
            // 
            // txtPatientDate
            // 
            this.txtPatientDate.Enabled = false;
            this.txtPatientDate.Location = new System.Drawing.Point(129, 231);
            this.txtPatientDate.Name = "txtPatientDate";
            this.txtPatientDate.Size = new System.Drawing.Size(100, 20);
            this.txtPatientDate.TabIndex = 9;
            // 
            // txtPatientEmail
            // 
            this.txtPatientEmail.Enabled = false;
            this.txtPatientEmail.Location = new System.Drawing.Point(129, 184);
            this.txtPatientEmail.Name = "txtPatientEmail";
            this.txtPatientEmail.Size = new System.Drawing.Size(100, 20);
            this.txtPatientEmail.TabIndex = 8;
            // 
            // txtPatientLastName
            // 
            this.txtPatientLastName.Enabled = false;
            this.txtPatientLastName.Location = new System.Drawing.Point(129, 93);
            this.txtPatientLastName.Name = "txtPatientLastName";
            this.txtPatientLastName.Size = new System.Drawing.Size(100, 20);
            this.txtPatientLastName.TabIndex = 6;
            // 
            // txtPatientName
            // 
            this.txtPatientName.Enabled = false;
            this.txtPatientName.Location = new System.Drawing.Point(129, 43);
            this.txtPatientName.Name = "txtPatientName";
            this.txtPatientName.Size = new System.Drawing.Size(100, 20);
            this.txtPatientName.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Kayıt Tarihi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "E-posta Adresi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Telefon Numarsı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasta Soyadı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hasta Adı";
            // 
            // txtPatientNote
            // 
            this.txtPatientNote.Location = new System.Drawing.Point(346, 230);
            this.txtPatientNote.Name = "txtPatientNote";
            this.txtPatientNote.Size = new System.Drawing.Size(472, 276);
            this.txtPatientNote.TabIndex = 2;
            this.txtPatientNote.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(343, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Doktor Görüşleri";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(472, 38);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(126, 47);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "KAYDET";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(565, 103);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(126, 44);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "PDF";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnMail
            // 
            this.btnMail.Location = new System.Drawing.Point(670, 41);
            this.btnMail.Name = "btnMail";
            this.btnMail.Size = new System.Drawing.Size(126, 44);
            this.btnMail.TabIndex = 6;
            this.btnMail.Text = "E-MAİL GÖNDER";
            this.btnMail.UseVisualStyleBackColor = true;
            this.btnMail.Click += new System.EventHandler(this.btnMail_Click);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Text = "Baskı önizleme";
            this.printPreviewDialog1.Visible = false;
            // 
            // DoctorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 543);
            this.Controls.Add(this.btnMail);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPatientNote);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtGVAppointmentDetails);
            this.Name = "DoctorForm";
            this.Text = "Doctor Ekranı ";
            this.Load += new System.EventHandler(this.DoctorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGVAppointmentDetails)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGVAppointmentDetails;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtPatientPhone;
        private System.Windows.Forms.TextBox txtPatientDate;
        private System.Windows.Forms.TextBox txtPatientEmail;
        private System.Windows.Forms.TextBox txtPatientLastName;
        private System.Windows.Forms.TextBox txtPatientName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox txtPatientNote;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnMail;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}