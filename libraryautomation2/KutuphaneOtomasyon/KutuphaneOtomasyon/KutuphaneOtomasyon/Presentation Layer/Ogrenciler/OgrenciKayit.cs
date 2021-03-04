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
        BLUyeler bluye= new BLUyeler(); //üye ekleme işlemi yapılacağından bluyeler classı çağırılır
        Uyeler uyeler;
        private void button1_Click(object sender, EventArgs e)
        {
            uyeler = new Uyeler();
            //textboxa girilecek değerler veritabanına kayıt edilecek yere eşitlenir 
            uyeler.UyeTC= textBox1.Text;
            uyeler.UyeAd = textBox2.Text;
            uyeler.UyeSoyad = textBox3.Text;
            uyeler.UyeNo = textBox4.Text;
            uyeler.UyeTel = textBox5.Text;
            uyeler.UyeAdres = textBox6.Text;
            uyeler.UyePozisyon = "0";
            int kontrol = bluye.UyeIslem(uyeler,0,0);//üyeişlemde bulunan ekle fonksiyonuna gönderilir
            
            if (kontrol > 0)//kayıt kontrol edilir
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
