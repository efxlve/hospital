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
    public partial class frmAnnouncements : Form
    {
        public frmAnnouncements()
        {
            InitializeComponent();
        }

        SQLConnection con = new SQLConnection();

        private void frmAnnouncements_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM Tbl_Announcements", con.connect());
            sqlDataAdapter.Fill(dataTable);
            dgvAnnouncements.DataSource = dataTable;
        }
    }
}
