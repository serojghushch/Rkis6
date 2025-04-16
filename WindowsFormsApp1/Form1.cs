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

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            menu mn = (menu)menuBindingSource.Current;
            frm.db = db;
            frm.mn = mn;

            DialogResult dr = frm.ShowDialog();
            if (dr == DialogResult.OK)
            {
                menuBindingSource.DataSource = db.menu.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu mn = (menu)menuBindingSource.Current;

            DialogResult dr = MessageBox.Show
                (
                "Вы действительно хотите удалить?" + mn.ID.ToString(),
                "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.menu.Remove(mn);
            }
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            menuBindingSource.DataSource = db.menu.ToList();



        }
    }
}
