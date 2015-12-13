using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Timers;

namespace ThreadingTimer
{
    class Program
    {
        static void Main()
        {
            //initialisation
            Countdown cd = new Countdown();
            cd.RemainingCountDownTime = 0;
            //Set a time for the timer class to do the countdown
            cd.StartUpdating(10);
            Console.ReadLine();
        }

        public class Countdown
        {
            public DateTime StartDateTime { get; set; }

            public double RemainingCountDownTime
            {
                get { return remainTime; }

                set
                {
                    remainTime = value;
                }
            }

            Timer timer;

            double remainTime;
            
            double TotalCountDownTime;

            /// <summary>
            /// Starts the updating with specified period, total time and period are specified in seconds.
            /// </summary>
            public void StartUpdating(double totalTime)
            {

                TotalCountDownTime = totalTime;
                RemainingCountDownTime = totalTime;

                StartDateTime = DateTime.Now;

                timer = new Timer(1000);
                Console.WriteLine(RemainingCountDownTime.ToString("#"));
                timer.Elapsed += (sender, e) => Tick();
                timer.Enabled = true;
            }
            public void Tick()
            {
                
                var ActualTotalElapsedTime = (DateTime.Now - StartDateTime).TotalSeconds;

                if (ActualTotalElapsedTime < TotalCountDownTime)
                {
                    RemainingCountDownTime = TotalCountDownTime - ActualTotalElapsedTime;
                    Console.WriteLine(RemainingCountDownTime.ToString("#"));
                }
                else
                {
                    RemainingCountDownTime = 0;
                    Console.WriteLine("Times up!");
                    RemainingCountDownTime = 0;
                    TotalCountDownTime = 0;

                    if (timer != null)
                    {
                        timer.Enabled = false;
                        timer = null;
                    }
                }
            }

        }
    }
}
