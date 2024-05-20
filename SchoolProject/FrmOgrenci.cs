using SchoolProject.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolProject
{
    public partial class FrmOgrenci : Form
    {
        public FrmOgrenci()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        
        DataSet1TableAdapters.DataTable1TableAdapter ds=new DataSet1TableAdapters.DataTable1TableAdapter();
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6JPMHUC\SQLSERVERFIRST;Initial Catalog=School;Integrated Security=True");

        private void FrmOgrenci_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
            
            //ComboBox Itemlerini Çekme ve Değere Göre Atama

            connection.Open();
            SqlCommand command = new SqlCommand("Select * From Tbl_Klüpler", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DisplayMember = "KulupAd";
            comboBox1.ValueMember = "KlupId";
            comboBox1.DataSource= dt;
            connection.Close();


        }
        string c = "";

        private void btnEkle_Click(object sender, EventArgs e)
        {
            
            if (radioButton1.Checked == true)
            {
                c = "Kız";
            }
            if (radioButton2.Checked == true)
            {
                c = "Erkek";
            }
            ds.OgrenciEkle(txtAd.Text, TxtSoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c);
            MessageBox.Show("Eklendi");
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.OgrenciListesi();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtId.Text = comboBox1.SelectedValue.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.OgrenciSil(int.Parse(txtId.Text));
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtSoyad.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            c=dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (c == "Erkek")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;

            }
            else
            {
                radioButton1.Checked = false;
                radioButton1.Checked = false;
            }

            if (c == "Kız")
            {
                radioButton2.Checked = false;
                radioButton1.Checked = true;


            }
            else
            {
                radioButton1.Checked = false;
                radioButton1.Checked = false;
            }

            comboBox1.Text= dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.OgrenciGuncelle(txtAd.Text, TxtSoyad.Text, byte.Parse(comboBox1.SelectedValue.ToString()), c, byte.Parse(txtId.Text));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource= ds.OgrenciAra(txtAra.Text);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
