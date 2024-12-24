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
    public partial class Kullanicilar : Form
    {
        public Kullanicilar()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yoneticiler yeniForm = new Yoneticiler();
            yeniForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Musteriler yeniForm = new Musteriler();
            yeniForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Kuaforler yeniForm = new Kuaforler();
            yeniForm.ShowDialog();
        }
    }
}
