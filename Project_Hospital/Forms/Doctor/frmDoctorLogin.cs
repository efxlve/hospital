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

namespace Project_Hospital
{
    public partial class frmDoctorLogin : Form
    {
        public frmDoctorLogin()
        {
            InitializeComponent();
        }

        SQLConnection con = new SQLConnection();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Tbl_Doctor WHERE DoctorID = @p1 AND DoctorPassword = @p2", con.connect());
            command.Parameters.AddWithValue("@p1", txtID.Text);
            command.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.Read())
            {
                frmDoctorDetail frm = new frmDoctorDetail();
                frm.ID = txtID.Text;
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid ID or Password");
            }
            con.connect().Close();
        }
    }
}
