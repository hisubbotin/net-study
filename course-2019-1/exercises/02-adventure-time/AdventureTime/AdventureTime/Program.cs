using System;

namespace AdventureTime
{
    internal class Program
    {
        private static void Main()
        {
            var d = DateTime.UtcNow;
            var dL = DateTime.SpecifyKind(d, DateTimeKind.Local);
            var dU = DateTime.SpecifyKind(d, DateTimeKind.Utc);
            var dUn = DateTime.SpecifyKind(d, DateTimeKind.Unspecified);
            Console.WriteLine($"{d}\n {dL}\n {dU}\n {dUn}___________\n");
            

            DateTime saveNow = DateTime.Now;
            DateTime saveUtcNow = DateTime.UtcNow;

        
            DateTime myDate = DateTime.SpecifyKind(saveUtcNow, DateTimeKind.Utc); // 12/20/2015 12:17:18 PM  
            DateTime myDate2 = DateTime.SpecifyKind(saveNow, DateTimeKind.Local); // 12/20/2015 5:47:17 PM
            Console.WriteLine("Kind: " + myDate.Kind); // Utc  
            Console.WriteLine("Kind: " + myDate2.Kind); // Local  
            var a = Console.Read();
        } 
    }
}
