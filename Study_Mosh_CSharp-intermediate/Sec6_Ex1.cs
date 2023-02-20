using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Mosh_CSharp_intermediate
{
    public class Sec6_Ex1
    {
        public static void Start()
        {
            WorkflowEngine workflowEngine = new WorkflowEngine();
            Workflow workflow = new Workflow();
            workflow.AddActivity(new FileEncoder());
            workflow.AddActivity(new CloudUploader());
            workflow.AddActivity(new NotificationSender());
            workflow.AddActivity(new DbReader());
            workflow.AddActivity(new UIUpdater());
            workflowEngine.Run(workflow);
        }
    }

    internal class WorkflowEngine
    {
        public void Run(Workflow workflow)
        {
            foreach (IActivity activity in workflow.GetActivities())
            {
                activity.Execute();
            }
        }
    }

    internal class Workflow
    {
        private readonly List<IActivity> _activities;

        public Workflow(List<IActivity> activities)
        {
            this._activities = activities;
        }
        public Workflow() : this(new List<IActivity>()) { }

        public void AddActivity(IActivity activity)
        {
            if (activity == null) throw new ArgumentNullException("activity", "Activity can't be null");

            _activities.Add(activity);
        }

        public void RemoveActivity(IActivity activity)
        {
            if (activity == null) throw new ArgumentNullException("activity", "Activity can't be null");

            _activities.Remove(activity);
        }

        public IEnumerable<IActivity> GetActivities()
        {
            return _activities;
        }
    }

    internal interface IActivity
    {
        void Execute();
    }
    internal class FileEncoder : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Encoding file...");
        }
    }
    internal class CloudUploader : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Uploading data to cloud...");
        }
    }
    internal class NotificationSender : IActivity 
    {
        public void Execute()
        {
            Console.WriteLine("Sending notification...");
        }
    }
    internal class DbReader : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Getting data from database...");
        }
    }
    internal class UIUpdater : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Updating UI...");
        }
    }
}
