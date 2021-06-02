using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace PETT
{
    class Testdata
    {

        private static Random r = new Random();


        //Generate own data
        public static string MaakBsn()
        {
            int rest;
            string bsn;

            do
            {
                bsn = ""; int total = 0; for (int i = 0; i < 8; i++)
                {
                    int rndDigit = r.Next(0, 9);
                    total += rndDigit * (9 - i);
                    bsn += rndDigit;
                }
                rest = total % 11;
            }
            while (rest > 9);
            return bsn + rest;
        }

        public static string MaakGeboortedatum()
        {
            DateTime start = new DateTime(1960, 1, 1);
            DateTime end = DateTime.Today.AddMonths(-12 * 18);

            int range = (end - start).Days;

            DateTime GeboorteDatum = start.AddDays(r.Next(range));
            String GeboorteDatumString = GeboorteDatum.ToString("yyyy-MM-dd");

            return GeboorteDatumString;
        }

        public static string MaakIBAN()
        {
            string iban = "NL07ABNA0224668536";
            return iban;
        }

        public static string MaakVandaag()
        {
            DateTime Vandaag = DateTime.Today;
            String VandaagString = Vandaag.ToString("yyyy-MM-dd");

            return VandaagString;
        }


        //ReadDatabase 
        //DSW

        static string ConnectionString = "";
        static SqlConnection SQLC = new SqlConnection(ConnectionString);



        public static void SaveGegevens()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("");
            String sql = sb.ToString();


            using (SqlCommand command = new SqlCommand(sql, SQLC))
            {
                SQLC.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    reader.Read();
                    while (reader.Read())
                    {

                    }

                }
                SQLC.Close();
            }
        }

    }    
    
}

