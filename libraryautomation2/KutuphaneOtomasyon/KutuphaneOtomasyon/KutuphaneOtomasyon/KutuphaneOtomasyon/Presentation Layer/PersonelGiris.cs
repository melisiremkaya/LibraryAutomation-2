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
    public partial class Personel_Giris : Form
    {
        public Personel_Giris()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonelIslem islem = new PersonelIslem();
            islem.ShowDialog();
        }
    }
}
