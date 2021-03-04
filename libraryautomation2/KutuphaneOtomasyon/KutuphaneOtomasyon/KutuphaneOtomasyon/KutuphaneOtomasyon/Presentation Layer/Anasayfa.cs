using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KutuphaneOtomasyon.Presentation_Layer;
using KutuphaneOtomasyon.Business_Layer;

namespace KutuphaneOtomasyon
{
    public partial class Form1 : Form
    {
        BLKitaplar blkitap = new BLKitaplar();
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Personel_Giris pgrs = new Personel_Giris();
            pgrs.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciKayit kyt = new OgrenciKayit();
            kyt.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OgrenciGiris grs = new OgrenciGiris();
            grs.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kitapadi = textBox1.Text;
            dataGridView1.DataSource = blkitap.KitapListele(kitapadi);
            if (dataGridView1.RowCount<=0)
            {
                MessageBox.Show("Kayıt Bulunamadı.");
            }
        }

       
    }
}
