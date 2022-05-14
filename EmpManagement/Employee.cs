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
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }
        SqlConnection con=new SqlConnection(@"Data Source=LAPTOP-OS8Q8BAP\SQLEXPRESS;Initial Catalog=MyEmployeeDb;Integrated Security=True");

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text==""|| EmpNameTb.Text=="" ||EmpPhoneTb.Text==""||EmpAddTb.Text=="")
            {
                MessageBox.Show("Missing İnformation");

            }
            else
            {
                try
                {
                    con.Open();
                    string query ="insert into EmployeeTbl values('" +EmpIdTb.Text+"','"+EmpNameTb.Text+ "','"+EmpAddTb.Text +"','"
                        + EmpPosCb.SelectedItem.ToString() + "','" + EmpDob.Value.Date + "','"+EmpPhoneTb.Text+ "','"
                        + EmpEduCb.SelectedItem.ToString() + "','"+ EmpGenCb.SelectedItem.ToString()+ "')";
                    SqlCommand cmd= new SqlCommand(query,con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee added succesful");
                    con.Close();
                    Populate();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void label10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Populate()
        {
            con.Open();
            string query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query,con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmpDGV.DataSource = ds.Tables[0];
            con.Close();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            Populate();
        }

        private void bunifuThinButton24_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text=="")
            {
                MessageBox.Show("Add Employee Id ");
            }
            else
            {
                try
                {
                    con.Open();
                    string query = "delete from EmployeeTbl where EmpId='" + EmpIdTb.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee deleted successfully ");
                    con.Close();
                    Populate();

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            

        }

        private void EmpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmpIdTb.Text= EmpDGV.SelectedRows[0].Cells[0].Value.ToString();
            EmpNameTb.Text= EmpDGV.SelectedRows[0].Cells[1].Value.ToString();
            EmpAddTb.Text= EmpDGV.SelectedRows[0].Cells[2].Value.ToString();
            EmpPosCb.Text= EmpDGV.SelectedRows[0].Cells[3].Value.ToString();
            EmpDob.Text= EmpDGV.SelectedRows[0].Cells[4].Value.ToString();
            EmpPhoneTb.Text= EmpDGV.SelectedRows[0].Cells[5].Value.ToString();
            EmpEduCb.Text= EmpDGV.SelectedRows[0].Cells[6].Value.ToString();
            EmpGenCb.Text= EmpDGV.SelectedRows[0].Cells[7].Value.ToString();



        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            if (EmpIdTb.Text == "" || EmpNameTb.Text == "" || EmpPhoneTb.Text == "" || EmpAddTb.Text == "")
            {
                MessageBox.Show("Missing İnformation");

            }
            else
            {
                try
                {
                    con.Open();
                    string query = "Update EmployeeTbl Set EmpName='" + EmpNameTb.Text + "',EmpAdd='" + EmpAddTb.Text +
                        "',EmpPos='" + EmpPosCb.SelectedItem.ToString() + "',EmpDOB='" + EmpDob.Value.Date + "',EmpPhone='" + EmpPhoneTb.Text +
                        "',EmpEdu='" + EmpEduCb.SelectedItem.ToString() + "',EmpGender='" + EmpGenCb.SelectedItem.ToString() +
                        "' Where EmpId='" + EmpIdTb.Text + "'; ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();

                    con.Close();
                    Populate();

                   


                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void bunifuThinButton23_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void EmpPosCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
