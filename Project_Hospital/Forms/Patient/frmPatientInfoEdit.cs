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
    public partial class frmPatientInfoEdit : Form
    {
        public frmPatientInfoEdit()
        {
            InitializeComponent();
        }

        public string ID;
        SQLConnection con = new SQLConnection();

        private void frmPatientInfoEdit_Load(object sender, EventArgs e)
        {
            mskID.Text = ID;

            SqlCommand command = new SqlCommand("SELECT * FROM Tbl_Patient WHERE PatientID = @p1", con.connect());
            command.Parameters.AddWithValue("@p1", ID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                txtName.Text = reader["PatientName"].ToString();
                txtSurname.Text = reader["PatientSurname"].ToString();
                mskID.Text = reader["PatientID"].ToString();
                mskPhoneNumber.Text = reader["PatientPhone"].ToString();
                txtPassword.Text = reader["PatientPassword"].ToString();
                cmbGender.Text = reader["PatientGender"].ToString();
            }
            con.connect().Close();
        }

        private void btnUpdateYourInformation_Click_1(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("UPDATE Tbl_Patient SET PatientName = @p1, PatientSurname = @p2, PatientPhone = @p3, PatientPassword = @p4, PatientGender = @p5 WHERE PatientID = @p6", con.connect());
            sqlCommand.Parameters.AddWithValue("@p1", txtName.Text);
            sqlCommand.Parameters.AddWithValue("@p2", txtSurname.Text);
            sqlCommand.Parameters.AddWithValue("@p3", mskPhoneNumber.Text);
            sqlCommand.Parameters.AddWithValue("@p4", txtPassword.Text);
            sqlCommand.Parameters.AddWithValue("@p5", cmbGender.Text);
            sqlCommand.Parameters.AddWithValue("@p6", mskID.Text);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Your information has been updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.connect().Close();
        }
    }
}
