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
    public partial class frmReservationInfo : Form
    {
        public frmReservationInfo()
        {
            InitializeComponent();
        }


        public string playerName { get; private set; }
        public string numberOfHours { get; private set; }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.playerName = this.txtboxPlayerName.Text;
            this.numberOfHours = this.comboBoxNumberOfHours.SelectedItem.ToString();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
