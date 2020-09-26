using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //Sql bağlantısı sağlamak için bu kütüphaneyi eklemeliyiz.

namespace DatabaseExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection(" Data Source=EREN\\SQLEXPRESS;Integrated Security=True");
        private void Getir()
        {
            baglan.Open();
            SqlCommand komut = new SqlCommand("Select * from Ogrenciler.dbo.kayitlar", baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while(oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["adsoyad"].ToString();
                ekle.SubItems.Add(oku["sehir"].ToString());
                ekle.SubItems.Add(oku["bolum"].ToString());
                ekle.SubItems.Add(oku["sinif"].ToString());
                listView1.Items.Add(ekle);
               
            }
            baglan.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Getir();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
