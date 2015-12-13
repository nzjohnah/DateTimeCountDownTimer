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
                //Initialise timer variables
                TotalCountDownTime = totalTime;
                RemainingCountDownTime = totalTime;

                StartDateTime = DateTime.Now;

                //Specified timer to have 1 second interval
                timer = new Timer(1000);

                // Output the inital
                Console.WriteLine(TotalCountDownTime.ToString("#"));
                // Execute Ticking method for time check and timer ending check
                timer.Elapsed += (sender, e) => Tick();
                timer.Enabled = true;
            }
            public void Tick()
            {
                //Executes every single second
                var ActualTotalElapsedTime = (DateTime.Now - StartDateTime).TotalSeconds;

                if (ActualTotalElapsedTime < TotalCountDownTime)
                {
                    //Timer calibrated with actual DateTime 
                    RemainingCountDownTime = TotalCountDownTime - ActualTotalElapsedTime;
                    //Output to Console, this could be used to update the timer on interface
                    Console.WriteLine(RemainingCountDownTime.ToString("#"));
                }
                else
                {
                    //Execute when time is up
                    //Set to 0
                    RemainingCountDownTime = 0;
                    TotalCountDownTime = 0;
                    // Output to Console
                    Console.WriteLine("Times up!");
                    
                    // Disable clear
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
