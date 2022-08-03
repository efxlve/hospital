namespace Project_Hospital
{
    partial class frmMain
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pbPatient = new System.Windows.Forms.PictureBox();
            this.pbDoctor = new System.Windows.Forms.PictureBox();
            this.pbSecretary = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbPatient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDoctor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecretary)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(189, 379);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Patient";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(346, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Doctor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(493, 379);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Secretary";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.ForeColor = System.Drawing.Color.DarkViolet;
            this.label4.Location = new System.Drawing.Point(78, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(604, 39);
            this.label4.TabIndex = 7;
            this.label4.Text = "Hospital Management and Appointment System";
            // 
            // pbPatient
            // 
            this.pbPatient.BackColor = System.Drawing.Color.Transparent;
            this.pbPatient.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbPatient.Image = global::Project_Hospital.Properties.Resources.icons8_fever_96px;
            this.pbPatient.Location = new System.Drawing.Point(147, 226);
            this.pbPatient.Name = "pbPatient";
            this.pbPatient.Size = new System.Drawing.Size(150, 150);
            this.pbPatient.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbPatient.TabIndex = 8;
            this.pbPatient.TabStop = false;
            this.pbPatient.Click += new System.EventHandler(this.pbPatient_Click);
            // 
            // pbDoctor
            // 
            this.pbDoctor.BackColor = System.Drawing.Color.Transparent;
            this.pbDoctor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbDoctor.Image = global::Project_Hospital.Properties.Resources.icons8_doctor_female_200px;
            this.pbDoctor.Location = new System.Drawing.Point(303, 226);
            this.pbDoctor.Name = "pbDoctor";
            this.pbDoctor.Size = new System.Drawing.Size(150, 150);
            this.pbDoctor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbDoctor.TabIndex = 9;
            this.pbDoctor.TabStop = false;
            this.pbDoctor.Click += new System.EventHandler(this.pbDoctor_Click);
            // 
            // pbSecretary
            // 
            this.pbSecretary.BackColor = System.Drawing.Color.Transparent;
            this.pbSecretary.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbSecretary.Image = global::Project_Hospital.Properties.Resources.icons8_technical_support_200px;
            this.pbSecretary.Location = new System.Drawing.Point(459, 226);
            this.pbSecretary.Name = "pbSecretary";
            this.pbSecretary.Size = new System.Drawing.Size(150, 150);
            this.pbSecretary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbSecretary.TabIndex = 10;
            this.pbSecretary.TabStop = false;
            this.pbSecretary.Click += new System.EventHandler(this.pbSecretary_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImage = global::Project_Hospital.Properties.Resources.purple_white_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(760, 537);
            this.Controls.Add(this.pbSecretary);
            this.Controls.Add(this.pbDoctor);
            this.Controls.Add(this.pbPatient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Management and Appointment System";
            ((System.ComponentModel.ISupportInitialize)(this.pbPatient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbDoctor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSecretary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pbPatient;
        private System.Windows.Forms.PictureBox pbDoctor;
        private System.Windows.Forms.PictureBox pbSecretary;
    }
}

