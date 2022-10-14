namespace laba10
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.cicleButton2 = new laba10.CicleButton();
            this.cicleButton1 = new laba10.CicleButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cicleButton3 = new laba10.CicleButton();
            this.SuspendLayout();
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 660);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1283, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // cicleButton2
            // 
            this.cicleButton2.BackColor = System.Drawing.Color.Red;
            this.cicleButton2.Location = new System.Drawing.Point(903, 13);
            this.cicleButton2.Name = "cicleButton2";
            this.cicleButton2.Size = new System.Drawing.Size(17, 17);
            this.cicleButton2.TabIndex = 4;
            this.cicleButton2.Text = "cicleButton2";
            this.cicleButton2.Click += new System.EventHandler(this.cicleButton2_Click);
            // 
            // cicleButton1
            // 
            this.cicleButton1.BackColor = System.Drawing.Color.Red;
            this.cicleButton1.Location = new System.Drawing.Point(880, 13);
            this.cicleButton1.Name = "cicleButton1";
            this.cicleButton1.Size = new System.Drawing.Size(17, 17);
            this.cicleButton1.TabIndex = 3;
            this.cicleButton1.Text = "cicleButton1";
            this.cicleButton1.Click += new System.EventHandler(this.cicleButton1_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // cicleButton3
            // 
            this.cicleButton3.BackColor = System.Drawing.Color.Red;
            this.cicleButton3.Location = new System.Drawing.Point(903, 213);
            this.cicleButton3.Name = "cicleButton3";
            this.cicleButton3.Size = new System.Drawing.Size(17, 17);
            this.cicleButton3.TabIndex = 5;
            this.cicleButton3.Text = "cicleButton3";
            this.cicleButton3.Click += new System.EventHandler(this.cicleButton3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1283, 682);
            this.Controls.Add(this.cicleButton3);
            this.Controls.Add(this.cicleButton2);
            this.Controls.Add(this.cicleButton1);
            this.Controls.Add(this.statusStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private CicleButton cicleButton1;
        private CicleButton cicleButton2;
        private System.Windows.Forms.Timer timer1;
        private CicleButton cicleButton3;
    }
}

