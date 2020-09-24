using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Sinema_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        public OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database31.accdb");
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string sorgu ="SELECT *from kullanicilar where k_adi='"+textBox1.Text+"' and sifre='"+textBox2.Text+"'";
            OleDbCommand komut = new OleDbCommand(sorgu,baglanti);
            OleDbDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                Form2 frm2 = new Form2();
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre yanlış.");
            }

            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4();
            this.Hide();
            frm4.Show();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default["k_adi"] = textBox1.Text;
                Properties.Settings.Default["sifre"] = textBox2.Text;
            }
            else
            {
                Properties.Settings.Default[""] = textBox1.Text;
                Properties.Settings.Default[""] = textBox2.Text;
            }

            Properties.Settings.Default.Save();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           

        }
    }
}
