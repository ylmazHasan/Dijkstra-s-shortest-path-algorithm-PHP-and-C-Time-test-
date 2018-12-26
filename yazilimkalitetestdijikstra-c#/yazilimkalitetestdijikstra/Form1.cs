using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace yazilimkalitetestdijikstra
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
        private void button1_Click(object sender, EventArgs e)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
        

            Graph g = new Graph();
            g.add_vertex('A', new Dictionary<char, int>() { { 'B', 7 }, { 'C', 8 } });
            g.add_vertex('B', new Dictionary<char, int>() { { 'A', 7 }, { 'F', 2 } });
            g.add_vertex('C', new Dictionary<char, int>() { { 'A', 8 }, { 'F', 6 }, { 'G', 4 } });
            g.add_vertex('D', new Dictionary<char, int>() { { 'F', 8 } });
            g.add_vertex('E', new Dictionary<char, int>() { { 'H', 1 } });
            g.add_vertex('F', new Dictionary<char, int>() { { 'B', 2 }, { 'C', 6 }, { 'D', 8 }, { 'G', 9 }, { 'H', 3 } });
            g.add_vertex('G', new Dictionary<char, int>() { { 'C', 4 }, { 'F', 9 } });
            g.add_vertex('H', new Dictionary<char, int>() { { 'E', 1 }, { 'F', 3 } });

            g.shortest_path('A', 'H').ForEach(x => Console.Write(listBox1.Items.Add(x)));
            sw.Stop();
            label1.Text=sw.ElapsedMilliseconds.ToString();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            _vt.kmt.Connection = _vt.baglanti;
            _vt.kmt.CommandText = "insert into test(zaman,gelistirmedili) values('" + label1.Text + "','"+textBox1.Text+"')";
            _vt.kmt.ExecuteNonQuery();
        }

        
    }
}
