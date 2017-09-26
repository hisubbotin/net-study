using System;
using System.Collections.Generic;

namespace DrunkFibonacci
{
    internal static class DrunkFibonacci
    {
        public static int[] CreateArray(int len)
        {
            return new int[len];
            throw new NotImplementedException();
        }

        public static void FillArray(int[] arr, int seed, int step)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = seed + i * step;
            }
            throw new NotImplementedException();
        }

        public static int[] GetFirstFiveFibonacci()
        {
            return new[] { 1, 1, 2, 3, 5 };
            throw new NotImplementedException();
        }

        public static IEnumerable<int> GetNotSoRandomNumbers()
        {
            var r = new Random(42);
            while (true)
            {
                yield return r.Next();
            }
            throw new NotImplementedException();
        }

        public static IEnumerable<int> GetDrunkFibonacci()
        {
            var prev = 1;
            var curr = 1;
            var i = 2;

            foreach (var notSoRandomNumber in GetNotSoRandomNumbers())
            {
                i++;
                if (i == 4)
                {
                    prev = curr;
                    curr = 11;
                }
                else if (i == 6)
                {
                    unchecked
                    {
                        curr = curr + prev;
                    }
                }
                else
                {
                    unchecked
                    {
                        curr = curr + prev;
                        prev = curr - prev;
                    }
                }
                yield return curr;

                if ((notSoRandomNumber & 42) == 42)
                {
                    i += 2;
                }
                if (i > 6)
                {
                    i -= 6;
                }
            }
        }
    }
}
