using System;
using WubbaLubbaDubDub;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Programm
{
    public class StringsOperations
    {
        // рассмотрим два разных примера наборов строк (второй в явном виде, первый получится в результате операции split): 
        // static string[] strings_sample_1 = "A/B testing is a randomized experiment with 2 variants, A and B. It includes application of statistical hypothesis testing or 'two-sample hypothesis testing' as used in the field of statistics. A/B testing is a way to compare two versions of a single variable, typically by testing a subject's response to variant A against variant B, and determining which of the two variants is more effective.".Split();
        static string[] strings_sample_2 = {
            "aakklll788",
            "kmg fkbjg;u 2 mk",
            "34bh"
        };

        [Benchmark]
        public void StringsJoin()
        {
            // String.Join(" ", strings_sample_1);
            String.Join("", strings_sample_2);
        }

        [Benchmark]
        public void StringsBuilder()
        {
            // из strings_sample_1 и strings_sample_2 построим новую строку new_string:
            StringBuilder new_string = new StringBuilder();
            /*foreach (string str in strings_sample_1)
            {
                new_string.Append(str);
            }*/
            foreach (string str in strings_sample_2)
            {
                new_string.Append(str);
            }
        }

        [Benchmark]
        public void StringsConcatination()
        {
            // String.Concat(strings_sample_1);
            String.Concat(strings_sample_2);
        }

        //*****************************************************************************//

        static void Main()
        {
            BenchmarkRunner.Run<StringsOperations>();
        }
    }
}

/*
 * |               Method |      Mean |    Error |    StdDev |         
 * |--------------------- |----------:|---------:|----------:|     
 * |          StringsJoin | 140.54 ns | 4.401 ns | 12.486 ns |          
 * |       StringsBuilder | 183.45 ns | 5.027 ns | 14.261 ns |        
 * | StringsConcatination |  79.86 ns | 1.700 ns |  4.739 ns |
 */
