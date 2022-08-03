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
    public partial class frmPatientLogin : Form
    {
        public frmPatientLogin()
        {
            InitializeComponent();
        }

        SQLConnection con = new SQLConnection();

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPatientRegister frmPatientRegister = new frmPatientRegister();
            frmPatientRegister.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Tbl_Patient WHERE PatientID = @p1 AND PatientPassword = @p2", con.connect());
            command.Parameters.AddWithValue("@p1", txtID.Text);
            command.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                frmPatientDetail frmPatientDetail = new frmPatientDetail();
                frmPatientDetail.ID = txtID.Text;
                frmPatientDetail.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid ID or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.connect().Close();
        }
    }
}
