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
    public partial class Tedarikci : Form
    {
        private static List<Tedarik> tedarikciler = new List<Tedarik>();
        public Tedarikci()
        {
            InitializeComponent();
        }

        private void GuncelleTedarikci()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = tedarikciler;
        }

        private void Tedarikci_Load(object sender, EventArgs e)
        {
            
        }
    }

    public class Tedarik
    {
        public int tedarikciİD {  get; set; }
        public string sirketAdi {  get; set; }

        public override string ToString()
        {
            return $"{tedarikciİD} - {sirketAdi}";
        }
    }
}
