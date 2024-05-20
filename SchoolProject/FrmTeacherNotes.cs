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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SchoolProject
{
    public partial class FrmTeacherNotes : Form
    {
        public FrmTeacherNotes()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_NotlarTableAdapter ds = new DataSet1TableAdapters.Tbl_NotlarTableAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.NotListesi(int.Parse(txtId.Text));

        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6JPMHUC\SQLSERVERFIRST;Initial Catalog=School;Integrated Security=True");


        private void FrmTeacherNotes_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From Tbl_Dersler", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cmbDers.DisplayMember = "DersAd";
            cmbDers.ValueMember = "DersID";
            cmbDers.DataSource = dt;
            connection.Close();
        }
        int notid;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           notid= int.Parse(dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString()); 
           // txtId.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
           cmbDers.Text= dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtSınav1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSınav2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtSınav3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtProje.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtOrtalama.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDurum.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

        }
        int sinav1, sinav2, sinav3, proje;
        double ortalama;
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            
            string durum;
            sinav1 = Convert.ToInt16(txtSınav1.Text);
            sinav2 = Convert.ToInt16(txtSınav2.Text);
            sinav3 = Convert.ToInt16(txtSınav3.Text);
            proje = Convert.ToInt16(txtProje.Text);
            ortalama = (sinav1 + sinav2 + sinav3 + proje) / 4;
            txtOrtalama.Text=ortalama.ToString();
            if (ortalama>=50)
            {
                txtDurum.Text = "True";
            }
            else
            {
                txtDurum.Text="False";
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.NotGuncelle(byte.Parse(cmbDers.SelectedValue.ToString()), int.Parse(txtId.Text), byte.Parse(txtSınav1.Text), byte.Parse(txtSınav2.Text), byte.Parse(txtSınav3.Text), byte.Parse(txtProje.Text), decimal.Parse(txtOrtalama.Text), bool.Parse(txtDurum.Text), notid);
            MessageBox.Show("Not Güncellendi");
        }
    }
}
