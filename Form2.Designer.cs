using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;

namespace OgrenciBilgiSistemi
{
    partial class Form2
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
            lblOgrenciBilgileri = new Label();
            dataGridViewDersler = new DataGridView();
            lblDers = new Label();
            btnDersKaydet = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridViewDersler).BeginInit();
            SuspendLayout();
            // 
            // lblOgrenciBilgileri
            // 
            lblOgrenciBilgileri.AutoSize = true;
            lblOgrenciBilgileri.BackColor = SystemColors.ActiveCaption;
            lblOgrenciBilgileri.Location = new Point(33, 22);
            lblOgrenciBilgileri.Name = "lblOgrenciBilgileri";
            lblOgrenciBilgileri.Size = new Size(135, 15);
            lblOgrenciBilgileri.TabIndex = 0;
            lblOgrenciBilgileri.Text = "Seçilen öğrenci bilgileri :\r\n";
            // 
            // dataGridViewDersler
            // 
            dataGridViewDersler.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewDersler.Location = new Point(33, 120);
            dataGridViewDersler.Margin = new Padding(3, 2, 3, 2);
            dataGridViewDersler.Name = "dataGridViewDersler";
            dataGridViewDersler.RowHeadersWidth = 51;
            dataGridViewDersler.RowTemplate.Height = 29;
            dataGridViewDersler.Size = new Size(644, 153);
            dataGridViewDersler.TabIndex = 1;
            // 
            // lblDers
            // 
            lblDers.AutoSize = true;
            lblDers.BackColor = SystemColors.ControlDark;
            lblDers.Location = new Point(33, 94);
            lblDers.Name = "lblDers";
            lblDers.Size = new Size(43, 15);
            lblDers.TabIndex = 2;
            lblDers.Text = "Dersler";
            // 
            // btnDersKaydet
            // 
            btnDersKaydet.BackColor = SystemColors.HotTrack;
            btnDersKaydet.Location = new Point(220, 286);
            btnDersKaydet.Margin = new Padding(3, 2, 3, 2);
            btnDersKaydet.Name = "btnDersKaydet";
            btnDersKaydet.Size = new Size(231, 22);
            btnDersKaydet.TabIndex = 3;
            btnDersKaydet.Text = "Öğrencinin derslerini kaydet";
            btnDersKaydet.UseVisualStyleBackColor = false;
            btnDersKaydet.Click += btnDersKaydet_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(btnDersKaydet);
            Controls.Add(lblDers);
            Controls.Add(dataGridViewDersler);
            Controls.Add(lblOgrenciBilgileri);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewDersler).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOgrenciBilgileri;
        private DataGridView dataGridViewDersler;
        private Label lblDers;
        private Button btnDersKaydet;
    }
}