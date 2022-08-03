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
    public partial class frmDoctorInfoEdit : Form
    {
        public frmDoctorInfoEdit()
        {
            InitializeComponent();
        }

        SQLConnection con = new SQLConnection();

        public string ID;

        private void frmDoctorInfoEdit_Load(object sender, EventArgs e)
        {
            mskID.Text = ID;

            SqlCommand command = new SqlCommand("SELECT * FROM Tbl_Doctor WHERE DoctorID = @p1", con.connect());
            command.Parameters.AddWithValue("@p1", ID);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                txtName.Text = sqlDataReader["DoctorName"].ToString();
                txtSurname.Text = sqlDataReader["DoctorSurname"].ToString();
                cmbBranch.Text = sqlDataReader["DoctorBranch"].ToString();
                txtPassword.Text = sqlDataReader["DoctorPassword"].ToString();
            }
            con.connect().Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("UPDATE Tbl_Doctor SET DoctorName = @p1, DoctorSurname = @p2, DoctorBranch = @p3, DoctorPassword = @p4 WHERE DoctorID = @p5", con.connect());
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", cmbBranch.Text);
            command.Parameters.AddWithValue("@p4", txtPassword.Text);
            command.Parameters.AddWithValue("@p5", mskID.Text);
            command.ExecuteNonQuery();
            con.connect().Close();
            MessageBox.Show("Your information has been updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
