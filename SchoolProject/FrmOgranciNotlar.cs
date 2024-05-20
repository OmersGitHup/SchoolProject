using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolProject
{
    public partial class FrmOgranciNotlar : Form
    {
        public FrmOgranciNotlar()
        {
            InitializeComponent();
        }
        public string numara;
        SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-6JPMHUC\SQLSERVERFIRST;Initial Catalog=School;Integrated Security=True");
        private void FrmOgranciNotlar_Load(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select DersAd,Sınav1,Sınav2,Sınav3,Ortalama from Tbl_Notlar inner join Tbl_Dersler on Tbl_Notlar.DersId=Tbl_Dersler.DersID where OgrId=@p1", connection);
            komut.Parameters.AddWithValue("@p1", numara);
            //this.Text = numara.ToString();
            SqlDataAdapter da=new SqlDataAdapter(komut);
            DataTable dt= new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


        }
    }
}
