using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Mosh_CSharp_intermediate
{
    public class Sec2_Ex1
    {
        public static void Start()
        {
            var stopwatch = new Stopwatch();

            while (true)
            {
                Console.WriteLine("Press enter to start stopwatch...");
                Console.ReadLine();
                stopwatch.Start();

                Console.WriteLine("Press enter again to stop the stopwatch and get the duration");
                Console.ReadLine();
                stopwatch.Stop();

                Console.WriteLine("Stopwatch duration: " + stopwatch.Duration.TotalSeconds + "s");
            }
        }

    }

    internal class Stopwatch
    {
        public TimeSpan StartTime { get; private set; }
        public TimeSpan StopTime { get; private set; }
        public bool IsRunning { get; private set; }

        public TimeSpan Duration
        {
            get { return StopTime - StartTime; }
        }

        public void Start()
        {
            if (IsRunning) throw new InvalidOperationException("Cannot start a stopwatch that is currently running.");
            
            StopTime = TimeSpan.Zero;
            StartTime = TimeSpan.FromTicks(DateTime.Now.Ticks);
            IsRunning = true;
        }

        public void Stop()
        {
            if (!IsRunning) throw new InvalidOperationException("Cannot stop a stopwatch that is currently not running.");

            StopTime = TimeSpan.FromTicks(DateTime.Now.Ticks);
            IsRunning = false;
        }
    }
}
