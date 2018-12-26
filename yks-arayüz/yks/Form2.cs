using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace yks
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        db _vt = new db();
        private void Form2_Load(object sender, EventArgs e)
        {
            _vt.baglanti.Open();
            MySqlCommand komut = new MySqlCommand("Select zaman,gelistirmedili from test ",_vt.baglanti);
            MySqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                chart1.Series["Zaman"].Points.AddXY(oku[1].ToString(),oku[0].ToString());
            }
            _vt.baglanti.Close();

        }
    }
}
