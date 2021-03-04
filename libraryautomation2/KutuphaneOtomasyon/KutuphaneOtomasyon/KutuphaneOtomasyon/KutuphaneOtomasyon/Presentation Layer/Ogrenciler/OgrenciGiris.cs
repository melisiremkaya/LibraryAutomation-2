using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KutuphaneOtomasyon.Presentation_Layer
{
    public partial class OgrenciGiris : Form
    {
        public OgrenciGiris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //sqlden veri girişi kontrol edilcek
            OgrenciIslem oislem = new OgrenciIslem();
            oislem.ogrno = "172113036";
            oislem.ogrtc = "28249612345";
            oislem.ShowDialog();
        }
    }
}
