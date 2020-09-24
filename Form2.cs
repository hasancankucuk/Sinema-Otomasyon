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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database31.accdb");
        OleDbCommand komut;
        OleDbDataReader oku;
        private void Form6_Load(object sender, EventArgs e)
        {
            baglanti.Open();

            OleDbCommand komut = new OleDbCommand("SELECT *from filmbilgisi", baglanti);
            OleDbDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["f_ad"]);
            }
            baglanti.Close();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 30, y = 30;

            for (int j = 0; j < 6; j++)
            {
                for (char a = 'A'; a <= 'F'; a++)
                {
                    for (int k = 0; k < 13; k++)
                    {
                        
                        Button btn = new Button();
                        btn.Text = (k + 1).ToString() + a.ToString();
                        btn.BackColor = Color.Green;
                        btn.Size = new Size(30, 30);
                        btn.Location = new Point(x, y);
                        x += 30;
                        btn.Click += Btn_Click;
                        flowLayoutPanel4.Controls.Add(btn);
                    }
                    x = 30;
                    y += 30;
                }
            }
            
            for (char i = 'A'; i <= 'F'; i++)
                    {
                      Button btn = new Button();
                      btn.Text = i.ToString();
                      btn.BackColor = Color.Green;
                      btn.Size = new Size(30, 30);
                      btn.Location = new Point(x, y);
                      flowLayoutPanel1.Controls.Add(btn);
                      btn.Enabled = false;
                    }
    
                for (int i = 0; i < 3; i++)
                {
                      for (char a = 'G'; a < 'K'; a++)
                      {
                          for (int k = 0; k < 13; k++)
                          {
                              Button btn = new Button();
                              btn.Text = (k + 1).ToString() + a.ToString();
                              btn.BackColor = Color.Green;
                              btn.Size = new Size(30, 30);
                              btn.Location = new Point(x, y);
                              x += 30;
                              flowLayoutPanel2.Controls.Add(btn);
                              x += 30;
                              btn.Click += Btn_Click;
                          }
                          x = 30;
                          y += 30;
                      }

                }
                    for (char i = 'G'; i < 'K'; i++)
                    {
                        Button btn = new Button();
                        btn.Text = i.ToString();
                        btn.BackColor = Color.Green;
                        btn.Size = new Size(30, 30);
                        btn.Location = new Point(x, y);
                        flowLayoutPanel5.Controls.Add(btn);
                    }


                for (int i = 0; i < 5; i++)
                 {
                      for (char a = 'K'; a < 'O'; a++)
                      {
                          for (int k = 0; k < 13; k++)
                          {
                              Button btn = new Button();
                              btn.Text = (k + 1).ToString() + a.ToString();
                              btn.BackColor = Color.Green;
                              btn.Size = new Size(30, 30);
                              btn.Location = new Point(x, y);
                              x += 30;
                              flowLayoutPanel3.Controls.Add(btn);
                              btn.Click += Btn_Click;
                          }
                          x = 30;
                          y += 30;
                      }
                }

                  for (char i = 'K'; i < 'O'; i++)
                  {
                      Button btn = new Button();
                      btn.Text = i.ToString();
                      btn.BackColor = Color.Green;
                      btn.Size = new Size(30, 30);
                      btn.Location = new Point(x, y);
                      flowLayoutPanel6.Controls.Add(btn);
                      btn.Enabled = false;
                  }

           /* foreach (Button item in flowLayoutPanel4.Controls)
            {
                baglanti.Open();
                komut = new OleDbCommand("select * from biletler", baglanti);
                oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    if (oku["Kimlik"].ToString()==comboBox1.SelectedItem.ToString()+comboBox2.SelectedItem.ToString()+comboBox3.SelectedItem.ToString()+item.Text)
                    {
                        item.BackColor = Color.Gray;
                    }
                }

                baglanti.Close();
            }
            foreach (Button item in flowLayoutPanel2.Controls)
            {
                baglanti.Open();
                komut = new OleDbCommand("select * from biletler", baglanti);
                oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    if (oku["Kimlik"].ToString() == comboBox1.SelectedItem.ToString() + comboBox2.SelectedItem.ToString() + comboBox3.SelectedItem.ToString() + item.Text)
                    {
                        item.BackColor = Color.Gray;
                    }
                }

                baglanti.Close();
            }
            foreach (Button item in flowLayoutPanel3.Controls)
            {
                baglanti.Open();
                komut = new OleDbCommand("select * from biletler", baglanti);
                oku = komut.ExecuteReader();

                while (oku.Read())
                {
                    if (oku["Kimlik"].ToString() == comboBox1.SelectedItem.ToString() + comboBox2.SelectedItem.ToString() + comboBox3.SelectedItem.ToString() + item.Text)
                    {
                        item.BackColor = Color.Gray;
                    }
                }

                baglanti.Close();
            }*/
        }
        public void Btn_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            Button btn = (sender as Button);
            btn.BackColor = Color.Pink;
            btn.Enabled = false;

            string sorgu = "insert into biletler (koltuk,film_adi,seans,salon) values('" + btn.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "')";
            OleDbCommand komut = new OleDbCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
            this.Hide();
        }


 
    }
}
