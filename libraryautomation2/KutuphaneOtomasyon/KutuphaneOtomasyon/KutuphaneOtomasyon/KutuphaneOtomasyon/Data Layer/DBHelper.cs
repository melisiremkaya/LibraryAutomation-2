using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace KutuphaneOtomasyon.Data_Layer
{
    class DBHelper
    {
        public OleDbConnection BaglantiAc()
        {
            OleDbConnection baglanti =  new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\Database1.accdb;Persist Security Info=False;");
            baglanti.Open();
            return baglanti;
        }
        public void BaglantiKapa()
        {
            OleDbConnection baglanti = BaglantiAc();
            baglanti.Close();
        }
        //CRUD
        //CREATE READ UPDATE DELETE
        public OleDbCommand Sorgu(string komut)
        {
            OleDbCommand sorgu = new OleDbCommand(komut, BaglantiAc());
            BaglantiKapa();
            return sorgu;
        }

    }
}
