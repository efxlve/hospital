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
    public partial class frmPatientRegister : Form
    {
        public frmPatientRegister()
        {
            InitializeComponent();
        }

        SQLConnection con = new SQLConnection();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Tbl_Patient (PatientName,PatientSurname,PatientID,PatientPhone,PatientPassword,PatientGender) VALUES (@p1,@p2,@p3,@p4,@p5,@p6)", con.connect());
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", mskID.Text);
            command.Parameters.AddWithValue("@p4", mskPhoneNumber.Text);
            command.Parameters.AddWithValue("@p5", txtPassword.Text);
            command.Parameters.AddWithValue("@p6", cmbGender.Text);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                command.ExecuteNonQuery();
                MessageBox.Show("Registration Successful!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clear();
            }
            else
            {
                MessageBox.Show("Invalid ID or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.connect().Close();
        }

        private void clear()
        {
            txtName.Text = "";
            txtSurname.Text = "";
            mskID.Text = "";
            mskPhoneNumber.Text = "";
            txtPassword.Text = "";
            cmbGender.Text = "";
        }
    }
}
