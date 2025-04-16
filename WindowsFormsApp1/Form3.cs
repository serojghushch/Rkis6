﻿using System;
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
    public partial class Form3 : Form
    {
        public Model1 db { get; set; }
        public menu mn { get; set; }


        public Form3()
        {
            InitializeComponent();
        }

        private void menuBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            mn.Name = nameTextBox.Text;
            mn.Price = Convert.ToDouble(priceTextBox.Text);
            mn.Ves = Convert.ToInt32(vesTextBox.Text);

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
