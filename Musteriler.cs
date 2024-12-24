using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Npgsql;
namespace VeriTabaniProje
{
    public partial class Musteriler : Form
    {
        private static List<Musteri> musteriler = new List<Musteri>();

        private static bool verilerEklendi = false;

        public Musteriler()
        {
            InitializeComponent();
        }

        private static int musteriİdSayaci = 1;


        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432;Databse=kuafor;user ID=postgres;password=20062003");
        private void Musteriler_Load(object sender, EventArgs e)
        {
            
            if (!verilerEklendi)
            {
               

                verilerEklendi = true;
            }
            musteriİdSayaci = musteriler.Max(m => m.musteriİD) + 1;

            listBox1.DataSource = null;
            listBox1.DataSource = musteriler;
        }

        


        private void button1_Click(object sender, EventArgs e)
        {

        string ad = textBox1.Text.Trim();
            string soyad = textBox2.Text.Trim();
            string eposta = textBox3.Text.Trim();
            string telefon = textBox4.Text.Trim();

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) || string.IsNullOrEmpty(eposta) || string.IsNullOrEmpty(telefon))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Musteri yeniMusteri = new Musteri
            {
                musteriİD = musteriİdSayaci++, 
                Ad = ad,
                Soyad = soyad,
                Email = eposta,
                Telefon = telefon
            };

            musteriler.Add(yeniMusteri); 

            listBox1.DataSource = null; 
            listBox1.DataSource = musteriler; 

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Musteri seciliMusteri = listBox1.SelectedItem as Musteri;

            if (seciliMusteri == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz müşteriyi seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            musteriler.Remove(seciliMusteri);

            listBox1.DataSource = null;
            listBox1.DataSource = musteriler;

            MessageBox.Show($"Müşteri başarıyla silindi: {seciliMusteri.Ad} {seciliMusteri.Soyad}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string aramaKriteri = textBox5.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(aramaKriteri))
            {
                MessageBox.Show("Lütfen aramak istediğiniz bilgiyi giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var aramaSonuclari = musteriler.Where(m =>
                m.Ad.ToLower().Contains(aramaKriteri) ||
                m.Soyad.ToLower().Contains(aramaKriteri) ||
                m.Email.ToLower().Contains(aramaKriteri) ||
                m.Telefon.Contains(aramaKriteri)).ToList();

            if (aramaSonuclari.Count == 0)
            {
                MessageBox.Show("Aramanıza uygun müşteri bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                listBox2.DataSource = null;
                listBox2.DataSource = aramaSonuclari;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Musteri secilenMusteri = listBox1.SelectedItem as Musteri;

            if (secilenMusteri != null)
            {
                secilenMusteri.Ad = textBox6.Text.Trim();
                secilenMusteri.Soyad = textBox7.Text.Trim();
                secilenMusteri.Email = textBox8.Text.Trim();
                secilenMusteri.Telefon = textBox9.Text.Trim();

                listBox1.DataSource = null;
                listBox1.DataSource = musteriler;

                MessageBox.Show("Müşteri bilgileri güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen bir müşteri seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Musteri secilenMusteri = listBox1.SelectedItem as Musteri;

            if (secilenMusteri != null)
            {
                textBox6.Text = secilenMusteri.Ad;
                textBox7.Text = secilenMusteri.Soyad;
                textBox8.Text = secilenMusteri.Email;
                textBox9.Text = secilenMusteri.Telefon;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }

    public class Musteri
    {
        public int musteriİD { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public override string ToString()
        {
            return $"{musteriİD} - {Ad} {Soyad} | {Email} | {Telefon}";
        }
    }
}
