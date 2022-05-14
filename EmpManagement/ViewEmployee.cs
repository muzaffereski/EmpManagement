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
    public partial class ViewEmployee : Form
    {
        public ViewEmployee()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-OS8Q8BAP\SQLEXPRESS;Initial Catalog=MyEmployeeDb;Integrated Security=True");

        private void fetchempdata()
        {
            con.Open();
            string query = "select * from EmployeeTbl where EmpId='" + EmpidTb.Text + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda= new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                empidlbl.Text =dr["EmpId"].ToString();
                empnamlbl.Text = dr["EmpName"].ToString();
                empaddlbl.Text = dr["EmpAdd"].ToString();
                empposlbl.Text = dr["EmpPos"].ToString();
                empdoblbl.Text = dr["EmpDOB"].ToString();
                emppholbl.Text = dr["EmpPhone"].ToString();
                empedulbl.Text = dr["EmpEdu"].ToString();
                empgenlbl.Text = dr["EmpGender"].ToString();
                empidlbl.Visible = true;
                empnamlbl.Visible = true;
                empaddlbl.Visible = true;
                empposlbl.Visible = true;
                empdoblbl.Visible = true;
                emppholbl.Visible = true;
                empedulbl.Visible = true;
                empgenlbl.Visible = true;


            }


            con.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ViewEmployee_Load(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog()== DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("===== EMPLOYEE SUMMARY =====",new Font("Century Gothic",20,FontStyle.Bold ),Brushes.Red,new Point(200));
            

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
