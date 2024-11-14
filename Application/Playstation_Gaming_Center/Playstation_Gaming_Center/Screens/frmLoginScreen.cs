using BusinessAccessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playstation_Gaming_Center.Screens
{
    public partial class frmLoginScreen : Form
    {   
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            this._login();
        }


        private void _login()
        {
            string username = txtboxUsername.Text.Trim();
            string password = txtboxPassword.Text.Trim();  

            if(username == "" || password == "")
            {
                MessageBox.Show("Username or password can't be empty !","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           

            if(clsAdmin.login(username,clsEncryption.ComputeHash(password)))
            {
                MessageBox.Show("Logged in successfully", "Succeed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                clsGlobal.loggedInAdmin = clsAdmin.getAdmin(username, clsEncryption.ComputeHash(password));
                clsEventLogger.logSuccessfullLogin();

                frmMainScreen form = new frmMainScreen();
                form.ShowDialog();

                return;
            }

            clsEventLogger.logFailedLogin();
            MessageBox.Show("Incorrect username or password", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



    }
}
