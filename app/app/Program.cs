using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;



namespace app
{
    class Program
    {
        public static void SendReport(string name, string deliveryMethod, string reportName)
        {
            Console.WriteLine(deliveryMethod + " sent to " + name + " with " + reportName);
        }
        
        static void Main(string[] args)
        {
            TimeSpan ts = new TimeSpan(10,0,0);
            TimeSpan ts1 = new TimeSpan(8, 0, 0);
            TimeSpan ts2 = new TimeSpan(23, 02, 30);
            TimeSpan ts3 = new TimeSpan(23, 02 , 45);
            TimeSpan ts4 = new TimeSpan(23, 30, 0);
            TimeSpan tmin = new TimeSpan(0, 0, 0);
            TimeSpan tmax = new TimeSpan(23, 59, 59);
            TimeSpan ts5 = new TimeSpan(22, 0, 0);
            TimeSpan ts6 = new TimeSpan(6, 0, 0);
            TimeSpan ts7 = new TimeSpan(7, 0, 0);

            Contact co1 = new Contact("John Doe", "email", "asap"); //asap = now
            Contact co2 = new Contact("Jane Doe", "fax", ts2, tmax); //after 8 am
            Contact co3 = new Contact("Collect", "email", ts3, ts4); //between 8 and 8:30 am
            Contact co4 = new Contact("Tom Ford", "email", "asap"); //asap
            Contact co5 = new Contact("Bob", "fax",ts5, tmax); //after 10 pm
            Contact co6 = new Contact("Rachel", "email", ts6, ts7); //between 6 and 7 pm
            
            List <Contact> ContactList1 = new List<Contact>();

            ContactList1.Add(co1);
            ContactList1.Add(co2);
            ContactList1.Add(co3);

            List<Contact> ContactList2 = new List<Contact>();

            ContactList2.Add(co4);
            ContactList2.Add(co5);
            ContactList2.Add(co6);

            Client c1 = new Client("John Doe Medical Office", ContactList1);
            Client c2 = new Client("Another Medical Office", ContactList2);
            //Client c3 = new Client("Arcadia Medical Office");

            /*foreach (Contact contact in c1.getContactList)
            {
                Console.WriteLine("{0}, {1}, {2}", contact.Name, contact.DeliveryMethod, contact.DeliveryProgram);
            }*/
            List<Client> ClientList1 = new List<Client>();
            ClientList1.Add(c1);
            ClientList1.Add(c2);
            //ClientList1.Add(c3);

            /*Console.WriteLine("Contacts:");
            foreach (Contact contact in ContactList1 )
            {
                Console.WriteLine("{0}, {1}, {2}",contact.Name, contact.DeliveryMethod, contact.DeliveryProgram);
            }*/
            
            Report r1 = new Report("Report 1", "John Doe Medical Office", DateTime.Now);
            Report r2 = new Report("Report 2 ", "Another Medical Office", DateTime.Now);
            //Report r3 = new Report("John Doe Medical Office", dt1);
            //Report r4 = new Report("Another Medical Office", dt2); 

            List<Report> ReportList = new List<Report>();

            ReportList.Add(r1);
            ReportList.Add(r2);
            //ReportList.Add(r3);
            //ReportList.Add(r4);

            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();

            Console.WriteLine("Reports:");
            foreach (Report report in ReportList) //de facut clientList in report
            {
                //Console.WriteLine("{0}, {1}", report.ClientName, report.Time);

                //verify if the client is ok
                foreach (Client client in ClientList1)
                {
                    if (String.Equals(report.ClientName, client.Name))
                    {
                        foreach (Contact contact in client.getContactList)
                        {
                            if (String.Equals(contact.DeliveryProgram, "asap"))
                            {
                                string deliveryMethod = contact.DeliveryMethod;
                                SendReport(contact.Name, deliveryMethod, report.ReportName);
                            }
                            else
                            {
                                TimeSpan tr = report.Time.TimeOfDay;
                                TimeSpan t1 = contact.dMin;
                                TimeSpan t2 = contact.dMax;

                                if (TimeSpan.Compare(t1, tr) <= 0 && TimeSpan.Compare(tr, t2) <= 0)
                                {
                                    SendReport(contact.Name, contact.DeliveryMethod, report.ReportName);
                                }
                                else
                                {
                                    Scheduler sc = new Scheduler();
                                    sc.Schedule(scheduler, contact, report);
                                    //Console.WriteLine("This report has to be scheduled.");
                                }

                            }
                        }
                        break;
                    }
                }

            }

            scheduler.Start();
            Console.ReadKey();
        }
    }
}
