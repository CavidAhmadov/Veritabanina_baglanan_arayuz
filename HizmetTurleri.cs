using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabaniProje
{
    public partial class HizmetTurleri : Form
    {
        private static List<HizmetTuru> hizmetTurleri = new List<HizmetTuru>();
        public HizmetTurleri()
        {
            InitializeComponent();
        }

        private void HizmetTurleri_Load(object sender, EventArgs e)
        {

        }
    }
    public class HizmetTuru
    {
        public int hizmetTuruİD { get; set; }
        public int turİD { get; set; }
        public string Turu { get; set; }
        public int hizmetKodu { get; set; }

        public override string ToString()
        {
            return $"{hizmetTuruİD} - {turİD} - {Turu} - {hizmetKodu}";
        }
    }
}
