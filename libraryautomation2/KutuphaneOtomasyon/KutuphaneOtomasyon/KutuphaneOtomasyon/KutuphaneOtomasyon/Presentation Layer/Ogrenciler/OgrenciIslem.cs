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

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            DataTable dt = bLKitaplar.KitapListele(ogrno, ogrtc);
            for (int i = 0; i < dt.Rows.Count-1; i++)
            {
                double tutar = 0;
                string kteslimtarihi = dt.Rows[i]["KitapTeslimTarihi"].ToString();
                string bugun = DateTime.Now.ToShortDateString();
                double fark = (Convert.ToDateTime(bugun) - Convert.ToDateTime(kteslimtarihi)).TotalDays;
                if (fark > 0)
                {
                    tutar = fark * 1;
                    listBox1.Items.Add(dt.Rows[i]["KitapAd"].ToString()+" adlı kitabı "+fark.ToString() + " gün geciktiğinden " + tutar.ToString() + " TL cezanız bulunmaktadır");

                }
            }
        }

        private void OgrenciIslem_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bLKitaplar.KitapListele(ogrno, ogrtc);
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                Application.DoEvents();
                DataGridViewCellStyle renk = new DataGridViewCellStyle();
                string kteslimdurumu = dataGridView1.Rows[i].Cells["KitapDurumu"].Value.ToString();
                string kteslimtarihi = dataGridView1.Rows[i].Cells["KitapTeslimTarihi"].Value.ToString();
                string bugun = DateTime.Now.ToShortDateString();
                double fark = (Convert.ToDateTime(bugun) - Convert.ToDateTime(kteslimtarihi)).TotalDays;
                //FARKALR HESAPLANIRKEN TESLİM DURUMU KONTROL EDİLCEK
                if (fark > 0 && kteslimdurumu =="H")
                {
                    renk.BackColor = Color.Red;
                }
                else if (fark == -2 && kteslimdurumu != "E")
                {
                    renk.BackColor = Color.Yellow;
                }
                else if ( kteslimdurumu == "E")
                {
                    renk.BackColor = Color.Green;
                }
                dataGridView1.Rows[i].DefaultCellStyle = renk;
            }
        }
    }
}
