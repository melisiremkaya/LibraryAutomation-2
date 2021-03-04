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
        Uyeler Uyeler = new Uyeler();
        BLUyeler bluyeler = new BLUyeler();
        private void button1_Click(object sender, EventArgs e)//güncelle butonu
        {
            //textboxa girilen değerler üyelere atanır
            Uyeler.UyeTC = textBox1.Text;
            Uyeler.UyeAd = textBox2.Text;
            Uyeler.UyeSoyad = textBox3.Text;
            Uyeler.UyeNo = textBox4.Text;
            Uyeler.UyeTel = textBox5.Text;
            Uyeler.UyeAdres = textBox6.Text;
            int kontrol = bluyeler.UyeIslem(Uyeler,2,0);//üyeişlem üyeleri ve güncelleyi parametre alır
            if (kontrol > 0)//işlem kontrolü
            {
                MessageBox.Show("Kayıt Başarıyla Güncellenmiştir.");
            }
            else
            {
                MessageBox.Show("Kayıt Güncellenemedi. Tekrar Deneyiniz.");
            }
        }
        public string tc, ad, soyad, no, tel, adres;
        private void OgrenciGuncelleme_Load(object sender, EventArgs e)//güncelle formu yüklendiğinde
        {
            //dataGridView1 den seçilen değerler textboxa atanır
            textBox1.Text = tc;
            textBox2.Text = ad;
            textBox3.Text = soyad;
            textBox4.Text = no;
            textBox5.Text = tel;
            textBox6.Text = adres;
        }
    }
}
