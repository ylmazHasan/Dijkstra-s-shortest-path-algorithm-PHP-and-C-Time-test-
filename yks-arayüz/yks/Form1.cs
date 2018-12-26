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
using System.IO;
using System.Drawing;
using Excel = Microsoft.Office.Interop.Excel;
namespace yks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        db _vt = new db();
        private void Form1_Load(object sender, EventArgs e)
        {
            _vt.baglanti.Open();
            if (_vt.baglanti_kontrol() == "true")
            {
                MessageBox.Show("Veritabanı Bağlantısı Kuruldu");
            }
            else
            {
                MessageBox.Show(_vt.baglanti_kontrol());
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            string komut ="select * from test";
            
            MySqlDataAdapter da = new MySqlDataAdapter(komut, _vt.baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void releaseObject(object obj)
        {
      
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application Excelver = new Microsoft.Office.Interop.Excel.Application();
            Excelver.Visible = true;
            Microsoft.Office.Interop.Excel.Workbook objBook = Excelver.Workbooks.Add(System.Reflection.Missing.Value);
            Microsoft.Office.Interop.Excel.Worksheet objSheet = (Microsoft.Office.Interop.Excel.Worksheet)objBook.Worksheets.get_Item(1);
            for (int i = 0; i < dataGridView1.Columns.Count; i++) 
            {
                Microsoft.Office.Interop.Excel.Range objRange = (Microsoft.Office.Interop.Excel.Range)objSheet.Cells[1, i + 1];
                objRange.Value2 = dataGridView1.Columns[i].HeaderText;

            }
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Rows.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range objRange = (Microsoft.Office.Interop.Excel.Range)objSheet.Cells[j + 2, i + 1];
                    objRange.Value2 = dataGridView1[i, j].Value;
                }
            }


    
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }
    }
}
