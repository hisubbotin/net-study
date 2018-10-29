using System;
using System.Diagnostics;

namespace GarbageCollector
{
    class Program
    {
        private static void Main( string[] args )
        {
            int charLimit = ExploreLimit<char>( 1, 100000 );
            int intLimit = ExploreLimit<int>( 1, 100000 );
            int doubleLimit = ExploreLimit<double>( 1, 100000 );

            var ( zeroTime, firstTime, secondTime ) = ExploreGenerationsNTimes( 100000, 10000, 10 );

            Console.WriteLine( "Char limit = {0} bytes", charLimit * sizeof( char ) );
            Console.WriteLine( "Int limit = {0} bytes", intLimit * sizeof( int ) );
            Console.WriteLine( "Double limit = {0} bytes", doubleLimit * sizeof( double ) );
            Console.WriteLine( "\n" );
            Console.WriteLine( "Generation 0 collecting time = {0} ms", zeroTime.TotalMilliseconds );
            Console.WriteLine( "Generation 1 collecting time = {0} ms", firstTime.TotalMilliseconds );
            Console.WriteLine( "Generation 2 collecting time = {0} ms", secondTime.TotalMilliseconds );
        }

        private static int ExploreLimit<T>( int lInit, int rInit )
        {
            int lLimit = lInit;
            int rLimit = rInit;
            while( rLimit - lLimit > 1 ) {
                int mLimit = ( lLimit + rLimit ) / 2;
                T[] buff = new T[mLimit];
                if( GC.GetGeneration( buff ) < 2 ) {
                    lLimit = mLimit;
                } else {
                    rLimit = mLimit;
                }
            }
            return rLimit;
        }


        private static ( TimeSpan, TimeSpan, TimeSpan ) ExploreGenerations( int allocSize, int allocCount )
        {
            for( int i = 0; i < allocCount; ++i ) {
                _ = new int[allocSize];
            }

            Stopwatch timer = new Stopwatch();

            TimeSpan zeroTime = CollectGeneration( 0, timer );
            TimeSpan firstTime = CollectGeneration( 1, timer );
            TimeSpan secondTime = CollectGeneration( 2, timer );

            return (zeroTime, firstTime, secondTime);
        }

        private static ( TimeSpan, TimeSpan, TimeSpan ) ExploreGenerationsNTimes( int allocSize, int allocCount, int N )
        {
            TimeSpan zeroTimeTotal = new TimeSpan();
            TimeSpan firstTimeTotal = new TimeSpan();
            TimeSpan secondTimeTotal = new TimeSpan();

            for ( int i = 0; i < N; ++i ) {
                var ( zeroTime, firstTime, secondTime ) = ExploreGenerations( allocSize, allocCount );
                zeroTimeTotal += zeroTime;
                firstTimeTotal += firstTime;
                secondTimeTotal += secondTime;
            }

            zeroTimeTotal /= N;
            firstTimeTotal /= N;
            secondTimeTotal /= N;

            return ( zeroTimeTotal, firstTimeTotal, secondTimeTotal );
        }

        private static TimeSpan CollectGeneration( int generation, Stopwatch timer )
        {
            Debug.Assert( GC.CollectionCount( generation ) > 0 );
            timer.Restart();
            GC.Collect( generation, GCCollectionMode.Forced );
            GC.WaitForPendingFinalizers();
            timer.Stop();
            return timer.Elapsed;
        }
    }
}