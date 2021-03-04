using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using KutuphaneOtomasyon.Business_Layer;
namespace KutuphaneOtomasyon.Presentation_Layer.Kitap
{
    public partial class KitapAl : Form
    {
        public KitapAl()
        {
            InitializeComponent();
        }
        public string ogrtc, ogrno;
        BLKitaplar blkitap = new BLKitaplar();
        BLAlinanKitaplar blalinankitaplar = new BLAlinanKitaplar();
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string kitapid = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//listenin 1. indisi kitapid ye eşitlenir
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Kitap Alınsın mı", "Kitap Al", MessageBoxButtons.YesNo);//işlem yapılacağı zaman sorma
            if (dialog == DialogResult.Yes)//evetse
            {
                blkitap.KitapDurumGuncelle(kitapid);//kitapid parametre olarak kitapdurumgüncelleye gönderilir
            }
            else
            {
                this.Close();
            }
            string alinan = DateTime.Now.ToShortDateString();//bugünün tarihini alinana eşitleriz
            string teslim = DateTime.Now.AddMonths(1).ToString();//teslim tarihi 1 ay olarak ayarlanır
            int kontrol = blalinankitaplar.KitapAl(kitapid, ogrtc, alinan, teslim, "1"); //değişkenler parametre olarak kitapal fonk gönderilir
            if (kontrol>0)//işlem kontrolü
            {
                MessageBox.Show("Kitap Alındı");
            }
            else
            {
                MessageBox.Show("Tekrar deneyiniz");
            }
            dataGridView1.DataSource = blkitap.KitapDurumListele();//liste duruma göre yeniden listelenir
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].SetValues("Kitap Al");
            }         
        }

        private void KitapAl_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = blkitap.KitapDurumListele();//kitap durumu 0 olan kitaplar listelenir
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].SetValues("Kitap Al");
            }
        }
    }
}
