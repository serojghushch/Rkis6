using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.sqldata;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        Model1 db;
        public Form2(Model1 db_)
        {
            InitializeComponent();
            db = db_;
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void b1_Click(object sender, EventArgs e)
        {
            menu m2 = new menu();
            if(iDTextBox.Text == ""|| nameTextBox.Text == ""||priceTextBox.Text == ""|| vesTextBox.Text == "")
            {
                MessageBox.Show("Нужно ввести требуемые данные");
            }
            int id; int price; int ves;
            bool a; bool b; bool c;

            a = int.TryParse(iDTextBox.Text, out id);
            b = int.TryParse(priceTextBox.Text,out price);
            c = int.TryParse(vesTextBox.Text,out ves);

            if(a == false )
            {
                MessageBox.Show("Неверный формат ID - " + iDTextBox.Text);
                return;
            }
            if ( b == false )
            {
                MessageBox.Show("Неверный формат price - " + priceTextBox.Text);
                return;
            }
            if (c == false)
            {
                MessageBox.Show("Неверный формат ves - " + vesTextBox.Text);
                return;
            }

            m2.ID = id;
            m2.Name = nameTextBox.Text;
            m2.Price = price;
            m2.Ves = ves;
            db.menu.Add(m2);
            try
            {
                db.SaveChanges();
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.InnerException.InnerException.Message);
            }
        }

    }
}
