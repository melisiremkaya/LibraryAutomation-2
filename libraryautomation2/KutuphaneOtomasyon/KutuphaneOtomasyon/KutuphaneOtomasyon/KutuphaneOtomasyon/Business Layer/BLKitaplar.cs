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
        DBHelper veritabanı = new DBHelper();
        OleDbCommand komut;
        
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
                case 0://c
                    komut = new OleDbCommand("INSERT INTO Kitaplar(KitapID, KitapAd, KitapYazar, KitapBasimTarihi, KitapDurum) VALUES('" + id + "','" + kad + "','" + kyazar + "','" + kbasim + "','" + kdurum + "')");
                    break;
                case 1://r
                    KitapListele2();
                    break;
                case 2://u
                    komut = new OleDbCommand("UPDATE Kitaplar SET  KitapAd = '" + kad + "', KitapYazar = '" + kyazar + "', KitapBasimTarihi = '" + kbasim + "', KitapDurum = '" + kdurum + "' WHERE KitapID = '" + id + "'");
                    break;
                case 3://d
                    komut = new OleDbCommand("DELETE FROM Kitaplar WHERE KitapID = '" + id + "'");
                    break;
            }

            komut.Connection = veritabanı.BaglantiAc();
            int kontrol = komut.ExecuteNonQuery();
            veritabanı.BaglantiKapa();
            return kontrol;
        }

        public List<Kitaplar> KitapListele(string kitapadi) //arama butonu için listeleme
        {
            List<Kitaplar> kitaplistesi = new List<Kitaplar>();
            komut = veritabanı.Sorgu("SELECT * FROM Kitaplar WHERE KitapAd LIKE '%"+kitapadi+"%'");
            OleDbDataReader rdr = komut.ExecuteReader();
            while (rdr.Read())
            {
                Kitaplar kitaplar = new Kitaplar(
                    rdr["KitapID"].ToString(),
                    rdr["KitapAd"].ToString(),
                    rdr["KitapYazar"].ToString(),
                    rdr["KitapBasimTarihi"].ToString(),
                    rdr["KitapDurum"].ToString()
                    );
                kitaplistesi.Add(kitaplar);
            }
            return kitaplistesi;
        }
        public DataTable KitapListele(string ono,string otc) //
        {
            List<string> kitaplistesi = new List<string>();
            komut = veritabanı.Sorgu("SELECT K.KitapAd,A.KitapAlimTarihi,A.KitapTeslimTarihi,A.KitapDurumu FROM Ogrenciler O,AlinanKitaplar A,Kitaplar K  WHERE O.OgrenciTC =A.OgrenciTC AND A.KitapID = K.KitapID AND O.OgrenciTC = '"+otc+"' AND O.OgrenciNo='"+ono+"'");
            DataTable dataTable = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter(komut);
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);
          
            da.Dispose();
            return dataTable;
        }
        public List<Kitaplar> KitapListele2() //genel listeleme
        {
            List<Kitaplar> kitaplistesi = new List<Kitaplar>();
            komut = veritabanı.Sorgu("SELECT * FROM Kitaplar");
            OleDbDataReader rdr = komut.ExecuteReader();
            while (rdr.Read())
            {
                Kitaplar kitaplar = new Kitaplar(
                    rdr["KitapID"].ToString(),
                    rdr["KitapAd"].ToString(),
                    rdr["KitapYazar"].ToString(),
                    rdr["KitapBasimTarihi"].ToString(),
                    rdr["KitapDurum"].ToString()
                    );
                kitaplistesi.Add(kitaplar);
            }
            return kitaplistesi;
        }

    }
}
