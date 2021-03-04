using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using KutuphaneOtomasyon.Data_Layer;


namespace KutuphaneOtomasyon.Business_Layer
{

    class BLOgrenciler
    {
        DBHelper veritabanı = new DBHelper();
        OleDbCommand komut;
        //CRUD
        //0123
        public int OgrenciIslem(Ogrenciler ogrenciler, int islem)
        {
            string tc = ogrenciler.OgrenciTC;
            string ad = ogrenciler.OgrenciAd;
            string soyad = ogrenciler.OgrenciSoyad;
            string no = ogrenciler.OgrenciNo;
            string tel = ogrenciler.OgrenciTel;
            string adres = ogrenciler.OgrenciAdres;
            switch (islem)
            {
                case 0://c
                    komut = new OleDbCommand("INSERT INTO Ogrenciler(OgrenciTC, OgrenciAd, OgrenciSoyad, OgrenciNo, OgrenciTel, OgrenciAdres) VALUES('" + tc + "','" + ad + "','" + soyad + "','" + no + "','" + tel + "','" + adres + "')");
                    break;
                case 1://r
                    OgrenciListele();
                    break;
                case 2://u
                    komut = new OleDbCommand("UPDATE Ogrenciler SET  OgrenciAd = '" + ad + "', OgrenciSoyad = '" + soyad + "', OgrenciNo = '" + no + "', OgrenciTel = '" + tel + "', OgrenciAdres = '" + adres + "' WHERE OgrenciTC = '" + tc + "'");
                    break;
                case 3://d
                    komut = new OleDbCommand("DELETE FROM Ogrenciler WHERE OgrenciTC = '" + tc + "'");
                    break;
            }
            komut.Connection = veritabanı.BaglantiAc();
            int kontrol = komut.ExecuteNonQuery();
            veritabanı.BaglantiKapa();
            return kontrol;
        }

        public List<Ogrenciler> OgrenciListele()
        {
            List<Ogrenciler> ogrencilistesi = new List<Ogrenciler>();
            komut = veritabanı.Sorgu("SELECT * FROM Ogrenciler");
            OleDbDataReader rdr = komut.ExecuteReader();
            while (rdr.Read())
            {
                Ogrenciler ogrenciler = new Ogrenciler(
                    rdr["OgrenciTC"].ToString(),
                    rdr["OgrenciAd"].ToString(),
                    rdr["OgrenciSoyad"].ToString(),
                    rdr["OgrenciNo"].ToString(),
                    rdr["OgrenciTel"].ToString(),
                    rdr["OgrenciAdres"].ToString(),
                    rdr["KitapID"].ToString()
                    );
                ogrencilistesi.Add(ogrenciler);
            }
            return ogrencilistesi;
        }

    }
}
