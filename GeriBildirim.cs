using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeriTabaniProje
{
    public partial class GeriBildirim : Form
    {
        private static List<GeriBildirimler> geriBildirimler = new List<GeriBildirimler>();
        public GeriBildirim()
        {
            InitializeComponent();
        }

        private void GuncelleGeriBildirimler()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = geriBildirimler;
        }

        private void GeriBildirim_Load(object sender, EventArgs e)
        {

        }
    }

    public class GeriBildirimler
    {
        public int geriBildirimİD {  get; set; }
        public int musteriİD { get; set; }
        public int puan {  get; set; }

        public override string ToString()
        {
            return $"{geriBildirimİD} - {musteriİD} - {puan}";
        }
    }
}
