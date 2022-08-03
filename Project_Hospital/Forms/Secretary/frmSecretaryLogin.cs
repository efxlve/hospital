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
    public partial class frmSecretaryLogin : Form
    {
        public frmSecretaryLogin()
        {
            InitializeComponent();
        }

        SQLConnection con = new SQLConnection();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Tbl_Secretary WHERE SecretaryID = @p1 AND SecretaryPassword = @p2", con.connect());
            sqlCommand.Parameters.AddWithValue("@p1", txtID.Text);
            sqlCommand.Parameters.AddWithValue("@p2", txtPassword.Text);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                frmSecretaryDetail frmSecretaryDetail = new frmSecretaryDetail();
                frmSecretaryDetail.ID = txtID.Text;
                frmSecretaryDetail.Show();
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
