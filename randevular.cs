using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabaniProje
{
    public partial class Randevular : Form
    {
        private static List<Randevu> randevuListesi = new List<Randevu>();
        private static int sonrakiID = 1;
        private static int sonrakiBerberID = 1;
        private static int sonrakiMusteriID = 1;

        private static List<DateTime> randevuTarihleri = new List<DateTime>();
        public static List<DateTime> YenilenenRandevularListesi = new List<DateTime>();
        public Randevular()
        {
            InitializeComponent();
        }

        public class Randevu
        {
            public DateTime tarih { get; set; }
            public int randevuİD { get; set; }
            public int berber_id { get; set; }
            public int musteri_id { get; set; }
        }

        private void Randevular_Load(object sender, EventArgs e)
        {

        }

        private void GuncelleListBox()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = randevuListesi
                .Select(r => $"ID: {r.randevuİD}, Tarih: {r.tarih.ToShortDateString()}, BerberID: {r.berber_id}, MusteriID: {r.musteri_id}")
                .ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParseExact(
        textBox1.Text,
        "yyyy-MM-dd",
        System.Globalization.CultureInfo.InvariantCulture,
        System.Globalization.DateTimeStyles.None,
        out DateTime yeniTarih))
            {
                if (!randevuListesi.Any(r => r.tarih == yeniTarih))
                {
                    // Yeni randevu oluştur ve listeye ekle
                    Randevu yeniRandevu = new Randevu
                    {
                        randevuİD = sonrakiID++,
                        tarih = yeniTarih,
                        berber_id = sonrakiBerberID++, // BerberID otomatik artıyor
                        musteri_id = sonrakiMusteriID++ // Örnek olarak 1, bu değer dinamik olabilir
                    };
                    randevuListesi.Add(yeniRandevu);

                    GuncelleListBox();
                    MessageBox.Show("Randevu başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Bu tarih zaten mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir tarih giriniz (ör. 2024-12-12)", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            textBox1.Clear();
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string seciliRandevu = listBox1.SelectedItem.ToString();
                int id = int.Parse(seciliRandevu.Split(',')[0].Split(':')[1].Trim()); // ID'yi ayıkla

                Randevu silinecekRandevu = randevuListesi.FirstOrDefault(r => r.randevuİD == id);

                if (silinecekRandevu != null)
                {
                    randevuListesi.Remove(silinecekRandevu);
                    GuncelleListBox();
                    MessageBox.Show("Randevu başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz randevuyu seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tüm tarihleri silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                randevuTarihleri.Clear();
                GuncelleListBox();
                MessageBox.Show("Tüm tarihler silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string seciliRandevu = listBox1.SelectedItem.ToString();
                int id = int.Parse(seciliRandevu.Split(',')[0].Split(':')[1].Trim()); // ID'yi ayıkla

                Randevu guncellenecekRandevu = randevuListesi.FirstOrDefault(r => r.randevuİD == id);

                if (guncellenecekRandevu != null && DateTime.TryParse(textBox2.Text, out DateTime yeniTarih))
                {
                    if (!randevuListesi.Any(r => r.tarih == yeniTarih))
                    {
                        guncellenecekRandevu.tarih = yeniTarih;
                        GuncelleListBox();
                        MessageBox.Show("Randevu başarıyla güncellendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Bu tarih zaten mevcut!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz randevuyu seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            textBox2.Clear();
            textBox2.Focus();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            İptalEdilenRandevular yeniForm = new İptalEdilenRandevular();
            yeniForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                // Seçilen randevuyu ID ile alıyoruz
                string seciliRandevu = listBox1.SelectedItem.ToString();
                int id = int.Parse(seciliRandevu.Split(',')[0].Split(':')[1].Trim()); // ID'yi ayıkla

                // Randevu listesinde seçilen randevuyu bul
                Randevu iptalEdilecekRandevu = randevuListesi.FirstOrDefault(r => r.randevuİD == id);

                if (iptalEdilecekRandevu != null)
                {
                    // İptal edilen randevular listesine ekle
                    İptalEdilenRandevular.İptalRandevularListesi.Add(iptalEdilecekRandevu);

                    // Ana listeden sil
                    randevuListesi.Remove(iptalEdilecekRandevu);

                    // ListBox'u güncelle
                    GuncelleListBox();

                    MessageBox.Show("Randevu başarıyla iptal edildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen iptal etmek istediğiniz randevuyu seçiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            randevu_yenilendi yeni = new randevu_yenilendi();
            yeni.Show();
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=kuafor; user ID = Postgres; password=20062003");

        private void button8_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from randevu";
            NpgsqlDataAdapter d = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            d.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}