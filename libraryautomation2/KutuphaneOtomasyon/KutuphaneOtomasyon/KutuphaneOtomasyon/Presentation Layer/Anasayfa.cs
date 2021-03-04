using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KutuphaneOtomasyon.Presentation_Layer;
using KutuphaneOtomasyon.Business_Layer;
using System.Data.OleDb;

namespace KutuphaneOtomasyon
{
    public partial class Form1 : Form
    {
        BLKitaplar blkitap = new BLKitaplar();
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e) //Giriş
        {
            Giris grs = new Giris();
            grs.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)//Kayıt Ol
        {
            OgrenciKayit kyt = new OgrenciKayit();
            kyt.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Ara butonu
        {
            string kitapadi = textBox1.Text; //textbox a girilen değer kitapadi na atanır
            dataGridView1.DataSource = blkitap.KitapIsmeGoreListele(kitapadi);//kitap işlemlerinde bulunan kitapismegörelistele fonk çağırılır ve kitapadi parametre olarak gönderilir
            if (dataGridView1.RowCount <= 0)
            {
                MessageBox.Show("Kayıt Bulunamadı.");
            }
            else
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].SetValues("Tıklayınız");
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)//Form Yüklendiğinde
        {
            dataGridView1.DataSource = blkitap.KitapListele("", "", "");//dataGridView1 de BLKitaplarda bulunan kitap listele gelir
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].SetValues("Tıklayınız");//satırda tıklayınız linki gelir
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Presentation_Layer.Kitaplar.KitapBilgisi kbilgisi = new Presentation_Layer.Kitaplar.KitapBilgisi();
            kbilgisi.kid= dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//dataGridView1 de bulunan kitapid 1. indistedir ve bu kitapbilgisinin kid ine atanır
            kbilgisi.ShowDialog();//kitap bilgisi formu açma
        }
    }
}
