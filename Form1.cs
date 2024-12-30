using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OgrenciBilgiSistemi
{
    public partial class Form1 : Form
    {
        Ogrenci? ogr;
        private object txtId;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var ctx = new OdevDbContext())
            {

                var siniflar = ctx.Siniflar.ToList();
                comboBox1.DataSource = siniflar;
                comboBox1.DisplayMember = "SinifAd";
                comboBox1.ValueMember = "SinifId";
            }
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            bool kontrol = false;
            foreach (Control item in grpOgrenci.Controls)
            {
                if (item is TextBox && item.Text == String.Empty)
                {
                    item.BackColor = Color.DarkCyan;
                    kontrol = true;
                }
            }
            if (kontrol)
            {
                MessageBox.Show("Tüm alanlar zorunludur");
                return;
            }

            var ogr = new Ogrenci { Ad = txtAd.Text.Trim(), Soyad = txtSoyad.Text.Trim(), Numara = txtNumara.Text.Trim() };

            using (var ctx = new OdevDbContext())
            {
                ctx.Ogrenciler.Add(ogr);
                var sonuc = ctx.SaveChanges();
                MessageBox.Show(sonuc > 0 ? "Kayıt Başarılı" : "Kayıt Ekleme Başarısız!");
            }

            try
            {
                using (var ctx = new OdevDbContext())
                {
                    if (comboBox1.SelectedValue == null)
                    {
                        MessageBox.Show("Lütfen bir sinif seçiniz!");
                        return;
                    }

                    int sinifId = (int)comboBox1.SelectedValue;
                    var sinif = ctx.Siniflar.Include(s => s.Ogrenciler).FirstOrDefault(s => s.SinifId == sinifId);

                    if (sinif == null)
                    {
                        MessageBox.Show("Seçilen sinif bulunamadi!");
                        return;
                    }

                    if (sinif.Ogrenciler != null && sinif.Ogrenciler.Count >= sinif.Kontenjan)
                    {
                        MessageBox.Show($"Seçilen sinifin kontenjani dolmustur! ({sinif.Kontenjan} ögrenci)");
                        return;
                    }


                    ctx.Ogrenciler.Add(ogr);
                    var sonuc = ctx.SaveChanges();
                    MessageBox.Show(sonuc > 0 ? "Kayit Basarili" : "Kayit Ekleme Basarisiz!");
                }
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show($"Veritabani güncellenirken bir hata olustu: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata olustu: {ex.Message}");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            using (var ctx = new OdevDbContext())
            {
                if (ogr != null)
                {
                    ogr.Numara = txtNumara.Text.Trim();
                    ogr.Ad = txtAd.Text.Trim();
                    ogr.Soyad = txtSoyad.Text.Trim();
                    ctx.Entry(ogr).State = EntityState.Modified;
                    MessageBox.Show(ctx.SaveChanges() > 0 ? "Güncelleme Başarılı" : "Başarısız!");
                }
                else
                {
                    MessageBox.Show("Ögrenci bulunamadı!");
                }
            }
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            txt.BackColor = Color.White;
            if (txt.Text == String.Empty)
            {
                txt.BackColor = Color.DarkGreen;
            }
        }

        private void btnBul_Click(object sender, EventArgs e)
        {
            using (var ctx = new OdevDbContext())
            {
                var ogr = ctx.Ogrenciler.FirstOrDefault(o => o.Numara == txtNumara.Text.Trim());
                if (ogr != null)
                {
                    this.ogr = ogr;
                    txtAd.Text = ogr.Ad;
                    txtSoyad.Text = ogr.Soyad;
                }
                else
                {
                    MessageBox.Show("Öğrenci Bulunamadı!");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int ogrenciId = 1; 
            var form2 = new Form2(ogrenciId);  
            form2.Show();
        }
    }
}