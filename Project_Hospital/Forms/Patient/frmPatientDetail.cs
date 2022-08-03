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
    public partial class frmPatientDetail : Form
    {
        public frmPatientDetail()
        {
            InitializeComponent();
        }

        public string ID;

        SQLConnection con = new SQLConnection();

        private void frmPatientDetail_Load(object sender, EventArgs e)
        {
            lblID.Text = ID;

            #region Information
            SqlCommand command = new SqlCommand("SELECT PatientName, PatientSurname FROM Tbl_Patient WHERE PatientID = @p1", con.connect());
            command.Parameters.AddWithValue("@p1", ID);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblNameSurname.Text = reader["PatientName"].ToString() + " " + reader["PatientSurname"].ToString();
            }
            con.connect().Close();
            #endregion

            #region Appointment History
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Tbl_Appointments WHERE PatientID = " + ID, con.connect());
            sqlDataAdapter.Fill(dataTable);
            dgvAppointmentsHistory.DataSource = dataTable;
            #endregion

            #region Branch
            SqlCommand command1 = new SqlCommand("SELECT BranchName FROM Tbl_Branch", con.connect());
            SqlDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                cmbBranch.Items.Add(reader1["BranchName"].ToString());
            }
            con.connect().Close();
            #endregion
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoctor.Items.Clear();
            SqlCommand command = new SqlCommand("SELECT DoctorName, DoctorSurname FROM Tbl_Doctor WHERE DoctorBranch = @p1", con.connect());
            command.Parameters.AddWithValue("@p1", cmbBranch.SelectedItem.ToString());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                cmbDoctor.Items.Add(reader["DoctorName"].ToString() + " " + reader["DoctorSurname"].ToString());
            }
            con.connect().Close();
        }

        private void cmbDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Tbl_Appointments WHERE AppointmentBranch = '" + cmbBranch.Text + "'" + " AND AppointmentDoctor = '" + cmbDoctor.Text + "' AND AppointmentStatus = 0", con.connect());
            sqlDataAdapter.Fill(dataTable);
            dgvActiveAppointments.DataSource = dataTable;
        }

        private void dgvActiveAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dgvActiveAppointments.SelectedCells[0].RowIndex;
            txtID.Text = dgvActiveAppointments.Rows[chosen].Cells[0].Value.ToString();
        }

        private void btnMakeAnAppointment_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("UPDATE Tbl_Appointments SET AppointmentStatus = 1, PatientID = @p1, AppointmentComplaint = @p2 WHERE A_ID = @p3", con.connect());
            command.Parameters.AddWithValue("@p1", ID);
            command.Parameters.AddWithValue("@p2", rchComplaints.Text);
            command.Parameters.AddWithValue("@p3", txtID.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Appointment has been made successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.connect().Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            frmPatientInfoEdit frmPatientInfoEdit = new frmPatientInfoEdit();
            frmPatientInfoEdit.ID = ID;
            frmPatientInfoEdit.ShowDialog();
        }
    }
}
