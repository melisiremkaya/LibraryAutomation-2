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
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }
        BLUyeler bluyeler = new BLUyeler();
        private void button1_Click(object sender, EventArgs e)
        {
            OgrenciIslem oislem = new OgrenciIslem();//öğrenci girişi yapılırsa
            PersonelIslem pislem = new PersonelIslem();//personel girişi yapılırsa
            DataTable uyelistesi = bluyeler.UyeListele(-1,textBox2.Text,textBox1.Text);
          
                if (uyelistesi.Rows[0][3].ToString() == textBox1.Text && uyelistesi.Rows[0][0].ToString() == textBox2.Text)//textboxa girilen değerlerin listede kontrolü
                {
                    if (Convert.ToInt32(uyelistesi.Rows[0][6].ToString()) == 0)//öğrenci
                    {
                        oislem.ogrno = textBox1.Text;
                        oislem.ogrtc = textBox2.Text;
                        oislem.ShowDialog();
                    }
                    else if (Convert.ToInt32(uyelistesi.Rows[0][6].ToString()) == 1)//personel
                    {
                        pislem.ShowDialog();
                    }
                }
        }
    }
}
