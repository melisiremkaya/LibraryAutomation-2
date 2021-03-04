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
using ZedGraph;

namespace KutuphaneOtomasyon.Presentation_Layer
{
    public partial class PersonelIslem : Form
    {
        public PersonelIslem()
        {
            InitializeComponent();
        }

        BLUyeler bluyeler = new BLUyeler();
        BLKitaplar blkitap = new BLKitaplar();
        Uyeler uyeler = new Uyeler();

        private void button7_Click(object sender, EventArgs e)
        {
            //öğrenci listeleme
            dataGridView1.DataSource = bluyeler.UyeListele(0, "", "");

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //öğrenci silme
            uyeler.UyeTC = dataGridView1.SelectedRows[0].Cells["UyeTC"].Value.ToString();//seçilen satırdaki üyetc üyelere atanır
            int kontrol = bluyeler.UyeIslem(uyeler, 3, 0);//üyeişlem de üyeler ve silme parametresini alır
            if (kontrol > 0)//işlem kontrolü
            {
                MessageBox.Show("Kayıt Başarıyla Silinmiştir.");
            }
            else
            {
                MessageBox.Show("Kayıt Silinememiştir. Tekrar Deneyiniz.");
            }
            dataGridView1.DataSource = bluyeler.UyeListele(0, "", "");//silme işlemi yapıldıktan sonra güncel listeleme
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //öğrenci güncelleme
            OgrenciGuncelleme ogrguncelleme = new OgrenciGuncelleme();
            ogrguncelleme.tc = dataGridView1.SelectedRows[0].Cells["UyeTC"].Value.ToString();
            ogrguncelleme.ad = dataGridView1.SelectedRows[0].Cells["UyeAd"].Value.ToString();
            ogrguncelleme.soyad = dataGridView1.SelectedRows[0].Cells["UyeSoyad"].Value.ToString();
            ogrguncelleme.no = dataGridView1.SelectedRows[0].Cells["UyeNo"].Value.ToString();
            ogrguncelleme.tel = dataGridView1.SelectedRows[0].Cells["UyeTel"].Value.ToString();
            ogrguncelleme.adres = dataGridView1.SelectedRows[0].Cells["UyeAdres"].Value.ToString();
            ogrguncelleme.ShowDialog();//öğrenci güncelleme formu açılır
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
            //kitap güncelle formuna dataGridView1 den seçilen satırın bilgileri aktarılır
            KitapGuncelleme kguncelleme = new KitapGuncelleme(); 
            kguncelleme.kid = dataGridView1.SelectedRows[0].Cells["KitapID"].Value.ToString();
            kguncelleme.kad = dataGridView1.SelectedRows[0].Cells["KitapAd"].Value.ToString();
            kguncelleme.kyazar = dataGridView1.SelectedRows[0].Cells["KitapYazar"].Value.ToString();
            kguncelleme.kbasim = dataGridView1.SelectedRows[0].Cells["KitapBasimTarihi"].Value.ToString();
            kguncelleme.kdurum = dataGridView1.SelectedRows[0].Cells["KitapDurum"].Value.ToString();
            kguncelleme.ShowDialog();//form açılır
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // kitap silme 
            Data_Layer.Kitaplar kitaplar = new Data_Layer.Kitaplar(dataGridView1.SelectedRows[0].Cells["KitapID"].Value.ToString(), "", "", "", "");//seçilen satırdaki kitapid gönderilir
            int kontrol = blkitap.KitapIslem(kitaplar, 3);//kitapişlemlerinden silme işlemine yönlendirilir
            if (kontrol > 0)//işlem kontrolü
            {
                MessageBox.Show("Kayıt Başarıyla Silinmiştir.");
            }
            else
            {
                MessageBox.Show("Kayıt Silinememiştir. Tekrar Deneyiniz.");
            }
            dataGridView1.DataSource = blkitap.KitapListele("", "", "");//silme işlemi yapıldıktan sonra güncel listeleme
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //kitap listeleme
            dataGridView1.DataSource = blkitap.KitapListele("", "", "");
        }



        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        GraphPane pane;
        BarItem bi1, bi2, bi3;
        private void PersonelIslem_Load(object sender, EventArgs e)
        {
            pane = zedGraphControl1.GraphPane;//beyaz grafik alanını temsil eder 
            pane.Title.Text = "KİTAP DURUM GRAFİĞİ";//Grafik başlığı
            pane.XAxis.Title.Text = ""; //xaxis için başlık verilmiyor
            pane.YAxis.Title.Text = "Kitap Sayıları";//yaxis başlığı

            DataTable dt1 = blkitap.KitapSayisi();//kitap işlemlerinden kitap sayısı fonksiyonu dt1 e atanır
            double[] kitaplarx = { 0 };//dt1 in x kısmındaki konumu
            double[] kitaplary = { Convert.ToDouble(dt1.Rows[0][0].ToString()) }; 
            DataTable dt2 = blkitap.KiralananlarSayisi();//kitap işlemlerinden kiralanan kitap sayısı fonksiyonu dt2 e atanır
            double[] kiralanalarx = { 5 };//dt2 nin x kısmındaki konumu
            double[] kiralanalary = { Convert.ToDouble(dt2.Rows[0][0].ToString()) };
            DataTable dt3 = blkitap.BosKitapSayisi();//kitap işlemlerinden boş kitap sayısı fonksiyonu dt3 e atanır
            double[] verilmeyehazirx = { 10 };//dt3 nin x kısmındaki konumu
            double[] verilmeyehaziry = { Convert.ToDouble(dt3.Rows[0][0].ToString()) };
            //line chart çizmek için nokta çiftleri oluşturulur
            PointPairList pl1 = new PointPairList(kitaplarx, kitaplary);
            PointPairList pl2 = new PointPairList(kiralanalarx, kiralanalary);
            PointPairList pl3 = new PointPairList(verilmeyehazirx, verilmeyehaziry);
            //baritemlara isimleri, verileri ve renkleri atanır
             bi1 = pane.AddBar("Kitaplar", pl1, Color.Green);
             bi2 = pane.AddBar("Kiralananlar", pl2, Color.Red);
             bi3 = pane.AddBar("Boşta Olan Kitaplar", pl3, Color.Turquoise);

            TextObj barLabel = new TextObj(bi1.Points[0].Y.ToString(), bi1.Points[0].X, bi1.Points[0].Y + 5);
            barLabel.FontSpec.Border.IsVisible = false;
            //bir degişiklik yaptımızda, bu değişikliği zedgraph a haber vermek için çağırmamız gereken fonksiyonlar
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            //Grafiği baştan çizdirmek için
            zedGraphControl1.Refresh();
        }

    }
}
