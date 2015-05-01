using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcSkladowana
{
    class Program
    {

        static void Main(string[] args)
        {
            Main1(new /*string*/ []{"abc","asd"});
        }

//http://msdn.microsoft.com/en-us/library/vstudio/zxsa8hkf%28v=vs.100%29.aspx
            //InsertCurrencyCommand.CommandText =
            //    "INSERT Sales.Currency (CurrencyCode, Name, ModifiedDate)" +
            //    " VALUES(@CurrencyCode, @Name, GetDate())";



        static void Main1(string[] args)
        {

            using (var cn = new System.Data.SqlClient.SqlConnection(@"Server=ELA-KOMPUTER\NAZWA_INSTANCJI;Database=KR_D;Trusted_Connection=True;"))
            {
                System.Data.SqlClient.SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = cn;

                //sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@parNazwa", "KB03"));
                sqlCmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@parNip", "00000003"));

                sqlCmd.CommandText =
                    "INSERT dbo.klienci (nazwa, nip)" +
                    " VALUES(@parNazwa, @parNip)";

                cn.Open();
                sqlCmd.ExecuteNonQuery();
                cn.Close();
            }
        }



        static void Main2(string[] args)
        {
            //http://www.connectionstrings.com/sqlconnection/
            var cn = new System.Data.SqlClient.SqlConnection(@"Server=ELA-KOMPUTER\NAZWA_INSTANCJI;Database=KR_D;Trusted_Connection=True;");
            //cn.Open();
            SqlCommand cmd = new SqlCommand("procDodajKlienta", cn); // cn.CreateCommand();
            //cmd.CommandText = "procDodajKlienta";
            cn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@parNazwa", "KB01"));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@parNip", "00000002"));
            cmd.ExecuteNonQuery();
            cn.Close();
        }


        static void Main3(string[] args)
        {
            //http://www.connectionstrings.com/sqlconnection/
            var cn = new System.Data.SqlClient.SqlConnection(@"Server=ELA-KOMPUTER\NAZWA_INSTANCJI;Database=KR_D;Trusted_Connection=True;");
            //cn.Open();
            SqlCommand cmd = new SqlCommand("procDodajKlienta", cn); // cn.CreateCommand();
            //cmd.CommandText = "procDodajKlienta";
            cn.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@parNazwa", "KB01"));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@parNip", "00000002"));
            cmd.ExecuteNonQuery();  
        }


        static void Main4(string[] args)
        {
            //http://www.connectionstrings.com/sqlconnection/
            var cn = new System.Data.SqlClient.SqlConnection(@"Server=ELA-KOMPUTER\NAZWA_INSTANCJI;Database=KR_D;Trusted_Connection=True;");
            cn.Open();
            SqlCommand cmd = cn.CreateCommand();
            cmd.CommandText = "procDodajKlienta";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@parNazwa", "KB01"));
            cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@parNip", "00000002"));
            cmd.ExecuteNonQuery();  
        }

        static void Main5(string[] args)
        {
            //google:
            //ef Database.ExecuteSqlCommand

//            "INSERT dbo.klienci (nazwa, nip)" +
//            " VALUES(@parNazwa, @parNip)";

            var krdContext = new KR_DEntities();

            //Sytem.Data.SqlClient
            SqlParameter param1 = new SqlParameter("@parNazwa", "KB");
            SqlParameter param2 = new SqlParameter("@parNip", "00000002");
            krdContext.Database.ExecuteSqlCommand("procDodajKlienta @parNazwa, @parNip", param1, param2);

        }
    }
}
