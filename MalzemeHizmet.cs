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
    public partial class MalzemeHizmet : Form
    {
        private static List<MalzemeHizmetler> malzemeHizmetler = new List<MalzemeHizmetler> ();
        public MalzemeHizmet()
        {
            InitializeComponent();
        }

        private void MalzemeHizmet_Load(object sender, EventArgs e)
        {

        }

        public class MalzemeHizmetler
        {
            public int malzemeHizmetİD { get; set; }
            public int hizmetKodu { get; set; }
            public int malzemeİD { get; set; }

            public override string ToString()
            {
                return $"{malzemeHizmetİD} - {hizmetKodu} - {malzemeİD}";
            }
        }
    }
}
