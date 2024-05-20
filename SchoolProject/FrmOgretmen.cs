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
    public partial class FrmOgretmen : Form
    {
        public FrmOgretmen()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKulup frm= new FrmKulup();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDersler frm= new FrmDersler();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmTeacherNotes frm= new FrmTeacherNotes();
            frm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmOgrenci frm= new FrmOgrenci();
            frm.Show();
        }
    }
}
