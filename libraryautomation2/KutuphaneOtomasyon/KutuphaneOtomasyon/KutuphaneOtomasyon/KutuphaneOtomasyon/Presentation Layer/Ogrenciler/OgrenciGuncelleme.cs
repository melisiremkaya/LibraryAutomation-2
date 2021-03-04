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
    public partial class OgrenciGuncelleme : Form
    {
        public OgrenciGuncelleme()
        {
            InitializeComponent();
        }
        Ogrenciler ogrenciler;
        BLOgrenciler blogr = new BLOgrenciler();
        private void button1_Click(object sender, EventArgs e)
        {
            ogrenciler.OgrenciTC = textBox1.Text;
            ogrenciler.OgrenciAd = textBox2.Text;
            ogrenciler.OgrenciSoyad = textBox3.Text;
            ogrenciler.OgrenciNo = textBox4.Text;
            ogrenciler.OgrenciTel = textBox5.Text;
            ogrenciler.OgrenciAdres = textBox6.Text;
            int kontrol = blogr.OgrenciIslem(ogrenciler,2);
            if (kontrol > 0)
            {
                MessageBox.Show("Kayıt Başarıyla Güncellenmiştir.");
            }
            else
            {
                MessageBox.Show("Kayıt Güncellenemedi. Tekrar Deneyiniz.");
            }
        }
        public string tc, ad, soyad, no, tel, adres;
        private void OgrenciGuncelleme_Load(object sender, EventArgs e)
        {
            textBox1.Text = tc;
            textBox2.Text = ad;
            textBox3.Text = soyad;
            textBox4.Text = no;
            textBox5.Text = tel;
            textBox6.Text = adres;

        }
    }
}
