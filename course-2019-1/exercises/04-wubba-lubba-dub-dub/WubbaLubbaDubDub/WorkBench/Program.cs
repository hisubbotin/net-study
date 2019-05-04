using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using WubbaLubbaDubDub;

namespace WorkBench
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var stopWatch = Stopwatch.StartNew();
            var text = ReadFile("example.txt");
            stopWatch.Stop();
            Console.WriteLine($"Text read {stopWatch.Elapsed}");
            Console.WriteLine($"Text lenght = {text.Length}");
            Console.WriteLine($"Text start = {text.Substring(0, 100)}");


            stopWatch.Restart();
            var lines = RicksMercilessEncryptor.SplitToLines(text);
            stopWatch.Stop();
            Console.WriteLine($"Text SplitToLines {stopWatch.Elapsed}");
            Console.WriteLine($"Count line {lines.Length}");

            stopWatch.Restart();
            var words = RicksMercilessEncryptor.SplitToWords(text);
            stopWatch.Stop();
            Console.WriteLine($"Text SplitToWords {stopWatch.Elapsed}");
            Console.WriteLine($"Count word {words.Length}");

            {
                stopWatch.Restart();
                var joinWordsWithSpace = string.Join(" ", words);
                stopWatch.Stop();
                Console.WriteLine($"joinWordsWithSpace {stopWatch.Elapsed}");
                // Что бы не оптимизировал.
                Console.WriteLine($"joinWordsWithSpace lenght {joinWordsWithSpace.Length}");
            }

            {
                stopWatch.Restart();
                var joinWordsWithOutSpace = string.Join("", words);
                stopWatch.Stop();
                Console.WriteLine($"joinWordsWithOutSpace {stopWatch.Elapsed}");
                // Что бы не оптимизировал.
                Console.WriteLine($"joinWordsWithOutSpace lenght {joinWordsWithOutSpace.Length}");
            }

            {
                stopWatch.Restart();
                var stringBuilder = new StringBuilder();
                foreach (var word in words)
                {
                    stringBuilder.Append(word + ' ');
                }
                var stringBuilderWithSpace = stringBuilder.ToString();
                stopWatch.Stop();
                Console.WriteLine($"stringBuilderWithSpace {stopWatch.Elapsed}");
                // Что бы не оптимизировал.
                Console.WriteLine($"stringBuilderWithSpace lenght {stringBuilderWithSpace.Length}");
            }

            {
                stopWatch.Restart();
                var stringBuilder = new StringBuilder();
                foreach (var word in words)
                {
                    stringBuilder.Append(word);
                    stringBuilder.Append(' ');
                }
                var stringBuilderWithSpace = stringBuilder.ToString();
                stopWatch.Stop();
                Console.WriteLine($"stringBuilderWithSpace {stopWatch.Elapsed}");
                // Что бы не оптимизировал.
                Console.WriteLine($"stringBuilderWithSpace lenght {stringBuilderWithSpace.Length}");
            }

            {
                stopWatch.Restart();
                var stringBuilder = new StringBuilder();
                foreach (var word in words)
                {
                    stringBuilder.Append(word);
                }
                var stringBuilderWithoutSpace = stringBuilder.ToString();
                stopWatch.Stop();
                Console.WriteLine($"stringBuilderWithoutSpace {stopWatch.Elapsed}");
                // Что бы не оптимизировал.
                Console.WriteLine($"stringBuilderWithoutSpace lenght {stringBuilderWithoutSpace.Length}");
            }

            {
                static IEnumerable<string> AddSpaceStr(IEnumerable<string> words)
                {
                    foreach (var word in words)
                    {
                        yield return word + ' ';
                    }
                }
                stopWatch.Restart();
                var concatWithSpace1 = string.Concat(AddSpaceStr(words));
                stopWatch.Stop();
                Console.WriteLine($"concatWithSpace1 {stopWatch.Elapsed}");
                // Что бы не оптимизировал.
                Console.WriteLine($"concatWithSpace1 lenght {concatWithSpace1.Length}");
            }

            {
                static IEnumerable<string> AddSpaceStr(IEnumerable<string> words)
                {
                    foreach (var word in words)
                    {
                        yield return word;
                        yield return " ";
                    }
                }
                stopWatch.Restart();
                var concatWithSpace2 = string.Concat(AddSpaceStr(words));
                stopWatch.Stop();
                Console.WriteLine($"concatWithSpace2 {stopWatch.Elapsed}");
                // Что бы не оптимизировал.
                Console.WriteLine($"concatWithSpace2 lenght {concatWithSpace2.Length}");
            }

            {
                stopWatch.Restart();
                var concatWithoutSpace = string.Concat(words);
                stopWatch.Stop();
                Console.WriteLine($"concatWithoutSpace {stopWatch.Elapsed}");
                // Что бы не оптимизировал.
                Console.WriteLine($"concatWithoutSpace lenght {concatWithoutSpace.Length}");
            }
        }

        static string ReadFile(string path)
        {
            using var streamReader = new StreamReader(path);
            return streamReader.ReadToEnd(); 
        }
    }
}
