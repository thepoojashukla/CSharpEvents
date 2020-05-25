using System;
using System.Collections.Generic;
using System.Text;

namespace InternalAssessment
{    
    public enum WorkType { Gamer, Programmer,Tester, I95=5, union = 20};

    //a.public delegate void WorkPerformHandler(int hours, WorkType work);
    //Another way if we have EventArgs
    //public delegate void WorkPerformHandler(object sender, EventArgs e);

    //b.public delegate void WorkPerformHandler(object sender, WorkPerformedEventArgs e);
    //.public delegate void EventHandler(object sender, WorkPerformedEventArgs e); compiler will create this
    //we can remove delegate and can use the args directly in event in the back compiler will generate this delegate by itself
    class Worker
    {
        //b. public event WorkPerformHandler workPerformed;
        public event EventHandler<WorkPerformedEventArgs> workPerformedeve;
        public event EventHandler workCompleted; //In built delegate EventHandler is used

        public virtual void DoWork(int hours, WorkType work)
        {
            for (int i = 0; i < hours; i++)
            {
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i + 1, work);
            }
            OnWorkCompleted(hours, work);
        }
        public virtual void OnWorkPerformed(int hours, WorkType work)
        {
            //if(workPerformedeve != null)
            //{
            //    workPerformedeve(hours, work);
            //}

            //a.var del = workPerformedeve as WorkPerformHandler; //casting event as delegate
            //b.var del = workPerformedeve as EventHandler<WorkPerformedEventArgs>;

            //if (del != null)//checking if delegate is assigned or not // if no subscriber is there it is gonna throw error
            //{
            //    //del(hours,work)
            //    del(this, new WorkPerformedEventArgs(hours,work) );  //Raise an Event
            //}

            // Simplification of all the process
            (workPerformedeve as EventHandler<WorkPerformedEventArgs>)?.Invoke(this, new WorkPerformedEventArgs(hours, work));
        }

        public virtual void OnWorkCompleted(int hours, WorkType work)
        {
            EventHandler del = workCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}
