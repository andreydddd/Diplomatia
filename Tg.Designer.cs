namespace Diplomatia
{
    partial class Tg
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
            this.SendButton = new Guna.UI2.WinForms.Guna2Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SendButton2 = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.AutoRoundedCorners = true;
            this.SendButton.BorderRadius = 36;
            this.SendButton.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SendButton.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SendButton.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SendButton.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SendButton.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SendButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SendButton.ForeColor = System.Drawing.Color.White;
            this.SendButton.Location = new System.Drawing.Point(12, 301);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(181, 74);
            this.SendButton.TabIndex = 0;
            this.SendButton.Text = "как дела";
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Items.AddRange(new object[] {
            "Здравствуй"});
            this.listBox1.Location = new System.Drawing.Point(12, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(360, 251);
            this.listBox1.TabIndex = 1;
            // 
            // SendButton2
            // 
            this.SendButton2.AutoRoundedCorners = true;
            this.SendButton2.BorderRadius = 36;
            this.SendButton2.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.SendButton2.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.SendButton2.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.SendButton2.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.SendButton2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.SendButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SendButton2.ForeColor = System.Drawing.Color.White;
            this.SendButton2.Location = new System.Drawing.Point(217, 301);
            this.SendButton2.Name = "SendButton2";
            this.SendButton2.Size = new System.Drawing.Size(181, 74);
            this.SendButton2.TabIndex = 2;
            this.SendButton2.Text = "чо делаешь";
            this.SendButton2.Click += new System.EventHandler(this.SendButton2_Click);
            // 
            // Tg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(136)))), ((int)(((byte)(130)))));
            this.ClientSize = new System.Drawing.Size(410, 450);
            this.Controls.Add(this.SendButton2);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.SendButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Tg";
            this.Text = "Tg";
            this.Load += new System.EventHandler(this.Tg_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Button SendButton;
        private System.Windows.Forms.ListBox listBox1;
        private Guna.UI2.WinForms.Guna2Button SendButton2;
    }
}