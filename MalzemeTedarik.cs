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
    public partial class MalzemeTedarik : Form
    {
        private static List<MalzemeTedarikler> malzemeTedarikler = new List<MalzemeTedarikler> ();
        public MalzemeTedarik()
        {
            InitializeComponent();
        }

        private void MalzemeTedarik_Load(object sender, EventArgs e)
        {

        }

        public class MalzemeTedarikler
        {
            public int kayitİD { get; set; }
            public int tedarikciİD { get; set; }
            public int malzemeİD { get; set; }
            public DateTime alimTarihi { get; set; }
            public int miktar {  get; set; }

            public override string ToString()
            {
                return $"{kayitİD} - {tedarikciİD} - {malzemeİD} - {alimTarihi} - {miktar}";
            }
        }
    }
}
