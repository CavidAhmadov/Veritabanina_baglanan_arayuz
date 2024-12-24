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
    public partial class RandevuHizmetleri : Form
    {
        private static List<RandevuHizmetler> randevuHizmetleri = new List<RandevuHizmetler> ();
        public RandevuHizmetleri()
        {
            InitializeComponent();
        }

        private void RandevuHizmetleri_Load(object sender, EventArgs e)
        {

        }
    }

    public class RandevuHizmetler
    {
        public int randevuİD {  get; set; }
        public int hizmetKodu { get; set; }
        public int randevuHizmetleriİD { get; set; }

        public override string ToString()
        {
            return $"{randevuHizmetleriİD} - {hizmetKodu} - {randevuHizmetleriİD}";
        }
    }
}