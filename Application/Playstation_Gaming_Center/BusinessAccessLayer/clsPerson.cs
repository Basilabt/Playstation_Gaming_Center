using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace BusinessAccessLayer
{
    public class clsPerson
    {
        public enum enGender
        {
            Male = 1 , Female = 2
        }

        public int personID {  get; set; }
        public string firstName { get; set; }
        public string secondName { get; set; }
        public string thirdName { get; set; }
        public string lastName { get; set; }
        public enGender gender { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }

        public clsPerson()
        {
            this.personID = -1;
            this.firstName = "";
            this.secondName = "";
            this.thirdName = "";
            this.lastName = "";
            this.gender = enGender.Male;
            this.phoneNumber = "";
            this.email = "";
        }

        private clsPerson(int personID , string firstName , string secondName , string thirdName , string lastName , enGender gedner , string phoneNumber , string email)
        {
            this.personID = personID;
            this.firstName = firstName;
            this.secondName = secondName;
            this.thirdName = thirdName;
            this.lastName = lastName;
            this.gender = gedner;
            this.phoneNumber = phoneNumber;
            this.email = email;
        }

        // Static Methods

        public static clsPerson getPersonByPersonID(int personID)
        {
            string firstName = "", secondName = "", thirdName = "", lastName = "", phoneNumber = "", email = "";
            bool gender = false;

            if(clsPersonDataAccess.getPersonByPersonID(personID,ref firstName,ref secondName,ref thirdName,ref lastName,ref gender , ref phoneNumber,ref email))
            {               
                return new clsPerson(personID,firstName,secondName,thirdName,lastName, (gender) ? enGender.Male : enGender.Female,phoneNumber,email);
            }

            return null;
        }

    }
}
