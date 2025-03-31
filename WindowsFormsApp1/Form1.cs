using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.sqldata;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Model1 db = new Model1();


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            menuBindingSource.DataSource = db.menu.ToList();
        }

        private void b1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2(db);
            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                menuBindingSource.DataSource = db.menu.ToList();
            }

        }
    }
}
