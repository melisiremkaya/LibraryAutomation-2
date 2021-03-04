using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;


namespace KutuphaneOtomasyon.Data_Layer
{
    class Kitaplar
    {
        public string KitapID { get; set; }
        public string KitapAd { get; set; }
        public string KitapYazar { get; set; }
        public string KitapBasimTarihi { get; set; }
        public string KitapDurum { get; set; }

        public Kitaplar(
            string KitapID,
            string KitapAd,
            string KitapYazar,
            string KitapBasimTarihi,
            string KitapDurum)
        {
            this.KitapID = KitapID;
            this.KitapAd = KitapAd;
            this.KitapYazar = KitapYazar;
            this.KitapBasimTarihi = KitapBasimTarihi;
            this.KitapDurum = KitapDurum;
        }
    }
}
