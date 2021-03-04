using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KutuphaneOtomasyon.Business_Layer;
using KutuphaneOtomasyon.Data_Layer;

namespace KutuphaneOtomasyon.Presentation_Layer
{

    public partial class OgrenciKayit : Form
    {
        public OgrenciKayit()
        {
            InitializeComponent();
        }
        BLOgrenciler blogrenci = new BLOgrenciler();
        Ogrenciler ogrenciler;
        private void button1_Click(object sender, EventArgs e)
        {
            ogrenciler.OgrenciTC= textBox1.Text;
            ogrenciler.OgrenciAd = textBox2.Text;
            ogrenciler.OgrenciSoyad = textBox3.Text;
            ogrenciler.OgrenciNo = textBox4.Text;
            ogrenciler.OgrenciTel = textBox5.Text;
            ogrenciler.OgrenciAdres = textBox6.Text;

            int kontrol = blogrenci.OgrenciIslem(ogrenciler,0);
            
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
