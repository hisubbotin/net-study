using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GarbageLimits
{
    public enum TAllocationType
    {
        AT_Char,
        AT_Int,
        AT_Double
    }


    public static class GarbageUtils
    {

        public static object Allocate(TAllocationType type, int count)
        {
            object array;
            switch (type)
            {
                case TAllocationType.AT_Char:
                    {
                        array = (object)(new char[count]);
                        break;
                    }
                case TAllocationType.AT_Double:
                    {
                        array = (object)(new double[count]);
                        break;
                    }
                case TAllocationType.AT_Int:
                    {
                        array = (object)(new int[count]);
                        break;
                    }
                default:
                    {
                        throw new InvalidEnumArgumentException();
                    }
            }
            return array;
        }

        public static int AllocateAndGetGeneration(TAllocationType type, int count)
        {
            object array = Allocate(type, count);
            return GC.GetGeneration(array);
        }

        public static void GenerateGarbage()
        {
            Random rand = new Random(42);
            int count = rand.Next(5000);
            for (int i = 0; i < count; i++)
            {
                Allocate(TAllocationType.AT_Int, rand.Next(500000));
            }
        }
    }
}
