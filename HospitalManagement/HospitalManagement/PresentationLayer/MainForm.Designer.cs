namespace HospitalManagement.PresentationLayer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnSecretary = new System.Windows.Forms.Button();
            this.btnDoctor = new System.Windows.Forms.Button();
            this.grpAuth = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.grpAuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSecretary
            // 
            this.btnSecretary.Location = new System.Drawing.Point(51, 63);
            this.btnSecretary.Name = "btnSecretary";
            this.btnSecretary.Size = new System.Drawing.Size(314, 105);
            this.btnSecretary.TabIndex = 7;
            this.btnSecretary.Text = "SEKRETER";
            this.btnSecretary.UseVisualStyleBackColor = true;
            this.btnSecretary.Click += new System.EventHandler(this.btnSecretary_Click);
            // 
            // btnDoctor
            // 
            this.btnDoctor.Location = new System.Drawing.Point(51, 205);
            this.btnDoctor.Name = "btnDoctor";
            this.btnDoctor.Size = new System.Drawing.Size(314, 95);
            this.btnDoctor.TabIndex = 8;
            this.btnDoctor.Text = "DOKTOR";
            this.btnDoctor.UseVisualStyleBackColor = true;
            this.btnDoctor.Click += new System.EventHandler(this.btnDoctor_Click);
            // 
            // grpAuth
            // 
            this.grpAuth.Controls.Add(this.btnLogin);
            this.grpAuth.Controls.Add(this.txtPhoneNumber);
            this.grpAuth.Controls.Add(this.txtPassword);
            this.grpAuth.Controls.Add(this.label6);
            this.grpAuth.Controls.Add(this.label5);
            this.grpAuth.Controls.Add(this.label4);
            this.grpAuth.Location = new System.Drawing.Point(35, 46);
            this.grpAuth.Name = "grpAuth";
            this.grpAuth.Size = new System.Drawing.Size(367, 293);
            this.grpAuth.TabIndex = 10;
            this.grpAuth.TabStop = false;
            this.grpAuth.Text = "Kullanıcı Giriş ";
            this.grpAuth.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "KULLANICI GİRİŞİ ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Telefon Numarası ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Şifre";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(147, 132);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(144, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Location = new System.Drawing.Point(152, 83);
            this.txtPhoneNumber.Mask = "(999) 000-0000";
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(136, 20);
            this.txtPhoneNumber.TabIndex = 4;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(88, 185);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(176, 38);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "OTURUM AÇ ";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 399);
            this.Controls.Add(this.grpAuth);
            this.Controls.Add(this.btnDoctor);
            this.Controls.Add(this.btnSecretary);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Hastane Randevu Sistemi";
            this.grpAuth.ResumeLayout(false);
            this.grpAuth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSecretary;
        private System.Windows.Forms.Button btnDoctor;
        private System.Windows.Forms.GroupBox grpAuth;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.MaskedTextBox txtPhoneNumber;
        private System.Windows.Forms.TextBox txtPassword;
    }
}