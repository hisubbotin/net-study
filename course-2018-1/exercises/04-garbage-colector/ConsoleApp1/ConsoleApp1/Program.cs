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
            while (generation != 2)
            {
                if (generation != GC.GetGeneration(intArray))
                {
                    generation++;
                    Console.WriteLine("Generation: " + generation.ToString());
                    Console.WriteLine("int[]: "  + (intArray.Capacity * sizeof(int)).ToString() + " bytes");
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
            while (generation != 2)
            {
                if (generation != GC.GetGeneration(doubleArray))
                {
                    generation++;
                    Console.WriteLine("Generation: " + generation.ToString());
                    Console.WriteLine("double[] : "  + (doubleArray.Capacity * sizeof(double)).ToString());
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
            while (generation != 2)
            {
                str.Append('a');
                if (generation != GC.GetGeneration(str))
                {
                    generation++;
                    Console.WriteLine("Generation: " + generation.ToString());
                    Console.WriteLine("string : "  + (str.Length * sizeof(char)).ToString());
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
       
        
        static void Main(string[] args)
        {
            StringType();
        }
    }
}