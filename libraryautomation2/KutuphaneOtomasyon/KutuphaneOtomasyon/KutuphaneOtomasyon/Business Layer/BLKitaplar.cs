using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KutuphaneOtomasyon.Data_Layer;
using System.Data.OleDb;
using System.Data;

namespace KutuphaneOtomasyon.Business_Layer
{
    class BLKitaplar
    {
        DBHelper veritabanı = new DBHelper(); //Veritabanı işlemi yapılacağından dbhelper çağırılır
        string komut;
        public int KitapIslem(Kitaplar kitaplar, int islem)
        {
            //CRUD
            //0123
            string id = kitaplar.KitapID;
            string kad = kitaplar.KitapAd;
            string kyazar = kitaplar.KitapYazar;
            string kbasim = kitaplar.KitapBasimTarihi;
            string kdurum = kitaplar.KitapDurum;
            
            switch (islem)
            {
                case 0://c ekle
                    komut = "INSERT INTO Kitaplar(KitapID, KitapAd, KitapYazar, KitapBasimTarihi, KitapDurum) VALUES('" + id + "','" + kad + "','" + kyazar + "','" + kbasim + "','" + kdurum + "')";
                    break;
                case 1://r listeleme
                    KitapListele("","","");
                    break;
                case 2://u güncelleme
                    komut = "UPDATE Kitaplar SET  KitapAd = '" + kad + "', KitapYazar = '" + kyazar + "', KitapBasimTarihi = '" + kbasim + "', KitapDurum = '" + kdurum + "' WHERE KitapID = '" + id + "'";
                    break;
                case 3://d silme
                    komut = "DELETE FROM Kitaplar WHERE KitapID = '" + id + "'";
                    break;
            }
            return veritabanı.SorguCalistir(komut);
        }
        public int KitapDurumGuncelle(string kitapid) //kitap durumu güncelleme
        {
            return veritabanı.SorguCalistir("UPDATE Kitaplar SET KitapDurum = '1'  where KitapID = '" + kitapid + "'"); 
        }
        public DataTable KitapIsmeGoreListele(string kitapadi) //arama butonu için listeleme
        {
            return veritabanı.ListeleSorgusu("SELECT * FROM Kitaplar WHERE KitapAd LIKE '%" + kitapadi + "%'");
        }
        public DataTable KitapListele(string uno, string utc, string kitapid) //Öğrenci numaralarına ve kitapid ye göre kitap listeleme fonksiyonu
        {
            if (string.IsNullOrEmpty(kitapid))//öğrenci no ve tc ye göre listeleme
            {
                komut = "SELECT K.KitapID,K.KitapAd,A.KitapAlimTarihi,A.KitapTeslimTarihi,A.KitapDurumu,A.İslemID FROM Uyeler U,AlinanKitaplar A,Kitaplar K  WHERE U.UyeTC =A.UyeTC AND A.KitapID = K.KitapID AND U.UyeTC = '" + utc + "' AND U.UyeNo='" + uno + "'";
            }
             if(string.IsNullOrEmpty(uno) && string.IsNullOrEmpty(utc)) //kitapid ye göre listeleme
            {
                komut = "SELECT * FROM Kitaplar where KitapID = '" + kitapid + "'";
            }
             if(string.IsNullOrEmpty(uno) && string.IsNullOrEmpty(utc)&& string.IsNullOrEmpty(kitapid)) //genel kitap listesi
            {
                komut= "SELECT * FROM Kitaplar";
            }
            return veritabanı.ListeleSorgusu(komut);
        }
        public DataTable KitapDurumListele()//Boşta olan kitapların listesi
        {
            return veritabanı.ListeleSorgusu("SELECT * FROM Kitaplar where KitapDurum ='0'"); 
        }

        public DataTable KitapSayisi()//Tüm kitap sayısı
        {

            komut = ("SELECT COUNT(*) FROM Kitaplar");

            return veritabanı.ListeleSorgusu(komut);
        }

        public DataTable KiralananlarSayisi() //Dolu kitap sayısı
        {

            komut = ("SELECT COUNT(*) FROM Kitaplar WHERE KitapDurum='1'");

            return veritabanı.ListeleSorgusu(komut);
        }

        public DataTable BosKitapSayisi() //Boş kitap sayısı
        {

            komut = ("SELECT COUNT(*) FROM Kitaplar WHERE KitapDurum='0'"); 

            return veritabanı.ListeleSorgusu(komut);
        }
        public int KitapDurumGuncelleIade(string kid) //İade işlemi yapıldıktan sonra durum güncelleme
        {

            komut = ("UPDATE Kitaplar SET KitapDurum ='0' WHERE KitapID = '"+kid+"'"); 

            return veritabanı.SorguCalistir(komut);
        }
    }
}
