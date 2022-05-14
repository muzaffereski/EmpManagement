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
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        int StartPoint=0;

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            StartPoint += 1;
            guna2CircleProgressBar1.Value = StartPoint;
            if (guna2CircleProgressBar1.Value==100)
            {

                guna2CircleProgressBar1.Value = 0;
                timer1.Stop();
                this.Hide();
                Login  log = new Login();
                log.Show();
            }
        }
        private void Splash_Load(object sender, EventArgs e)
        {
            timer1.Start();
            
        }
    }
}
