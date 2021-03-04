using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace KutuphaneOtomasyon.Data_Layer
{
    class DBHelper
    {
        OleDbCommand sorgu;
        DataTable dt;
        OleDbDataAdapter adp;
        public OleDbConnection BaglantiAc()
        {
            OleDbConnection baglanti = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database1.accdb;Persist Security Info=False;"); //Veritabanı bağlantısı
            baglanti.Open();//Bağlantı açma
            return baglanti;
        }
        public void BaglantiKapa()//Bağlantı kapama
        {
            OleDbConnection baglanti = BaglantiAc();
            baglanti.Close();
        }
        //CRUD
        //CREATE READ UPDATE DELETE
        public int SorguCalistir(string komut) // Create,update,delete işlemlerinin yapıldığı sorgu
        {
            sorgu = new OleDbCommand(komut, BaglantiAc());//Sorgu oluşturulup bağlantısı belirtilir ve açılır
            int kontrol = sorgu.ExecuteNonQuery();//İşlem yapılıp yapılmadığı kontrol edilir
            BaglantiKapa();//Bağlantı kapatılır
            return kontrol;
        }
        public DataTable ListeleSorgusu(string komut)//Read işleminin yapıldığı fonksiyondur
        {
            dt = new DataTable(); //Datatable oluşturulur
            sorgu = new OleDbCommand(komut, BaglantiAc());
            adp = new OleDbDataAdapter(sorgu);//Veri kaynağı sorgu olarak belirtilir
            adp.Fill(dt);//Datatable içine adapterdaki veriler atanır
            BaglantiKapa();//Bağlantı kapatılır
            return dt;
        }
    }
}
