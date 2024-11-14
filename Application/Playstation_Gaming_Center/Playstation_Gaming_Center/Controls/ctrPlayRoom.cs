using BusinessAccessLayer;
using Playstation_Gaming_Center.Screens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Playstation_Gaming_Center.Controls
{
    public partial class ctrPlayRoom : UserControl
    {
        private Timer _timer;
        private TimeSpan _timeSpan;

        private bool _hasStarted;

        // We assign it a value from the frmReservationInfo.
        private double _numberOfReservedHours;

        private DateTime _startTime;

        public ctrPlayRoom()
        {
            InitializeComponent();

            this._hasStarted = false;
            this._numberOfReservedHours = 0;
            this._initializeTimerSettings();
            this._restLabelValues();
        }


        private void btnStart_Click(object sender, EventArgs e)
        {   
            // If timer has been already started continue countdown.
            if(this._hasStarted == true)
            {
                this._timer.Start();
                return;
            }
            

            // If timer has not been started yet (new reservation), show reservation settings and start !

            frmReservationInfo form = new frmReservationInfo();

            if(form.ShowDialog() != DialogResult.OK)
            {   
                return;
            }

            this._hasStarted = true;

            this.lblPlayerName.Text = form.playerName;
            double numberOfReservedHours = Double.Parse(form.numberOfHours.ToString());
            this._numberOfReservedHours += numberOfReservedHours;
            
            this._timeSpan = TimeSpan.FromHours(numberOfReservedHours);  

            this._timer.Start();
            this._startTime = DateTime.Now;
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            this._timer.Stop();
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {

            this._timer.Stop();

            double numberOfPlayedSeconds = (this._numberOfReservedHours * 3600) - this._timeSpan.TotalSeconds;
            double totalCost = this.pricePerSecond * numberOfPlayedSeconds;
            MessageBox.Show($"{this.roomName} time is finished. \n Total Cost = {totalCost}", "Time finished", MessageBoxButtons.OK, MessageBoxIcon.Information);

            clsReservation.logReservation(clsGlobal.loggedInAdmin.adminID,this.lblPlayerName.Text,DateTime.Today,this._startTime,DateTime.Now,numberOfPlayedSeconds/3600,totalCost);

            this._resetRoomSettings();

        }



        // Private methods

        private void _timerTick(object sender, EventArgs e)
        {
            if (this._timeSpan.Ticks <= 0)
            {
                this._timer.Stop();

                double totalCost = this.pricePerHour * this._numberOfReservedHours;
                MessageBox.Show($"{this.roomName} time is finished. \n Total Cost = {totalCost}", "Time finished", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clsReservation.logReservation(clsGlobal.loggedInAdmin.adminID, this.lblPlayerName.Text, DateTime.Today, this._startTime, DateTime.Now, this._numberOfReservedHours, totalCost);

                this._resetRoomSettings();

                return;
            }

            // Decrement One Second
            this._timeSpan = this._timeSpan.Subtract(TimeSpan.FromSeconds(1));

            lblRemainingTime.Text = this._timeSpan.ToString(@"hh\:mm\:ss");
        }
        private void _initializeTimerSettings()
        {
            this._timer = new Timer();
            this._timeSpan = TimeSpan.Zero;

            this._timer.Interval = 1000;
            this._timer.Tick += this._timerTick;
        }



        private void _restLabelValues()
        {
            this._restPlayerNameLabel();
            this._resetRemainingTimeLabel();   
        }
        private void _restPlayerNameLabel()
        {
            this.lblPlayerName.Text = "";
        }
        private void _resetRemainingTimeLabel()
        {
            this.lblRemainingTime.Text = "";
        }
        private void _resetRoomSettings()
        {
            this._restLabelValues();
            this._hasStarted = false;
        }

        // Custom Control Attributes [Instead of Misc]

        private string _roomName = "Table";

        [
        Category("Room Settings"),
        Description("Room Name")
        ]
  
        public string roomName
        {
            get
            {
                return this._roomName;
            }
            set
            {
                this._roomName = value;
                groupBox1.Text = value;

                // The Invalidate method calls the OnPaint method, which redraws the control.  
                Invalidate();
            }
        }



        private double _pricePerHour = 1.5;

        [
        Category("Room Settings"),
        Description("Room Hour Price")
        ]

        public double pricePerHour
        {
            get
            {
                return this._pricePerHour;
            }
            set
            {
                this._pricePerHour = value;
                
                // The Invalidate method calls the OnPaint method, which redraws the control.  
                Invalidate();
            }
        }



        private double _pricePerSecond = 0.05;

        [
        Category("Room Settings"),
        Description("Room Hour Price")
        ]

        public double pricePerSecond
        {
            get
            {
                return this._pricePerSecond;
            }
            set
            {
                this._pricePerSecond = value;

                // The Invalidate method calls the OnPaint method, which redraws the control.  
                Invalidate();
            }
        }


    }
}
