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
    public partial class FrmKulup : Form
    {
        public FrmKulup()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6JPMHUC\SQLSERVERFIRST;Initial Catalog=School;Integrated Security=True");
        private void FrmKulup_Load(object sender, EventArgs e)
        {
            
        }
        void listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Klüpler", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKlupId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKlupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Insert Into Tbl_Klüpler (KulupAd) values (@p1)", connection);
            command.Parameters.AddWithValue("@p1", txtKlupAd.Text);
            command.ExecuteNonQuery();
            connection.Close    ();
            MessageBox.Show("Klüp Added","Info",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.LightYellow;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.BackColor = Color.Transparent;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Delete From Tbl_Klüpler where KlupId=@p1 ", connection);
            command.Parameters.AddWithValue("@p1", txtKlupId.Text);
            command.ExecuteNonQuery();
            connection.Close ();
            MessageBox.Show("Klüp Silindi");
            listele();

        }

        private void button3_Click(object sender, EventArgs e)
        {
             connection.Open();
            SqlCommand command = new SqlCommand("Update Tbl_Klüpler set KulupAd=@p1 where KlupId=@p2 ", connection);
            command.Parameters.AddWithValue("@p1", txtKlupAd.Text);
            command.Parameters.AddWithValue("@p2", txtKlupId.Text);
            command.ExecuteNonQuery();
            connection.Close ();
            MessageBox.Show("Klüp Güncellendi");
            listele();
        }
    }
}
