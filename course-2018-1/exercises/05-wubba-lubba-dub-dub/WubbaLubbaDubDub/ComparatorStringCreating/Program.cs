using System;
using System.Diagnostics;
using System.Text;


namespace ComparatorStringCreating
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            string s = string.Join("", "fdsfaa ", "fdsafdsafsdagagasdgfdgfdga", "fdsgdsagfgfsdddddgfsd", " dsfafagfgsdatretthf");
            sw.Stop();
            Console.WriteLine("string.Join: {0} ms", sw.Elapsed.TotalMilliseconds);

            sw.Restart();
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin("fdsfaa ", "fdsafdsafsdagagasdgfdgfdga", "fdsgdsagfgfsdddddgfsd", " dsfafagfgsdatretthf");
            string str = sb.ToString();
            sw.Stop();
            Console.WriteLine("StringBuilder: {0} ms", sw.Elapsed.TotalMilliseconds);

            sw.Restart();
            string s1 = "fdsfaa " + "fdsafdsafsdagagasdgfdgfdga" + "fdsgdsagfgfsdddddgfsd" + " dsfafagfgsdatretthf";
            sw.Stop();
            Console.WriteLine("Concatenation: {0} ms", sw.Elapsed.TotalMilliseconds);
        }
    }
}
