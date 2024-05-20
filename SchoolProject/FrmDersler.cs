using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolProject
{
    public partial class FrmDersler : Form
    {
        public FrmDersler()
        {
            InitializeComponent();
        }
        DataSet1TableAdapters.Tbl_DerslerTableAdapter ds = new DataSet1TableAdapters.Tbl_DerslerTableAdapter();

        private void FrmDersler_Load(object sender, EventArgs e)
        {
            
            dataGridView1.DataSource = ds.DersListesi();
        }//SchoolConnectionString

        private void btnEkle_Click(object sender, EventArgs e)
        {
            ds.DersEkle(txtKlupAd.Text);
            MessageBox.Show("Ders Eklendi");
            dataGridView1.DataSource = ds.DersListesi();

        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            ds.DersSil(byte.Parse(txtKlupId.Text));
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            ds.DersGuncelle(txtKlupAd.Text, byte.Parse(txtKlupId.Text));
            dataGridView1.DataSource = ds.DersListesi();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtKlupAd.Text="";
            txtKlupId.Text = "";
            txtKlupId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtKlupAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
        }
    }
}
