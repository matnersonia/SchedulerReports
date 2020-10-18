using System;
using Quartz;
using Quartz.Impl;

namespace app
{
    public class Scheduler
    {
        public void Schedule(IScheduler scheduler, Contact contact, Report report)
        {
            DateTime triggerStartTime = DateTimeUtil.ChangeTime(DateTime.Now, contact.dMin);

            IJobDetail job = JobBuilder.Create<Job>()
                .UsingJobData("contactName", contact.Name)
                .UsingJobData("deliveryMethod", contact.DeliveryMethod)
                .UsingJobData("reportName", report.ReportName)
                .Build();
            ITrigger trigger = TriggerBuilder.Create()
             .WithIdentity("IDGJob" + contact.Name, "IDG" + contact.Name)
               .StartAt(triggerStartTime)
               .WithPriority(1)
               .Build();
            scheduler.ScheduleJob(job, trigger);
        }
    }
}