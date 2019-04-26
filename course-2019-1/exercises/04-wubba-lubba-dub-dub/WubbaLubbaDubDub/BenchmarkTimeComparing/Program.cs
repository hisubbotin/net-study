using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace WubbaLubbaDubDub.Benchmarks {
    public class JoinVsStringBuilderVsConcat {

        private readonly string[] testStrings = {"Как обычно, рядом с этим документом расположена папка с солюшеном WubbaLubbaDubDub, открывай его.",
            "В этот раз немного расслабимся - никаких лонгридов, никаких сотен методов, никаких отсылок к монадам и никаких глупых шуток (кроме названия).",
            "Реализуй методы-расширения типа string в статическом классе RicksMercilessEncryptor, а затем добавь каждому из них юнит-тесты в классе RicksMercilessEncryptorTests проекта WubbaLubbaDubDub.Tests. Смотри, не заскучай!",
            "И не забудь часть задания в произвольной форме - сравнить по скорости:","string.Join()","StringBuilder","Конкатенацию",
            "Напоминаю, что классно делать это с помощью BenchmarkDotNet, терпимо с помощью StopWatch и нетерпимо с помощью DateTime.UtcNow"};

        [Benchmark]
        public string Join() => string.Join("\n", testStrings);

        [Benchmark]
        public string Builder() {
            var builder = new StringBuilder();
            foreach (var s in testStrings)
            {
                builder.Append(s);
            }
            return builder.ToString();
        }
        
        [Benchmark]
        public string Concatination()
        {
            var res = "";
            foreach (var s in testStrings)
            {
                res += s;
            }
            return res;
        }
    }
    
    class Program {

        static void Main(string[] args) {
            BenchmarkRunner.Run<JoinVsStringBuilderVsConcat>();
        }
    }
}