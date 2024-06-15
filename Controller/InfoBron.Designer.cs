namespace Diplomatia.Controller
{
    partial class InfoBron
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
            this.LabelFio = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labelNomer = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labeldateStart = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labeldateEnd = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labelCountChel = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.labelPrice = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.SuspendLayout();
            // 
            // LabelFio
            // 
            this.LabelFio.AutoSize = false;
            this.LabelFio.BackColor = System.Drawing.Color.Transparent;
            this.LabelFio.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelFio.ForeColor = System.Drawing.Color.White;
            this.LabelFio.Location = new System.Drawing.Point(266, 43);
            this.LabelFio.Name = "LabelFio";
            this.LabelFio.Size = new System.Drawing.Size(214, 65);
            this.LabelFio.TabIndex = 0;
            this.LabelFio.Text = "ФИО";
            // 
            // labelNomer
            // 
            this.labelNomer.BackColor = System.Drawing.Color.Transparent;
            this.labelNomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNomer.ForeColor = System.Drawing.Color.White;
            this.labelNomer.Location = new System.Drawing.Point(8, 45);
            this.labelNomer.Name = "labelNomer";
            this.labelNomer.Size = new System.Drawing.Size(225, 31);
            this.labelNomer.TabIndex = 1;
            this.labelNomer.Text = "Название номера";
            // 
            // labeldateStart
            // 
            this.labeldateStart.BackColor = System.Drawing.Color.Transparent;
            this.labeldateStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labeldateStart.ForeColor = System.Drawing.Color.White;
            this.labeldateStart.Location = new System.Drawing.Point(528, 43);
            this.labeldateStart.Name = "labeldateStart";
            this.labeldateStart.Size = new System.Drawing.Size(156, 31);
            this.labeldateStart.TabIndex = 2;
            this.labeldateStart.Text = "дата начало";
            // 
            // labeldateEnd
            // 
            this.labeldateEnd.BackColor = System.Drawing.Color.Transparent;
            this.labeldateEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labeldateEnd.ForeColor = System.Drawing.Color.White;
            this.labeldateEnd.Location = new System.Drawing.Point(766, 43);
            this.labeldateEnd.Name = "labeldateEnd";
            this.labeldateEnd.Size = new System.Drawing.Size(141, 31);
            this.labeldateEnd.TabIndex = 3;
            this.labeldateEnd.Text = "дата конец";
            // 
            // labelCountChel
            // 
            this.labelCountChel.BackColor = System.Drawing.Color.Transparent;
            this.labelCountChel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCountChel.ForeColor = System.Drawing.Color.White;
            this.labelCountChel.Location = new System.Drawing.Point(29, 108);
            this.labelCountChel.Name = "labelCountChel";
            this.labelCountChel.Size = new System.Drawing.Size(148, 31);
            this.labelCountChel.TabIndex = 4;
            this.labelCountChel.Text = "количество";
            // 
            // labelPrice
            // 
            this.labelPrice.BackColor = System.Drawing.Color.Transparent;
            this.labelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPrice.ForeColor = System.Drawing.Color.White;
            this.labelPrice.Location = new System.Drawing.Point(188, 108);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(64, 31);
            this.labelPrice.TabIndex = 5;
            this.labelPrice.Text = "цена";
            // 
            // InfoBron
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(33)))), ((int)(((byte)(43)))));
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelCountChel);
            this.Controls.Add(this.labeldateEnd);
            this.Controls.Add(this.labeldateStart);
            this.Controls.Add(this.labelNomer);
            this.Controls.Add(this.LabelFio);
            this.Name = "InfoBron";
            this.Size = new System.Drawing.Size(996, 514);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public Guna.UI2.WinForms.Guna2HtmlLabel LabelFio;
        public Guna.UI2.WinForms.Guna2HtmlLabel labelNomer;
        public Guna.UI2.WinForms.Guna2HtmlLabel labeldateStart;
        public Guna.UI2.WinForms.Guna2HtmlLabel labeldateEnd;
        public Guna.UI2.WinForms.Guna2HtmlLabel labelCountChel;
        public Guna.UI2.WinForms.Guna2HtmlLabel labelPrice;
    }
}
