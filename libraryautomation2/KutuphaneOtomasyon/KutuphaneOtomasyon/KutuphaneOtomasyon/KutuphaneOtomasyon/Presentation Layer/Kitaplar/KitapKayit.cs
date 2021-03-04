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
    public partial class KitapKayit : Form
    {
        public KitapKayit()
        {
            InitializeComponent();
        }
        BLKitaplar blkitap = new BLKitaplar();
        Kitaplar kitaplar;

        private void button1_Click(object sender, EventArgs e)
        {
            kitaplar = new Kitaplar(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            int kontrol = blkitap.KitapIslem(kitaplar, 0);

            if (kontrol > 0)
            {
                MessageBox.Show("Kayıt Başarıyla Oluşturulmuştur.");
            }
            else
            {
                MessageBox.Show("Kayıt Oluşturulamadı. Tekrar Deneyiniz.");
            }
        }
    }
}
