using System;
using System.Collections.Generic;
using System.Threading;

namespace gc_ex_counters
{
    class Program
    {
        public static class GCNotification
        {
            private static Action<Int32> s_gcDone = null;  // The event's field

            public static event Action<Int32> GCDone
            {
                add
                {
                    // If there were no registered delegates before, start reporting notifications now
                   if (s_gcDone == null) { new GenObject(0); new GenObject(2); }
                    s_gcDone += value;
                }
                remove { s_gcDone -= value; }
            }

            private sealed class GenObject
            {
                private Int32 m_generation;
                public GenObject(Int32 generation) { m_generation = generation; }
                ~GenObject()
                { // This is the Finalize method
                  // If this object is in the generation we want (or higher),
                  // notify the delegates that a GC just completed
                    if (GC.GetGeneration(this) >= m_generation)
                    {
                        Volatile.Read(ref s_gcDone)?.Invoke(m_generation);
                    }

                    // Keep reporting notifications if there is at least one delegate registered,
                    // the AppDomain isn't unloading, and the process isn't shutting down
                    if ((s_gcDone != null)
                       && !AppDomain.CurrentDomain.IsFinalizingForUnload()
                       && !Environment.HasShutdownStarted)
                    {
                        // For Gen 0, create a new object; for Gen 2, resurrect the object
                        // & let the GC call Finalize again the next time Gen 2 is GC'd
                        if (m_generation == 0) new GenObject(0);
                        else GC.ReRegisterForFinalize(this);
                    }
                    else { /* Let the objects go away */ }
                }
            }
        }

        static List<byte[]> load = new List<byte[]>();
        static void Main(string[] args)
        {
            Console.WriteLine("Application is running with server GC=" + System.Runtime.GCSettings.IsServerGC);
            Console.WriteLine(System.Runtime.GCSettings.LatencyMode);

            Thread tr = new Thread(new ThreadStart(() => { load.Clear(); Thread.Sleep(500); }));
            tr.Start();
          
            try
            {

                int lastCollCount = 0;
                int newCollCount = 0;


                while (true)
                {
                    load.Add(new byte[100000]);
                    newCollCount = GC.CollectionCount(2);
                    if (newCollCount != lastCollCount)
                    {
                        // Show collection count when it increases:
                        Console.WriteLine("Gen 2 collection count: {0}, {1}", newCollCount.ToString(), DateTime.UtcNow.Millisecond);
                        lastCollCount = newCollCount;
                    }

                    Thread.Sleep(500);
                }

            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("Out of memory.");
            }

            
            Console.ReadLine();
        }
    }
}
