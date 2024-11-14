using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
    public  class clsReservation
    {   
        public enum enMode
        {
            AddNew = 1 , Update = 2 , Delete
        }

        public int reservationID {  get; set; }
        public int adminID {  get; set; }
        public string customerName { get; set; }
        public DateTime reservationDate { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public double playHours { get; set; }
        public double paidAmmount {  get; set; }

        public enMode mode { get; set; }

        public clsAdmin admin { get; set; }

        public clsReservation()
        {
            this.reservationID = -1;
            this.adminID = -1;
            this.customerName = "";
            this.reservationDate = DateTime.MinValue;
            this.startTime = DateTime.MinValue;
            this.endTime = DateTime.MinValue;
            this.playHours = -1;
            this.paidAmmount = -1;
            this.mode = enMode.AddNew;
        }

        private clsReservation(int reservationID, int adminID, string customerName, DateTime reservationDate, DateTime startTime, DateTime endTime, double playHours, double paidAmmount)
        {
            this.reservationID = reservationID;
            this.adminID = adminID;
            this.customerName = customerName;
            this.reservationDate = reservationDate;
            this.startTime = startTime;
            this.endTime = endTime;
            this.playHours = playHours;
            this.paidAmmount = paidAmmount;
            this.mode = enMode.Update;
            this.admin = clsAdmin.getAdmin(adminID);
            
        }




        // Static Methods

        public static bool logReservation(int adminID, string customerName, DateTime reservationDate, DateTime startTime, DateTime endTime, double playedHours, double paidAmount)
        {
            return clsReservationDataAccess.logReservation(adminID, customerName, reservationDate, startTime, endTime, playedHours, paidAmount);
        }

        public static DataTable getAllReservations()
        {
            return clsReservationDataAccess.getAllReservations();
        }
    }
}
