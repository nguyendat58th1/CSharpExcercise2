using System;
using System.Threading;

namespace ClockCSharp
{
    
    class ClockPublisher
    {
        public delegate void SecondChangeHandler(ClockPublisher clockPublisher, Clock time);
        public event SecondChangeHandler SecondChange;

        public void OnSecondChange(ClockPublisher clockPublisher, Clock time )
        {
            SecondChange(clockPublisher,time);
        }

        public void Run()
        {
            while (true)
            {
                Thread.Sleep(1000);
                var datetime = new Datetime.Now;
                Clock time = new Clock(dateTime.hour,dateTime.minute,dateTime.second);
                OnSecondChange(this, time);
            }
        }
       

    }
}
