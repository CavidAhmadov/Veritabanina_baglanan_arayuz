using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static VeriTabaniProje.Randevular;

namespace VeriTabaniProje
{
    public partial class İptalEdilenRandevular : Form
    {
        public static List<Randevu> İptalRandevularListesi = new List<Randevu>();
        public İptalEdilenRandevular()
        {
            InitializeComponent();
        }

        private void İptalEdilenRandevular_Load(object sender, EventArgs e)
        {
            İptalEdilenRandevularListesi.DataSource = null;
            İptalEdilenRandevularListesi.DataSource = İptalRandevularListesi
                .Select(r => $"ID: {r.randevuİD}, Tarih: {r.tarih.ToShortDateString()}, BerberID: {r.berber_id}, MusteriID: {r.musteri_id}")
                .ToList();
        }
    }
}
