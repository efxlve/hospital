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
    public partial class frmDoctorDetail : Form
    {
        public frmDoctorDetail()
        {
            InitializeComponent();
        }

        SQLConnection con = new SQLConnection();

        public string ID;

        private void frmDoctorDetail_Load(object sender, EventArgs e)
        {
            lblID.Text = ID;

            #region Doctor Name-Surname
            SqlCommand command = new SqlCommand("SELECT DoctorName, DoctorSurname FROM Tbl_Doctor WHERE DoctorID = @p1", con.connect());
            command.Parameters.AddWithValue("@p1", ID);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                lblNameSurname.Text = sqlDataReader["DoctorName"].ToString() + " " + sqlDataReader["DoctorSurname"].ToString();
            }
            #endregion

            #region Appointments
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Tbl_Appointments WHERE AppointmentDoctor = '" + lblNameSurname.Text + "'", con.connect());
            sqlDataAdapter.Fill(dataTable);
            dgvAppointments.DataSource = dataTable;
            #endregion
        }

        private void btnUpdateInformation_Click(object sender, EventArgs e)
        {
            frmDoctorInfoEdit frmDoctorInfoEdit = new frmDoctorInfoEdit();
            frmDoctorInfoEdit.ID = lblID.Text;
            frmDoctorInfoEdit.ShowDialog();
        }

        private void btnAnnouncements_Click(object sender, EventArgs e)
        {
            frmAnnouncements frmAnnouncements = new frmAnnouncements();
            frmAnnouncements.ShowDialog();
        }

        private void dgvAppointments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dgvAppointments.SelectedCells[0].RowIndex;
            rchAppointmentDetails.Text = dgvAppointments.Rows[chosen].Cells[7].Value.ToString();
        }
    }
}
