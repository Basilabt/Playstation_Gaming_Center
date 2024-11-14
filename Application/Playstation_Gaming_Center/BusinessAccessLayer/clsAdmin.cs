using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
    public class clsAdmin
    {
        public int adminID {  get; set; }
        public int personID { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public clsPerson person { get; set; }

        public clsAdmin()
        {
            this.adminID = -1;
            this.personID = -1;
            this.username = "";
            this.password = "";
        }

        private clsAdmin(int adminID , int personID , string username , string password)
        {
            this.adminID = adminID;
            this.personID = personID;
            this.username = username;
            this.password = password;
            this.person = clsPerson.getPersonByPersonID(adminID);
        }


        public static bool login(string username , string password)
        {
           return clsAdminDataAccess.login(username , password);
        }
        
        public static clsAdmin getAdmin(string username , string password) 
        {
            int adminID = -1, personID = -1;
            
            if(clsAdminDataAccess.getAdminByUsernameAndPassword(username , password,ref adminID,ref personID))
            {
                return new clsAdmin(adminID , personID , username , password);
            }

            return null;
        }

        public static clsAdmin getAdmin(int adminID)
        {
            int personID = -1;
            string username = "";
            string password = "";

            if (clsAdminDataAccess.getAdminByAdminID(adminID,ref personID, ref username,ref password))
            {
                return new clsAdmin(adminID, personID, username, password);
            }

            return null;
        }

    }
}
