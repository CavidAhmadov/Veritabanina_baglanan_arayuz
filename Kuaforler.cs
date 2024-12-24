using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VeriTabaniProje
{
    public partial class Kuaforler : Form
    {
        private static List<Kuafor> kuaforler = new List<Kuafor>();

        private static bool verilerEklendi = false;

        public Kuaforler()
        {
            InitializeComponent();
        }

        private static int kuaforİDsayaci = 1;

        private void Kuaforler_Load(object sender, EventArgs e)
        {
            if (!verilerEklendi)
            {
                kuaforler.Add(new Kuafor { kuaforİD = 1, Ad = "Mehmet", Soyad = "Yilmaz", Email = "mehmetyilmaz@example.com", Telefon = "4441111" });
                kuaforler.Add(new Kuafor { kuaforİD = 2, Ad = "Emre", Soyad = "Deniz", Email = "emredeniz.com", Telefon = "4442222" });
                kuaforler.Add(new Kuafor { kuaforİD = 3, Ad = "Efe", Soyad = "Kaya", Email = "efekaya@example.com", Telefon = "4443333" });

                verilerEklendi = true;
            }

            kuaforİDsayaci = kuaforler.Max(k => k.kuaforİD) + 1;
            listBox1.DataSource = kuaforler;
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

            Kuafor yeniKuafor = new Kuafor
            {
                kuaforİD = kuaforİDsayaci++,
                Ad = ad,
                Soyad = soyad,
                Email = eposta,
                Telefon = telefon
            };

            kuaforler.Add(yeniKuafor);

            listBox1.DataSource = null;
            listBox1.DataSource = kuaforler;


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kuafor seciliKuafor = listBox1.SelectedItem as Kuafor;

            if (seciliKuafor == null)
            {
                MessageBox.Show("Lütfen silmek istediğiniz müşteriyi seçiniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            kuaforler.Remove(seciliKuafor);

            listBox1.DataSource = null;
            listBox1.DataSource = kuaforler;

            MessageBox.Show($"Kuaför başarıyla silindi: {seciliKuafor.Ad}, {seciliKuafor.Soyad}", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string aramaKriteri = textBox5.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(aramaKriteri))
            {
                MessageBox.Show("Lütfen aramak istediğiniz bilgiyi giriniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var aramaSonuclari = kuaforler.Where(m =>
                m.Ad.ToLower().Contains(aramaKriteri) ||
                m.Soyad.ToLower().Contains(aramaKriteri) ||
                m.Email.ToLower().Contains(aramaKriteri) ||
                m.Telefon.Contains(aramaKriteri)).ToList();

            if (aramaSonuclari.Count == 0)
            {
                MessageBox.Show("Aramanıza uygun kuaför bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                listBox2.DataSource = null;
                listBox2.DataSource = aramaSonuclari;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Kuafor secilenKuafor = listBox1.SelectedItem as Kuafor;

            if (secilenKuafor != null)
            {
                secilenKuafor.Ad = textBox6.Text.Trim();
                secilenKuafor.Soyad = textBox7.Text.Trim();
                secilenKuafor.Email = textBox8.Text.Trim();
                secilenKuafor.Telefon = textBox9.Text.Trim();

                listBox1.DataSource = null;
                listBox1.DataSource = kuaforler;

                MessageBox.Show("Kuaför bilgileri güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Lütfen bir kuaför seçin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kuafor secilenKuafor = listBox1.SelectedItem as Kuafor;

            if (secilenKuafor != null)
            {
                textBox6.Text = secilenKuafor.Ad;
                textBox7.Text = secilenKuafor.Soyad;
                textBox8.Text = secilenKuafor.Email;
                textBox9.Text = secilenKuafor.Telefon;
            }
        }
    }

    public class Kuafor
    {
        public int kuaforİD { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }

        public override string ToString()
        {
            return $"{kuaforİD} - {Ad} {Soyad} | Eposta: {Email} | Tel: {Telefon}";
        }
    }
}
