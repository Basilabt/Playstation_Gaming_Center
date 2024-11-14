using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BusinessAccessLayer;

namespace Playstation_Gaming_Center.Screens
{
    public partial class frmMainScreen : Form
    {
        public frmMainScreen()
        {
            InitializeComponent();

            this._setLoggedInUserLabelValue();
        }

        private void picboxHistory_Click(object sender, EventArgs e)
        {
            frmReservationsLogScreen form = new frmReservationsLogScreen();
            form.ShowDialog();
        }


        private void _setLoggedInUserLabelValue()
        {
            this.lblLoggedUsername.Text = clsGlobal.loggedInAdmin.username;
        }


    }
}
