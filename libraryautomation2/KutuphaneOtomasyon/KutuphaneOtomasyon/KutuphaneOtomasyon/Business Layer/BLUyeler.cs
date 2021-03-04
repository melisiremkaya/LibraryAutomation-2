using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using KutuphaneOtomasyon.Data_Layer;
using System.Data;

namespace KutuphaneOtomasyon.Business_Layer
{

    class BLUyeler
    {
        DBHelper veritabanı = new DBHelper();
        string komut;
        //CRUD
        //0123
        public int UyeIslem(Uyeler Uyeler, int islem, int pzsyn)
        {
            string tc = Uyeler.UyeTC;
            string ad = Uyeler.UyeAd;
            string soyad = Uyeler.UyeSoyad;
            string no = Uyeler.UyeNo;
            string tel = Uyeler.UyeTel;
            string adres = Uyeler.UyeAdres;
            string pozisyon = Convert.ToString(pzsyn);

            switch (islem)
            {
                case 0://c ekle
                    komut ="INSERT INTO Uyeler(UyeTC, UyeAd, UyeSoyad, UyeNo, UyeTel, UyeAdres,UyePozisyon) VALUES('" + tc + "','" + ad + "','" + soyad + "','" + no + "','" + tel + "','" + adres + "','" + pozisyon + "')";
                    break;
                case 1://r listele
                    UyeListele(pzsyn,Uyeler.UyeTC,Uyeler.UyeNo);
                    break;
                case 2://u güncelle
                    komut = "UPDATE Uyeler SET  UyeAd = '" + ad + "', UyeSoyad = '" + soyad + "', UyeNo = '" + no + "', UyeTel = '" + tel + "', UyeAdres = '" + adres + "', UyePozisyon = '" + pozisyon + "' WHERE UyeTC = '" + tc + "'";
                    break;
                case 3://d sil
                    komut = "DELETE FROM Uyeler WHERE UyeTC = '" + tc + "'";
                    break;
            }
            return veritabanı.SorguCalistir(komut);
        }

        public DataTable UyeListele(int pozisyon,string tc,string no)
        {
            //0 = ÖĞRENCİ
            //1 = PERSONEL
            if (pozisyon == -1) //Öğrenci Listeleme
            {
                komut = "SELECT * FROM Uyeler WHERE UyeNo = '"+no+"' AND UyeTC ='"+tc+"'";
            }
            else
            {
                if (string.IsNullOrEmpty(tc)&&string.IsNullOrEmpty(no))
                {
                    komut = "SELECT * FROM Uyeler WHERE UyePozisyon = " + pozisyon;
                }
                else
                {
                komut = "SELECT * FROM Uyeler WHERE UyeNo = '" + no + "' AND UyeTC ='" + tc + "' AND UyePozisyon = " + pozisyon;

                }
            }
            return veritabanı.ListeleSorgusu(komut);//komut dbhelperda bulunan listelesorgusuna gönderilir
        }

    }
}
