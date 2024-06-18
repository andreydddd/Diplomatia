namespace Diplomatia.Controller
{
    partial class EIUserControl
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
            this.components = new System.ComponentModel.Container();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.guna2GradientPanel1 = new Guna.UI2.WinForms.Guna2GradientPanel();
            this.gunaName = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gunaNomer = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gunaDateStart = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gunaDateEnd = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gunaCount = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.gunaPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2GradientPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2Elipse1
            // 
            this.guna2Elipse1.BorderRadius = 40;
            this.guna2Elipse1.TargetControl = this;
            // 
            // guna2GradientPanel1
            // 
            this.guna2GradientPanel1.Controls.Add(this.gunaPrice);
            this.guna2GradientPanel1.Controls.Add(this.gunaCount);
            this.guna2GradientPanel1.Controls.Add(this.gunaDateEnd);
            this.guna2GradientPanel1.Controls.Add(this.gunaDateStart);
            this.guna2GradientPanel1.Controls.Add(this.gunaNomer);
            this.guna2GradientPanel1.Controls.Add(this.gunaName);
            this.guna2GradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.guna2GradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.guna2GradientPanel1.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.guna2GradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2GradientPanel1.Name = "guna2GradientPanel1";
            this.guna2GradientPanel1.Size = new System.Drawing.Size(722, 69);
            this.guna2GradientPanel1.TabIndex = 0;
            // 
            // gunaName
            // 
            this.gunaName.BackColor = System.Drawing.Color.Transparent;
            this.gunaName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gunaName.ForeColor = System.Drawing.Color.White;
            this.gunaName.Location = new System.Drawing.Point(17, 25);
            this.gunaName.Name = "gunaName";
            this.gunaName.Size = new System.Drawing.Size(3, 2);
            this.gunaName.TabIndex = 0;
            // 
            // gunaNomer
            // 
            this.gunaNomer.BackColor = System.Drawing.Color.Transparent;
            this.gunaNomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gunaNomer.ForeColor = System.Drawing.Color.White;
            this.gunaNomer.Location = new System.Drawing.Point(114, 25);
            this.gunaNomer.Name = "gunaNomer";
            this.gunaNomer.Size = new System.Drawing.Size(3, 2);
            this.gunaNomer.TabIndex = 1;
            // 
            // gunaDateStart
            // 
            this.gunaDateStart.BackColor = System.Drawing.Color.Transparent;
            this.gunaDateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gunaDateStart.ForeColor = System.Drawing.Color.White;
            this.gunaDateStart.Location = new System.Drawing.Point(263, 25);
            this.gunaDateStart.Name = "gunaDateStart";
            this.gunaDateStart.Size = new System.Drawing.Size(3, 2);
            this.gunaDateStart.TabIndex = 2;
            // 
            // gunaDateEnd
            // 
            this.gunaDateEnd.BackColor = System.Drawing.Color.Transparent;
            this.gunaDateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gunaDateEnd.ForeColor = System.Drawing.Color.White;
            this.gunaDateEnd.Location = new System.Drawing.Point(402, 25);
            this.gunaDateEnd.Name = "gunaDateEnd";
            this.gunaDateEnd.Size = new System.Drawing.Size(3, 2);
            this.gunaDateEnd.TabIndex = 3;
            // 
            // gunaCount
            // 
            this.gunaCount.BackColor = System.Drawing.Color.Transparent;
            this.gunaCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gunaCount.ForeColor = System.Drawing.Color.White;
            this.gunaCount.Location = new System.Drawing.Point(557, 25);
            this.gunaCount.Name = "gunaCount";
            this.gunaCount.Size = new System.Drawing.Size(3, 2);
            this.gunaCount.TabIndex = 4;
            // 
            // gunaPrice
            // 
            this.gunaPrice.BackColor = System.Drawing.Color.Transparent;
            this.gunaPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gunaPrice.ForeColor = System.Drawing.Color.White;
            this.gunaPrice.Location = new System.Drawing.Point(648, 25);
            this.gunaPrice.Name = "gunaPrice";
            this.gunaPrice.Size = new System.Drawing.Size(3, 2);
            this.gunaPrice.TabIndex = 5;
            // 
            // EIUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.Controls.Add(this.guna2GradientPanel1);
            this.Name = "EIUserControl";
            this.Size = new System.Drawing.Size(722, 69);
            this.guna2GradientPanel1.ResumeLayout(false);
            this.guna2GradientPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Guna.UI2.WinForms.Guna2GradientPanel guna2GradientPanel1;
        public Guna.UI2.WinForms.Guna2HtmlLabel gunaPrice;
        public Guna.UI2.WinForms.Guna2HtmlLabel gunaCount;
        public Guna.UI2.WinForms.Guna2HtmlLabel gunaDateEnd;
        public Guna.UI2.WinForms.Guna2HtmlLabel gunaDateStart;
        public Guna.UI2.WinForms.Guna2HtmlLabel gunaNomer;
        public Guna.UI2.WinForms.Guna2HtmlLabel gunaName;
    }
}
