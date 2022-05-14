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

namespace EmpManagement
{
    public partial class Salary : Form
    {
        public Salary()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-OS8Q8BAP\SQLEXPRESS;Initial Catalog=MyEmployeeDb;Integrated Security=True");

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }
        private void fetchempdata()
        {
            if (EmpIdTb.Text == "")
            {
                MessageBox.Show("enter valid Id");
            }
            else
            {
                con.Open();
                string query = "select * from EmployeeTbl where EmpId='" + EmpIdTb.Text + "'";
                SqlCommand cmd = new SqlCommand(query, con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);


                foreach (DataRow dr in dt.Rows)
                {
                   
                    EmpNameTb.Text = dr["EmpName"].ToString();
                    EmpPosTb.Text = dr["EmpPos"].ToString();

                }
                con.Close();

            }
            
        }

        private void Salary_Load(object sender, EventArgs e)
        {
            

        }
        int Dailybase;

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (EmpPosTb.Text=="")
            {
                MessageBox.Show("Enter valid position");
            }
            else if (EmpWorTb.Text==""||Convert.ToInt32( EmpWorTb.Text) >28)
            {
                MessageBox.Show("Enter a number of days");
            }
            else
            {
                if (EmpPosTb.Text=="Manager")
                {
                    Dailybase = 250;
                }
                else if (EmpPosTb.Text == "Senior Developer")
                {
                    Dailybase = 230;
                }
                else if (EmpPosTb.Text == "Junior Developer")
                {
                    Dailybase = 210;
                }
                else 
                {
                    Dailybase = 150;
                }
            }
            int Total = Dailybase * Convert.ToInt32(EmpWorTb.Text);
            SalarySlip.Text ="Employee Id = "+EmpNameTb.Text+"\n"+"Employee Position = "+EmpPosTb.Text+"\n"+"Daily Gain = "+
                Dailybase.ToString()+"\n"+"Total Price = "+Total;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
