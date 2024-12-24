using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;



namespace VeriTabaniProje
{
    public partial class Hizmetler : Form
    {

        public Hizmetler()
        {
            InitializeComponent();
        }

        private void GuncelleListBox()
        {

        }


        private void Hizmetler_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432;Database=kuafor;user ID=postgres;Password= 20062003");
        private void button1_Click(object sender, EventArgs e)
        {

            string sorgu = "select * from hizmetler";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];


        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Guncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut12 = new NpgsqlCommand("update hizmetler set hizmetadi=@p1 where hizmetkodu=@p2", baglanti);
            komut12.Parameters.AddWithValue("@p1", (textBox1.Text));
            komut12.Parameters.AddWithValue("@p2", int.Parse(textBox2.Text));

            komut12.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt başarıyla guncellendi.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut4 = new NpgsqlCommand("SELECT * FROM hizmetler WHERE hizmetkodu=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1", int.Parse(textBox2.Text));

            using (var reader = komut4.ExecuteReader())
            {
                if (reader.Read())
                {
                    MessageBox.Show($"Hizmet Kodu: {reader["hizmetkodu"]}, Hizmet Adi: {reader["hizmetadi"]},");
                }
                else
                {
                    MessageBox.Show("Kayıt bulunamadı.");
                }
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut2 = new NpgsqlCommand("Delete from hizmetler where hizmetkodu = @p1", baglanti);
            komut2.Parameters.AddWithValue("@p1", int.Parse(textBox2.Text));
            komut2.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Hizmet silme islemi basarili");
        }

        private void Ekle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            NpgsqlCommand komut1 = new NpgsqlCommand("insert into hizmetler (hizmetkodu, hizmetadi) values (@p1, @p2)", baglanti);
            komut1.Parameters.AddWithValue("@p1", int.Parse(textBox2.Text));
            komut1.Parameters.AddWithValue("@p2", textBox1.Text);

            komut1.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt başarıyla eklendi.");
        }
    }

    public class Hizmet
    {
      


       
    }
}
