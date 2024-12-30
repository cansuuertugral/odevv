﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciBilgiSistemi
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private int OgrenciId;

        public Form2(int ogrenciId)
        {
            InitializeComponent();
            OgrenciId = ogrenciId;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            using (var ctx = new OdevDbContext())
            {

                var ogrenci = ctx.Ogrenciler.FirstOrDefault(o => o.OgrenciId == OgrenciId);
                if (ogrenci != null)
                {
                    lblOgrenciBilgileri.Text = $"Öğrenci: {ogrenci.Ad} {ogrenci.Soyad}";
                }


                var dersler = ctx.Dersler.ToList();
                dataGridViewDersler.DataSource = dersler;
            }

        }

        private void btnDersKaydet_Click(object sender, EventArgs e)
        {
            using (var ctx = new OdevDbContext())
            {

                var secilenDersler = dataGridViewDersler.SelectedRows
                    .Cast<DataGridViewRow>()
                    .Select(r => (int)r.Cells["DersId"].Value)
                    .ToList();


                foreach (var dersId in secilenDersler)
                {
                    ctx.OgrenciDersler.Add(new OgrenciDers
                    {
                        OgrenciId = this.OgrenciId,
                        DersId = dersId
                    });
                }


                ctx.SaveChanges();
                MessageBox.Show("Dersler başarıyla kaydedildi!");
            }

        }
    }
}