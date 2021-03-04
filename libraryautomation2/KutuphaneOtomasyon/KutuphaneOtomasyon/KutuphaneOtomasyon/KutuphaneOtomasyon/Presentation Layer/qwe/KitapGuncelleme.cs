using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KutuphaneOtomasyon.Business_Layer;
using KutuphaneOtomasyon.Data_Layer;

namespace KutuphaneOtomasyon.Presentation_Layer
{
    public partial class KitapGuncelleme : Form
    {
        BLKitaplar blkitap = new BLKitaplar();
     
        public KitapGuncelleme()
        {
            InitializeComponent();
        }
        public string kid, kad, kyazar, kbasim, kdurum;

        private void button1_Click(object sender, EventArgs e)
        {
            Kitaplar kitaplar = new Kitaplar(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            int kontrol = blkitap.KitapIslem(kitaplar,2);
            if (kontrol > 0)
            {
                MessageBox.Show("Kayıt Başarıyla Güncellenmiştir.");
            }
            else
            {
                MessageBox.Show("Kayıt Güncellenemedi. Tekrar Deneyiniz.");
            }
        }

        private void KitapGuncelleme_Load(object sender, EventArgs e)
        {
            textBox1.Text = kid;
            textBox2.Text = kad;
            textBox3.Text = kyazar;
            textBox4.Text = kbasim;
            textBox5.Text = kdurum;
        }
    }
}
