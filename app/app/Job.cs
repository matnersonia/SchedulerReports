using Quartz;
using System;
using System.Threading.Tasks;

namespace app
{
    public class Job : IJob
    {
        Task IJob.Execute(IJobExecutionContext context)
        {
            //obKey key = context.JobDetail.Key; 

            JobDataMap dataMap = context.JobDetail.JobDataMap; 
   
            string contactName = dataMap.GetString("contactName");
            string deliveryMethod = dataMap.GetString("deliveryMethod");
            string reportName = dataMap.GetString("reportName");

            Task taskA = new Task(() => Console.WriteLine("{0} sent to {1} from scheduler with {2}", deliveryMethod, contactName, reportName));
            taskA.Start();
            return taskA;
        }
    }
}