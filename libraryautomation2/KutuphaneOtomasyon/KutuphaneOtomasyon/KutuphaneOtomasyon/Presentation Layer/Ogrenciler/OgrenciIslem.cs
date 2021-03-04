using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KutuphaneOtomasyon.Business_Layer;
namespace KutuphaneOtomasyon.Presentation_Layer
{
    public partial class OgrenciIslem : Form
    {
        public OgrenciIslem()
        {
            InitializeComponent();
        }
        public string ogrtc, ogrno;
        BLKitaplar bLKitaplar = new BLKitaplar();
        BLAlinanKitaplar blalinankitaplar = new BLAlinanKitaplar();
        private void button1_Click(object sender, EventArgs e)//ceza işlem
        {
            listBox1.Items.Clear();//listbox temizleme
            DataTable dt = bLKitaplar.KitapListele(ogrno, ogrtc,"");//öğrenci no ve tc ye göre kitap listeletilir
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                double tutar = 0;
                string kteslimtarihi = dt.Rows[i]["KitapTeslimTarihi"].ToString();//listeden kitapteslimtarihi kteslimtarihine eşitlenir
                string kdurum = dt.Rows[i]["KitapDurumu"].ToString();//listeden kitapdurumu kduruma eşitlenir
                string bugun = DateTime.Now.ToShortDateString();//bugünün tarihi alınır ve bugune eşitlenir
                double fark = (Convert.ToDateTime(bugun) - Convert.ToDateTime(kteslimtarihi)).TotalDays;//bugünden teslim edilmesi gereken tarih çıkartılır bu da farka eşitlenir
                if (fark > 0 && kdurum == "1") //fark 0 dan büyük ve teslim edilmemişse
                {
                    tutar = fark * 1; //fark*1 tutarı vericektir
                    listBox1.Items.Add(dt.Rows[i]["KitapAd"].ToString() + " adlı kitabı " + fark.ToString() + " gün geciktiğinden " + tutar.ToString() + " TL cezanız bulunmaktadır");

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//kitap al
        {
            Kitap.KitapAl ktpal = new Kitap.KitapAl();
           // this.Close();
            ktpal.ogrno = ogrno;
            ktpal.ogrtc = ogrtc;
            ktpal.ShowDialog();      
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)//kitap iade
        {
            string islemid = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();//listenin 6. indisi islemid ye eşitlenir
            string kid = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//listenin 1. indisi kid e eşitlenir
            int kontrol = blalinankitaplar.KitapIade(Convert.ToInt32(islemid));//kitapiade fonk çağırılır ve islemid parametre olarak gönderilir
            bLKitaplar.KitapDurumGuncelleIade(kid);//kitabın kitapdurumu güncellenir
            doldur();
        }

        private void OgrenciIslem_Load(object sender, EventArgs e)
        {
            doldur();//fonksiyon çağırılır
        }
        void doldur()
        {
            dataGridView1.DataSource = bLKitaplar.KitapListele(ogrno, ogrtc,"");//öğrenci no ve tc ye göre listeleme
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                Application.DoEvents();
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                string kteslimdurumu = dataGridView1.Rows[i].Cells["KitapDurumu"].Value.ToString();//kitap durumu dgv1 den çekilir
                string kteslimtarihi = dataGridView1.Rows[i].Cells["KitapTeslimTarihi"].Value.ToString();//kitap teslim tarihi dgv1 den çekilir
                string bugun = DateTime.Now.ToShortDateString();//bugünün tarihi
                double fark = (Convert.ToDateTime(bugun) - Convert.ToDateTime(kteslimtarihi)).TotalDays;//bugünden teslim edilmesi gereken tarih çıkartılır bu da farka eşitlenir
                if (fark > 0 && kteslimdurumu == "1") //fark 0 dan büyükse ve kitap teslim edilmemişse
                {
                    renk.BackColor = Color.Red;//kırmızı uyarı
                }
                else if (fark == -2 && kteslimdurumu != "0") //teslime 2 gün varsa ve teslim edilmemişse
                {
                    renk.BackColor = Color.Yellow;//sarı uyarı
                }
                else if (kteslimdurumu == "0") //teslim edilmişse
                {
                    renk.BackColor = Color.Green;//yeşil uyarı
                }
                dataGridView1.Rows[i].DefaultCellStyle = renk;
                string durum = dataGridView1.Rows[i].Cells[5].Value.ToString();//5. indisi duruma esitler
                if (durum == "1")//eğer durum 1 ise
                {
                    dataGridView1.Rows[i].SetValues("İade Et");//iade et 
                }
                else
                {
                    dataGridView1.Rows[i].SetValues("İade Edildi");//iade edildi uyarısı
                }
            }
        }
    }
}
