using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VeriTabaniProje
{
    public partial class Yoneticiler : Form
    {
        private static List<Yonetici> yoneticiler = new List<Yonetici>();

        private static bool verilerEklendi = false;

        public Yoneticiler()
        {
            InitializeComponent();
        }

        private static int yoneticiİDsayaci = 1;

        private void Yoneticiler_Load(object sender, EventArgs e)
        {
            if (!verilerEklendi)
            {
                yoneticiler.Add(new Yonetici { yoneticiİD = 1, Ad = "Aslan", Soyad = "Akbey", Email = "aslanakbey@example.com", Telefon = "6661111" });
                yoneticiler.Add(new Yonetici { yoneticiİD = 2, Ad = "Polat", Soyad = "Alemdar", Email = "polatalemdar@example.com", Telefon = "6662222" });

                verilerEklendi = true;
            }

            yoneticiİDsayaci = yoneticiler.Max(y => y.yoneticiİD) + 1;

            listBox1.DataSource = null;
            listBox1.DataSource = yoneticiler;


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

            Yonetici yeniYonetici = new Yonetici
            {
                yoneticiİD = yoneticiİDsayaci++,
                Ad = ad,
                Soyad = soyad,
                Email = eposta,
                Telefon = telefon
            };

            yoneticiler.Add(yeniYonetici);

            listBox1.DataSource = null;
            listBox1.DataSource = yoneticiler;

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Yonetici seciliYonetici = listBox1.SelectedItem as Yonetici;

            if (seciliYonetici == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz yöneticiyi seçin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            yoneticiler.Remove(seciliYonetici);

            listBox1.DataSource = null;
            listBox1.DataSource = yoneticiler;

            MessageBox.Show($"Yönetici başarıyla silindi: {seciliYonetici.Ad}, {seciliYonetici.Soyad}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string aramaKriteri = textBox5.Text.Trim();

            if (string.IsNullOrEmpty(aramaKriteri))
            {
                MessageBox.Show("Lütfen aramak istediğiniz yöneticiyi seçin", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var aramaSonuclari = yoneticiler.Where(m =>
                m.Ad.ToLower().Contains(aramaKriteri) ||
                m.Soyad.ToLower().Contains(aramaKriteri) ||
                m.Email.ToLower().Contains(aramaKriteri) ||
                m.Telefon.Contains(aramaKriteri)).ToList();

            if (aramaSonuclari.Count == 0)
            {
                MessageBox.Show("Aramanıza uygun yönetici bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                listBox2.DataSource = null;
                listBox2.DataSource = aramaSonuclari;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            Yonetici secilenYonetici = listBox1.SelectedItem as Yonetici;

            if (secilenYonetici != null)
            {
                textBox6.Text = secilenYonetici.Ad;
                textBox7.Text = secilenYonetici.Soyad;
                textBox8.Text = secilenYonetici.Email;
                textBox9.Text = secilenYonetici.Telefon;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Yonetici secilenYonetici = listBox1.SelectedItem as Yonetici;

            if (secilenYonetici != null)
            {
                secilenYonetici.Ad = textBox6.Text.Trim();
                secilenYonetici.Soyad = textBox7.Text.Trim();
                secilenYonetici.Email = textBox8.Text.Trim();
                secilenYonetici.Telefon = textBox9.Text.Trim();

                listBox1.DataSource = null;
                listBox1.DataSource = yoneticiler;

                MessageBox.Show("Yönetici bilgileri güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen bir yönetici seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

    public class Yonetici
    {
        public int yoneticiİD { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public override string ToString()
        {
            return $"{yoneticiİD} - {Ad} {Soyad} | Eposta: {Email} | Tel: {Telefon}";
        }
    }
}