using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KutuphaneOtomasyon.Data_Layer
{
    class Ogrenciler
    {
        public string OgrenciTC { get; set; }
        public string OgrenciAd { get; set; }
        public string OgrenciSoyad { get; set; }
        public string OgrenciNo { get; set; }
        public string OgrenciTel { get; set; }
        public string OgrenciAdres { get; set; }
        public string KitapID { get; set; }


        public Ogrenciler(
            string OgrenciTC,
            string OgrenciAd,
            string OgrenciSoyad,
            string OgrenciNo,
            string OgrenciTel,
            string OgrenciAdres,
            string KitapID
            )

        {
            this.OgrenciTC = OgrenciTC;
            this.OgrenciAd = OgrenciAd;
            this.OgrenciSoyad = OgrenciSoyad;
            this.OgrenciNo = OgrenciNo;
            this.OgrenciTel = OgrenciTel;
            this.OgrenciAdres = OgrenciAdres;
            this.KitapID = KitapID;
          
        }


    }
}
