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
    public partial class PersonelIslem : Form
    {
        public PersonelIslem()
        {
            InitializeComponent();
        }

        BLOgrenciler blogr = new BLOgrenciler();
        BLKitaplar blkitap = new BLKitaplar();
        Ogrenciler ogrenciler;
      
        private void button7_Click(object sender, EventArgs e)
        {
            //öğrenci listeleme
            dataGridView1.DataSource = blogr.OgrenciListele();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //öğrenci silme
           ogrenciler.OgrenciTC= dataGridView1.SelectedRows[0].Cells["OgrenciTC"].Value.ToString();
            int kontrol = blogr.OgrenciIslem(ogrenciler,4);
            if (kontrol>0)
            {
                MessageBox.Show("Kayıt Başarıyla Silinmiştir.");
            }
            else
            {
                MessageBox.Show("Kayıt Silinememiştir. Tekrar Deneyiniz.");
            }
             dataGridView1.DataSource= blogr.OgrenciListele();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //öğrenci güncelleme
            string tc = dataGridView1.SelectedRows[0].Cells["OgrenciTC"].Value.ToString();
            string ad = dataGridView1.SelectedRows[0].Cells["OgrenciAd"].Value.ToString();
            string soyad = dataGridView1.SelectedRows[0].Cells["OgrenciSoyad"].Value.ToString();
            string no = dataGridView1.SelectedRows[0].Cells["OgrenciNo"].Value.ToString();
            string tel = dataGridView1.SelectedRows[0].Cells["OgrenciTel"].Value.ToString();
            string adres = dataGridView1.SelectedRows[0].Cells["OgrenciAdres"].Value.ToString();
            OgrenciGuncelleme ogrguncelleme = new OgrenciGuncelleme();
            ogrguncelleme.tc = tc;
            ogrguncelleme.ad = ad;
            ogrguncelleme.soyad = soyad;
            ogrguncelleme.no = no;
            ogrguncelleme.tel = tel;
            ogrguncelleme.adres = adres;
            ogrguncelleme.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //öğrenci kayıt
            OgrenciKayit ogrkayit = new OgrenciKayit();
            ogrkayit.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //kitap kayıt
            KitapKayit kkayit = new KitapKayit();
            kkayit.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //kitap guncelleme

            string id = dataGridView1.SelectedRows[0].Cells["KitapID"].Value.ToString();
            string kad = dataGridView1.SelectedRows[0].Cells["KitapAd"].Value.ToString();
            string kyazar = dataGridView1.SelectedRows[0].Cells["KitapYazar"].Value.ToString();
            string kbasim = dataGridView1.SelectedRows[0].Cells["KitapBasimTarihi"].Value.ToString();
            string kdurum = dataGridView1.SelectedRows[0].Cells["KitapDurum"].Value.ToString();
            KitapGuncelleme kguncelleme = new KitapGuncelleme();
            kguncelleme.kid= id;
            kguncelleme.kad = kad;
            kguncelleme.kyazar = kyazar;
            kguncelleme.kbasim = kbasim;
            kguncelleme.kdurum = kdurum;
            kguncelleme.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // kitap silme DÜZELTİLCEK
          //  Kitaplar kitaplar= new Kitaplar(dataGridView1.SelectedRows[0].Cells["KitapID"].Value.ToString(),"","","","");
          //  int kontrol = blkitap.KitapIslem(kitaplar,3);
            //if (kontrol > 0)
            //{
            //    MessageBox.Show("Kayıt Başarıyla Silinmiştir.");
            //}
            //else
            //{
            //    MessageBox.Show("Kayıt Silinememiştir. Tekrar Deneyiniz.");
            //}
           dataGridView1.DataSource = blkitap.KitapListele2();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //kitap listeleme
            dataGridView1.DataSource = blkitap.KitapListele2();
        }
    }
}
