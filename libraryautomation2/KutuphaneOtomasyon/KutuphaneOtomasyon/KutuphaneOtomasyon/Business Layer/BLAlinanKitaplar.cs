using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using KutuphaneOtomasyon.Data_Layer;
namespace KutuphaneOtomasyon.Business_Layer
{
    class BLAlinanKitaplar
    {
        DBHelper veritabanı = new DBHelper();
        public DataTable KitapAlanlar(string kitapid) //genel listeleme
        {
            return veritabanı.ListeleSorgusu("SELECT * FROM AlinanKitaplar WHERE KitapID = '" + kitapid + "'");
        }
        public int KitapIade(int islemid) //İade işleminde kitap durumu güncelleme
        {
            return veritabanı.SorguCalistir("UPDATE AlinanKitaplar SET KitapDurumu = '0'  where İslemID = " + islemid);
        }
        public int KitapAl(string kid, string tc, string atarih, string ttarih, string durum) //Kitap alınınca alınankitaplara eklenme
        {
            return veritabanı.SorguCalistir("INSERT INTO AlinanKitaplar(KitapID,UyeTC,KitapAlimTarihi,KitapTeslimTarihi,KitapDurumu) VALUES('" + kid + "','" + tc + "','" + atarih + "','" + ttarih + "', '" + durum + "')"); ;
        }
    }
}
