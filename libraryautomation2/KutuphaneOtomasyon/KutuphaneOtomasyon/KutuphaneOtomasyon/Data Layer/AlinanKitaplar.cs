using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KutuphaneOtomasyon.Data_Layer
{
    class AlinanKitaplar
    {
        public string KitapID { get; set; }
        public string UyeTC { get; set; }
        public string KitapAlimTarihi { get; set; }
        public string KitapTeslimTarihi { get; set; }
        public string KitapDurumu { get; set; }

        public AlinanKitaplar(
            string KitapID,
            string UyeTC,
            string KitapAlimTarihi,
            string KitapTeslimTarihi,
            string KitapDurumu)
        {
            this.KitapID = KitapID;
            this.UyeTC = UyeTC;
            this.KitapAlimTarihi = KitapAlimTarihi;
            this.KitapTeslimTarihi = KitapTeslimTarihi;
            this.KitapDurumu = KitapDurumu;
        }
    }
}
