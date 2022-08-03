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
    public partial class frmBranchPanel : Form
    {
        public frmBranchPanel()
        {
               InitializeComponent();
        }

        SQLConnection con = new SQLConnection();

        private void datagridbranch()
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Tbl_Branch", con.connect());
            sqlDataAdapter.Fill(dataTable);
            dgvBranch.DataSource = dataTable;
        }

        private void clear()
        {
            txtID.Text = "";
            txtBranchName.Text = "";
        }

        private void frmBranch_Load(object sender, EventArgs e)
        {
            datagridbranch();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Tbl_Branch (BranchName) VALUES(@p1)", con.connect());
            command.Parameters.AddWithValue("@p1", txtBranchName.Text);
            command.ExecuteNonQuery();
            con.connect().Close();
            MessageBox.Show("Branch added.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            datagridbranch();
            clear();
        }

        private void dgvBranch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int chosen = dgvBranch.SelectedCells[0].RowIndex;
            txtID.Text = dgvBranch.Rows[chosen].Cells[0].Value.ToString();
            txtBranchName.Text = dgvBranch.Rows[chosen].Cells[1].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Tbl_Branch WHERE B_ID = @p1", con.connect());
            command.Parameters.AddWithValue("@p1", txtID.Text);
            command.ExecuteNonQuery();
            con.connect().Close();
            MessageBox.Show("Branch deleted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            datagridbranch();
            clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("UPDATE Tbl_Branch SET BranchName = @p1 WHERE B_ID = @p2", con.connect());
            command.Parameters.AddWithValue("@p1", txtBranchName.Text);
            command.Parameters.AddWithValue("@p2", txtID.Text);
            command.ExecuteNonQuery();
            con.connect().Close();
            MessageBox.Show("Branch updated.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            datagridbranch();
            clear();
        }
    }
}
