using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoLoginApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void clearControls()
        {
            txtPassword.Text = " ";
            txtUserId.Text = " ";
            txtUserId.Focus();//means the focus should go to the username 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dbAisDataSet.tblusers' table. You can move, or remove it, as needed.
            this.tblusersTableAdapter.Fill(this.dbAisDataSet.tblusers);
            clearControls();
        }

        private void btmLogin_Click(object sender, EventArgs e)
        {

            if(txtUserId.Text.Length < 2)
            {
                MessageBox.Show("Please enter correct id");
                txtUserId.Focus();
                return;
            }
            else if(txtPassword.Text.Length <4)
            {
                MessageBox.Show("Please enter correct password");
                txtPassword.Focus();
                return;
            }

            object  found = tblusersTableAdapter.ValidateUser(txtUserId.Text, txtPassword.Text);
            if(found == null)
            {
                MessageBox.Show("Invalid id or password");
                txtUserId.Focus();
                return;
                //return from this method
            }
            else
            {
                MessageBox.Show("Welcome to" + found);

            }
            clearControls();
        }

        private void btmCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
