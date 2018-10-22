using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        enum Types
        {
            STR = 0,
            INT,
            DOUBLE
        }
        static void IntType()
        {
            Console.WriteLine("Sizes in bytes:" );
            List<int> intArray = new List<int>();
            int generation = -1;
            int iter = 0;
            while (generation != 2)
            {
                iter++;
                if (generation != GC.GetGeneration(intArray))
                {
                    generation++;
                    Console.WriteLine("Generation: " + generation.ToString());
                    Console.WriteLine("count: "  + (intArray.Count).ToString());
                    Console.WriteLine("count_size: "  + (intArray.Count * sizeof(int)).ToString() + " bytes");
                    Console.WriteLine("cap: "  + intArray.Capacity.ToString());
                    Console.WriteLine("cap_size: "  + (intArray.Capacity * sizeof(int)).ToString() + " bytes");
                    DateTime start = DateTime.Now;
                    if (generation == 2)
                    {
                        GC.Collect(generation);
                    }
                    DateTime end = DateTime.Now;
                    Console.WriteLine("Collecting time:" + (end - start).ToString());
                }                
                intArray.Add(Int32.MaxValue);
            }
        }
        
        static void DoubleType()
        {
            Console.WriteLine("Sizes in bytes:" );
            List<double> doubleArray = new List<double>();
            int generation = -1;
            int iter = 0;
            while (generation != 2)
            {
                iter++;
                if (generation != GC.GetGeneration(doubleArray))
                {
                    generation++;
                    Console.WriteLine("Generation: " + generation.ToString());
                    Console.WriteLine("count: "  + doubleArray.Count.ToString());
                    Console.WriteLine("count_size: "  + (doubleArray.Count * sizeof(double)).ToString() + " bytes");
                    Console.WriteLine("cap: "  + doubleArray.Capacity.ToString());
                    Console.WriteLine("cap_size: "  + (doubleArray.Capacity * sizeof(double)).ToString() + " bytes");
                    DateTime start = DateTime.Now;
                    if (generation == 2)
                    {
                        GC.Collect(generation);
                    }
                    DateTime end = DateTime.Now;
                    Console.WriteLine("Collecting time:" + (end - start).ToString());
                }
                doubleArray.Add(Double.MaxValue);
            }
        }
        
        static void StringType()
        {
            Console.WriteLine("Sizes in bytes:" );
            StringBuilder str = new StringBuilder();
            int generation = -1;
            int iter = 0;
            while (generation != 2)
            {
                iter++;
                str.Append('a');
                if (generation != GC.GetGeneration(str))
                {
                    generation++;
                    Console.WriteLine("Generation: " + generation.ToString());
                    Console.WriteLine("count: "  + str.Length.ToString());
                    Console.WriteLine("count_size: "  + (str.Length * sizeof(char)).ToString() + " bytes");
                    Console.WriteLine("cap: "  + str.Capacity.ToString());
                    Console.WriteLine("cap_size: "  + (str.Capacity * sizeof(char)).ToString() + " bytes");
                    DateTime start = DateTime.Now;
                    if (generation == 2)
                    {
                        GC.Collect(generation);
                    }
                    DateTime end = DateTime.Now;
                    Console.WriteLine("Collecting time:" + (end - start).ToString());
                }
            }
        }
        
        static void AllTypes()
        {
            const int numTypes = 3;
            const int numGenerations = 3;
            StringBuilder str = new StringBuilder();
            List<double> doubleArray = new List<double>();
            List<int> intArray = new List<int>();
            int[] generations = {-1, -1, -1};
            string[][] outputs = new string[numGenerations][];
            for (int i = 0; i < numGenerations; i++)
            {
                outputs[i] = new string[numTypes] {"string: ", "int[]: ", "double[]: "};
            }
            while (generations.Min() != 2)
            {
                str.Append('a');
                doubleArray.Add(Double.MaxValue);
                intArray.Add(Int32.MaxValue);
                if (generations[0] != GC.GetGeneration(str))
                {
                    generations[0]++;
                    outputs[generations[0]][0] += (str.Length * sizeof(char)).ToString();
                }
                if (generations[1] != GC.GetGeneration(intArray))
                {
                    generations[1]++;
                    outputs[generations[1]][1] += (intArray.Count * sizeof(int)).ToString();
                }
                if (generations[2] != GC.GetGeneration(str))
                {
                    generations[2]++;
                    outputs[generations[2]][2] += (doubleArray.Count * sizeof(double)).ToString();
                }
            }

            for (int i = 0; i < outputs.Length; i++)
            {
                Console.WriteLine("Generation: " + i.ToString());
                for (int j = 0; j < outputs[i].Length; j++)
                {
                    Console.WriteLine(outputs[i][j]);
                }
            }

        }

        static void GCPureString()
        {
            int capacity = 3824192;
            int gen = -1;
            for (int i = 1; i < capacity && gen < 2; i++)
            {
                string str = new string('a', i);
                int realGen = GC.GetGeneration(str);
                if (gen != realGen)
                {
                    gen++;
                    Console.WriteLine("Generation: " + realGen.ToString());
                    Console.WriteLine("count: "  + str.Length.ToString());
                    Console.WriteLine("count_size: "  + (str.Length * sizeof(char)).ToString() + " bytes");
                    if (gen != realGen)
                    {
                        DateTime start = DateTime.Now;
                        GC.Collect(realGen);
                        DateTime end = DateTime.Now;
                        Console.WriteLine("Collecting time:" + (end - start).ToString());
                        break;
                    }
                }
                GC.Collect(realGen);
            }
        }
        
        static void GCPureIntVector()
        {
            int capacity = 524289;
            int gen = -1;
            for (int i = 1; i < capacity && gen < 2; i++)
            {
                int[] array = new int[i];
                int realGen = GC.GetGeneration(array);
                if (gen != realGen)
                {
                    gen++;
                    Console.WriteLine("Generation: " + realGen.ToString());
                    Console.WriteLine("count: "  + array.Length.ToString());
                    Console.WriteLine("count_size: "  + (array.Length * sizeof(int)).ToString() + " bytes");
                    if (realGen == 2)
                    {
                        DateTime start = DateTime.Now;
                        GC.Collect(realGen);
                        DateTime end = DateTime.Now;
                        Console.WriteLine("Collecting time:" + (end - start).ToString());
                        break;
                    }
                }
                GC.Collect(realGen);
            }
        }
        
        static void GCPureDoubleVector()
        {
            int capacity = 524288;
            int gen = -1;
            for (int i = 1; i < capacity && gen < 2; i++)
            {
                double[] array = new double[i];
                int realGen = GC.GetGeneration(array);
                if (gen != realGen)
                {
                    gen++;
                    Console.WriteLine("Generation: " + realGen.ToString());
                    Console.WriteLine("count: "  + array.Length.ToString());
                    Console.WriteLine("count_size: "  + (array.Length * sizeof(double)).ToString() + " bytes");
                    if (realGen == 2)
                    {
                        DateTime start = DateTime.Now;
                        GC.Collect(realGen);
                        DateTime end = DateTime.Now;
                        Console.WriteLine("Collecting time:" + (end - start).ToString());
                        break;
                    }
                }
                GC.Collect(realGen);
            }
        }
        
        static void Main(string[] args)
        {
            GCPureString();
        }
    }
}