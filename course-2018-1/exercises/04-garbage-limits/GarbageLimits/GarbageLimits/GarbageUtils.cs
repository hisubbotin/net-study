using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace GarbageLimits
{
    /// <summary>
    /// Выделяемые типы
    /// </summary>
    public enum TAllocationType
    {
        AT_Char,
        AT_Int,
        AT_Double
    }

    /// <summary>
    /// Класс с финализатором
    /// </summary>
    public class ClassWithFinalizer
    {
        ~ClassWithFinalizer()
        {
            // Ничего не происходит, но финализатор есть
        }
    }

    /// <summary>
    /// Класс-обертка над методами выделения
    /// </summary>
    public static class GarbageUtils
    {
        /// <summary>
        /// Выделить массив определенного размера и типа
        /// </summary>
        /// <param name="type"></param>
        /// <param name="count"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Выделить массив и узнать его поколение
        /// </summary>
        /// <param name="type"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static int AllocateAndGetGeneration(TAllocationType type, int count)
        {
            object array = Allocate(type, count);
            return GC.GetGeneration(array);
        }

        /// <summary>
        /// Забить память небольшими объектами
        /// </summary>
        public static List<object> GenerateSmallGarbage(int count)
        {
            List<object> result = new List<object>();
            for (int i = 0; i < count; i++)
            {
                result.Add(Allocate(TAllocationType.AT_Int, 5));
            }

            return result;
        }

        /// <summary>
        /// Забить память большими объектами
        /// </summary>
        public static List<object> GenerateLargeGarbage(int count)
        {
            List<object> result = new List<object>();
            for (int i = 0; i < count; i++)
            {
                result.Add(Allocate(TAllocationType.AT_Int, 5));
            }

            return result;
        }

        public static List<object> GenerateFinalizedGarbage(int count)
        {
            List<object> result = new List<object>();
            for (int i = 0; i < count; i++)
            {
                result.Add(Allocate(TAllocationType.AT_Int, 5));
            }

            return result;
        }
    }
}
