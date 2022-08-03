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
    public partial class frmSecretaryDetail : Form
    {
        public frmSecretaryDetail()
        {
            InitializeComponent();
        }

        public string ID;
        SQLConnection con = new SQLConnection();

        private void frmSecretaryDetail_Load(object sender, EventArgs e)
        {
            lblID.Text = ID;

            #region Information
            SqlCommand command = new SqlCommand("SELECT SecretaryNameSurname FROM Tbl_Secretary WHERE SecretaryID = @p1", con.connect());
            command.Parameters.AddWithValue("@p1", ID);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                lblNameSurname.Text = sqlDataReader["SecretaryNameSurname"].ToString();
            }
            con.connect().Close();
            #endregion

            #region DataGrid Branch
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Tbl_Branch", con.connect());
            sqlDataAdapter.Fill(dataTable);
            dgvBranches.DataSource = dataTable;
            #endregion

            #region DataGrid Doctor
            DataTable dataTable1 = new DataTable();
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("SELECT (DoctorName + ' ' + DoctorSurname) as 'Doctors', DoctorBranch as 'Branches' FROM Tbl_Doctor", con.connect());
            sqlDataAdapter1.Fill(dataTable1);
            dgvDoctors.DataSource = dataTable1;
            #endregion

            #region ComboBox Branch
            SqlCommand command1 = new SqlCommand("SELECT BranchName FROM Tbl_Branch", con.connect());
            SqlDataReader sqlDataReader1 = command1.ExecuteReader();
            while (sqlDataReader1.Read())
            {
                cmbBranch.Items.Add(sqlDataReader1["BranchName"].ToString());
            }
            con.connect().Close();
            #endregion
        }

        void clear()
        {
            mskDate.Text = "";
            mskTime.Text = "";
            cmbBranch.Text = "";
            cmbDoctor.Text = "";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Tbl_Appointments (AppointmentDate, AppointmentTime, AppointmentBranch, AppointmentDoctor) VALUES (@p1, @p2, @p3, @p4)", con.connect());
            sqlCommand.Parameters.AddWithValue("@p1", mskDate.Text);
            sqlCommand.Parameters.AddWithValue("@p2", mskTime.Text);
            sqlCommand.Parameters.AddWithValue("@p3", cmbBranch.Text);
            sqlCommand.Parameters.AddWithValue("@p4", cmbDoctor.Text);
            sqlCommand.ExecuteNonQuery();
            con.connect().Close();
            MessageBox.Show("Appointment Created!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            clear();
        }

        private void cmbBranch_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoctor.Items.Clear();
            SqlCommand command = new SqlCommand("SELECT DoctorName, DoctorSurname FROM Tbl_Doctor WHERE DoctorBranch = @p1", con.connect());
            command.Parameters.AddWithValue("@p1", cmbBranch.Text);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                cmbDoctor.Items.Add(sqlDataReader["DoctorName"].ToString() + " " + sqlDataReader["DoctorSurname"].ToString());
            }
            con.connect().Close();
        }

        private void btnCreateAnnouncement_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Tbl_Announcements (Announcement) VALUES (@p1)", con.connect());
            command.Parameters.AddWithValue("@p1", rchAnnouncement.Text);
            command.ExecuteNonQuery();
            con.connect().Close();
            MessageBox.Show("Announcement created.");
        }

        private void btnDoctorPanel_Click(object sender, EventArgs e)
        {
            frmDoctorPanel frmDoctorPanel = new frmDoctorPanel();
            frmDoctorPanel.Show();
        }

        private void btnBranchPanel_Click(object sender, EventArgs e)
        {
            frmBranchPanel frmBranchPanel = new frmBranchPanel();
            frmBranchPanel.Show();
        }

        private void btnAppointmentList_Click(object sender, EventArgs e)
        {
            frmAppointmentList frmAppointmentList = new frmAppointmentList();
            frmAppointmentList.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAnnouncements frmAnnouncements = new frmAnnouncements();
            frmAnnouncements.Show();
        }
    }
}
