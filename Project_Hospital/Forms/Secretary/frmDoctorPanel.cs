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
    public partial class frmDoctorPanel : Form
    {
        public frmDoctorPanel()
        {
            InitializeComponent();
        }

        SQLConnection con = new SQLConnection();

        private void datagridupdate()
        {
            DataTable dataTable1 = new DataTable();
            SqlDataAdapter sqlDataAdapter1 = new SqlDataAdapter("SELECT * FROM Tbl_Doctor", con.connect());
            sqlDataAdapter1.Fill(dataTable1);
            dgvDoctors.DataSource = dataTable1;
        }

        private void frmDoctorPanel_Load(object sender, EventArgs e)
        {
            #region DataGrid Doctor
            datagridupdate();
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Tbl_Doctor (DoctorName, DoctorSurname, DoctorBranch, DoctorID, DoctorPassword) VALUES (@p1, @p2, @p3, @p4, @p5)", con.connect());
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", cmbBranch.Text);
            command.Parameters.AddWithValue("@p4", txtID.Text);
            command.Parameters.AddWithValue("@p5", txtPassword.Text);
            command.ExecuteNonQuery();
            con.connect().Close();
            MessageBox.Show("Doctor added.", "Information", MessageBoxButtons.OK,MessageBoxIcon.Information);
            datagridupdate();
        }

        private void dgvDoctors_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dgvDoctors.SelectedCells[0].RowIndex;
            txtName.Text = dgvDoctors.Rows[chosen].Cells[1].Value.ToString();
            txtSurname.Text = dgvDoctors.Rows[chosen].Cells[2].Value.ToString();
            cmbBranch.Text = dgvDoctors.Rows[chosen].Cells[3].Value.ToString();
            txtID.Text = dgvDoctors.Rows[chosen].Cells[4].Value.ToString();
            txtPassword.Text = dgvDoctors.Rows[chosen].Cells[5].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Tbl_Doctor WHERE DoctorID = @p1", con.connect());
            command.Parameters.AddWithValue("@p1", txtID.Text);
            command.ExecuteNonQuery();
            con.connect().Close();
            MessageBox.Show("Doctor deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            datagridupdate();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("UPDATE Tbl_Doctor SET DoctorName = @p1, DoctorSurname = @p2, DoctorBranch = @p3, DoctorPassword = @p5 WHERE DoctorID = @p4", con.connect());
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtSurname.Text);
            command.Parameters.AddWithValue("@p3", cmbBranch.Text);
            command.Parameters.AddWithValue("@p4", txtID.Text);
            command.Parameters.AddWithValue("@p5", txtPassword.Text);
            command.ExecuteNonQuery();
            con.connect().Close();
            MessageBox.Show("Doctor updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            datagridupdate();
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }
    }
}
