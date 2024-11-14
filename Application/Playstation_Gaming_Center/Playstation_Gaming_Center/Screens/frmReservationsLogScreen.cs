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
    public partial class frmReservationsLogScreen : Form
    {  

        private DataTable _dataTable = new DataTable();

        public frmReservationsLogScreen()
        {
            InitializeComponent();

            this._fetchReservationsFromDB();
        }


        // private methods

        private void _fetchReservationsFromDB()
        {
            this._dataTable = clsReservation.getAllReservations();
            this.dgvReservations.DataSource = _dataTable;
        }


    }
}
