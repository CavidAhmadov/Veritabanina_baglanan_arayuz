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
    public partial class Tur : Form
    {
        public List<Turu> turler = new List<Turu>();
        public Tur()
        {
            InitializeComponent();
        }

        private void Tur_Load(object sender, EventArgs e)
        {

        }

        public class Turu
        {
            public int turİD { get; set; }

            public override string ToString()
            {
                return $"{turİD}";
            }
        }
    }
}
