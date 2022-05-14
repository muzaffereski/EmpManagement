using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpManagement
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (useridtb.Text=="" || guna2TextBox2.Text=="")
            {
                MessageBox.Show("Enter id and password");
            }
            else if (useridtb.Text == "Admin" && guna2TextBox2.Text == "5858")
            {
                Home home = new Home();
                home.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("wrong id or password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            useridtb.Text = "";
            guna2TextBox2.Text = "";
        }
    }
}
