using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Hospital
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void pbPatient_Click(object sender, EventArgs e)
        {
            frmPatientLogin frmPatientLogin = new frmPatientLogin();
            frmPatientLogin.Show();
        }

        private void pbDoctor_Click(object sender, EventArgs e)
        {
            frmDoctorLogin frmDoctorLogin = new frmDoctorLogin();
            frmDoctorLogin.Show();
        }

        private void pbSecretary_Click(object sender, EventArgs e)
        {
            frmSecretaryLogin frmSecretaryLogin = new frmSecretaryLogin();
            frmSecretaryLogin.Show();
        }
    }
}
