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
    public partial class Malzemeler : Form
    {
        private static List<Malzeme> malzemeler = new List<Malzeme>();
        public Malzemeler()
        {
            InitializeComponent();
        }

        private void GuncelleListboxMalzemeler()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = malzemeler;
        }

        private void Malzemeler_Load(object sender, EventArgs e)
        {
            malzemeler.Add(new Malzeme { malzemeİD = 1, malzemeAdi = "Saç Kesim Makası"});
            malzemeler.Add(new Malzeme { malzemeİD = 2, malzemeAdi = "Saç Şekillendirme Tarağı" });
            malzemeler.Add(new Malzeme { malzemeİD = 3, malzemeAdi = "Saç Fırçası" });
            malzemeler.Add(new Malzeme { malzemeİD = 4, malzemeAdi = "Fön Makinesi" });



        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

    public class Malzeme
    {
        public int malzemeİD { get; set; }
        public string malzemeAdi { get; set; }

        public override string ToString()
        {
            return $"{malzemeİD} - {malzemeAdi}";
        }
    }

}
