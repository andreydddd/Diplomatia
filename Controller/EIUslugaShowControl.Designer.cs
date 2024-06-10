namespace Diplomatia.Controller
{
    partial class EIUslugaShowControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelName = new System.Windows.Forms.Label();
            this.guna2GradientButtonShowUsluga = new Guna.UI2.WinForms.Guna2GradientButton();
            this.labelDiskr = new System.Windows.Forms.Label();
            this.guna2PictureBoxUslugi = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBoxUslugi)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelName.ForeColor = System.Drawing.Color.White;
            this.labelName.Location = new System.Drawing.Point(148, 42);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(0, 24);
            this.labelName.TabIndex = 19;
            // 
            // guna2GradientButtonShowUsluga
            // 
            this.guna2GradientButtonShowUsluga.AutoRoundedCorners = true;
            this.guna2GradientButtonShowUsluga.BorderRadius = 28;
            this.guna2GradientButtonShowUsluga.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButtonShowUsluga.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2GradientButtonShowUsluga.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButtonShowUsluga.DisabledState.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2GradientButtonShowUsluga.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2GradientButtonShowUsluga.FillColor = System.Drawing.Color.DarkGreen;
            this.guna2GradientButtonShowUsluga.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientButtonShowUsluga.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientButtonShowUsluga.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Bold);
            this.guna2GradientButtonShowUsluga.ForeColor = System.Drawing.Color.White;
            this.guna2GradientButtonShowUsluga.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.guna2GradientButtonShowUsluga.Location = new System.Drawing.Point(778, 15);
            this.guna2GradientButtonShowUsluga.Name = "guna2GradientButtonShowUsluga";
            this.guna2GradientButtonShowUsluga.Size = new System.Drawing.Size(140, 58);
            this.guna2GradientButtonShowUsluga.TabIndex = 21;
            this.guna2GradientButtonShowUsluga.Text = "Перейти";
            this.guna2GradientButtonShowUsluga.Click += new System.EventHandler(this.guna2GradientButton1_Click);
            // 
            // labelDiskr
            // 
            this.labelDiskr.AutoSize = true;
            this.labelDiskr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelDiskr.ForeColor = System.Drawing.Color.White;
            this.labelDiskr.Location = new System.Drawing.Point(573, 42);
            this.labelDiskr.Name = "labelDiskr";
            this.labelDiskr.Size = new System.Drawing.Size(0, 24);
            this.labelDiskr.TabIndex = 22;
            // 
            // guna2PictureBoxUslugi
            // 
            this.guna2PictureBoxUslugi.BackColor = System.Drawing.Color.Transparent;
            this.guna2PictureBoxUslugi.BorderRadius = 15;
            this.guna2PictureBoxUslugi.ImageRotate = 0F;
            this.guna2PictureBoxUslugi.Location = new System.Drawing.Point(23, 14);
            this.guna2PictureBoxUslugi.Name = "guna2PictureBoxUslugi";
            this.guna2PictureBoxUslugi.Size = new System.Drawing.Size(100, 67);
            this.guna2PictureBoxUslugi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBoxUslugi.TabIndex = 0;
            this.guna2PictureBoxUslugi.TabStop = false;
            this.guna2PictureBoxUslugi.UseTransparentBackground = true;
            // 
            // EIUslugaShowControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.Controls.Add(this.labelDiskr);
            this.Controls.Add(this.guna2GradientButtonShowUsluga);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.guna2PictureBoxUslugi);
            this.Name = "EIUslugaShowControl";
            this.Size = new System.Drawing.Size(949, 88);
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBoxUslugi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label labelName;
        public System.Windows.Forms.Label labelDiskr;
        public Guna.UI2.WinForms.Guna2PictureBox guna2PictureBoxUslugi;
        public Guna.UI2.WinForms.Guna2GradientButton guna2GradientButtonShowUsluga;
    }
}
