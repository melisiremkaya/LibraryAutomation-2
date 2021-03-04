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
namespace KutuphaneOtomasyon.Presentation_Layer.Kitaplar
{
    public partial class KitapBilgisi : Form
    {
        public KitapBilgisi()
        {
            InitializeComponent();
        }
       
        public string kid;
        BLKitaplar blkitaplar = new BLKitaplar(); //listele komutu burada olduğundan blkitaplar çağırılır
        BLAlinanKitaplar blalinankitaplar = new BLAlinanKitaplar();//kitabı alan öğrenciler listeleneceğinden blalinankitaplar çağırılır
        private void KitapBilgisi_Load(object sender, EventArgs e) //form yüklendiğinde
        {
            DataTable dt = blkitaplar.KitapListele("","",kid); //kitapid ye göre listeleme
            label1.Text = dt.Rows[0][0].ToString(); //indislerin yerine göre labellere atama
            label2.Text = dt.Rows[0][1].ToString();
            label3.Text = dt.Rows[0][2].ToString();
            dataGridView1.DataSource = blalinankitaplar.KitapAlanlar(kid);//dataGridView1 de kitapid ye göre alan kişilerin listelenmesi
        }
    }
}
