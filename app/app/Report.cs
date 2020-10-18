using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app
{
    public class Report
    {
        //raportul este pentru fiecare contact? sau pentru fiecare client?
        //nu string client, 
        public string ReportName { get; set; }
        public string ClientName { get; set; }
        public DateTime Time { get; set; }

        public Report(string reportname, string clientName, DateTime time)
        {
            ReportName = reportname;
            ClientName = clientName;
            Time = time;
        }

    }
}
