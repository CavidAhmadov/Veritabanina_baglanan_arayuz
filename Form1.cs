namespace VeriTabaniProje
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Kullanicilar yeniForm = new Kullanicilar();
            yeniForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hizmetler yeniForm = new Hizmetler();
            yeniForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Randevular yeniForm = new Randevular();
            yeniForm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Malzemeler yenForm = new Malzemeler();
            yenForm.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tedarikci yeniForm = new Tedarikci();
            yeniForm.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GeriBildirim yeniForm = new GeriBildirim();
            yeniForm.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RandevuHizmetleri yeniForm = new RandevuHizmetleri();
            yeniForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            HizmetTurleri yeni = new HizmetTurleri();
            yeni.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MalzemeTedarik yeni = new MalzemeTedarik();
            yeni.Show();
        }
    }
}