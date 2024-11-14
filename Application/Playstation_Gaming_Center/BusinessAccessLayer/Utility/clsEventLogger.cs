using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
    public class clsEventLogger
    {

        private const string ApplicationName = "Playstation Gaming Center";
        private const string LogName = "Application";


        static clsEventLogger()
        {
            if (!EventLog.SourceExists(ApplicationName))
            {
                EventLog.CreateEventSource(ApplicationName, LogName);
            }
        }

        public static void logFailedLogin()
        {
            EventLog.WriteEntry(ApplicationName, "Login Failed", EventLogEntryType.Information);
        }

        public static void logSuccessfullLogin()
        {
            EventLog.WriteEntry(ApplicationName, "Login Succeed", EventLogEntryType.Information);
        }

    }

}


