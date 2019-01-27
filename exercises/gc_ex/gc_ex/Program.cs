using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Configuration;

namespace gc_exercise
{
    class Program
    {
        static bool checkForNotify = false;
        
        static bool bAllocate = false;
        
        static bool finalExit = false;
        static List<byte[]> load = new List<byte[]>();


        public static void Main(string[] args)
        {
            GC.RegisterForFullGCNotification(10, 10);
            Console.WriteLine("Registered for GC notification.");

            checkForNotify = true;
            bAllocate = true;
                
            new Thread(new ThreadStart(WaitForFullGCProc)).Start();

            int lastCollCount = 0;
            int newCollCount = 0;

            while (true)
            {
                if (bAllocate)
                {
                    load.Add(new byte[1000]);
                    newCollCount = GC.CollectionCount(2);
                    if (newCollCount != lastCollCount)
                    {
                        Console.WriteLine("Gen 2 collection count: {0}", GC.CollectionCount(2).ToString());
                        lastCollCount = newCollCount;
                    }
                            
                    if (newCollCount == 5)
                    {
                        finalExit = true;
                        checkForNotify = false;
                        break;
                    }
                }
            }


            finalExit = true;
            checkForNotify = false;
            GC.CancelFullGCNotification();

            Console.ReadLine();
        }

        public static void WaitForFullGCProc()
        {
            while (true)
            {
                while (checkForNotify)
                {
                    Console.WriteLine("HERE");
                    GCNotificationStatus s = GC.WaitForFullGCApproach();
                    if (s == GCNotificationStatus.Succeeded)
                    {
                        Console.WriteLine("WaitForFullGCApproach");
                        bAllocate = false;
                        load.Clear();
                        GC.Collect();
                        Console.WriteLine("Induced a collection.");
                    }
                    else 
                    {
                        Console.WriteLine("GC Notification cancelled.");
                        break;
                    }

                    Stopwatch timer = new Stopwatch();
                    timer.Start();
                    GCNotificationStatus status = GC.WaitForFullGCComplete();
                    if (status == GCNotificationStatus.Succeeded)
                    {
                        timer.Stop();
                        Console.WriteLine("WaitForFullGCComplete: {0}", timer.Elapsed.ToString());
                        bAllocate = true;
                    }
                    else
                    {
                        Console.WriteLine("GC Notification cancelled.");
                        break;
                    }
                }

                Thread.Sleep(500);
                if (finalExit)
                {
                    break;
                }
            }

        }

    }
}