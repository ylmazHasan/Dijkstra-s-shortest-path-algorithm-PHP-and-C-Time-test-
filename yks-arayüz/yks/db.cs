using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using MySql.Data;

namespace yks
{
    class db
    {
        public static string ConnStr = ConfigurationManager.ConnectionStrings["MySQL"].ToString();
        public MySqlConnection baglanti = new MySqlConnection(ConnStr);
        public MySqlCommand kmt = new MySqlCommand(ConnStr);
        public string baglanti_kontrol()
        {
            try
            {
                //     baglanti.Open();
                return "true";

            }
            catch (MySqlException ex)
            {
                return ex.Message;
            }
        }
    }
}
