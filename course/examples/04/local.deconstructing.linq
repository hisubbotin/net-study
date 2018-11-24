<Query Kind="Program" />

public class Example
{
   public static void Main()
   {
       (string firstname, string lastname, int height) = GetSomeData("Alex");

       Console.WriteLine($" {firstname} - {lastname} - {height}");
   }

   private static (string, string, int) GetSomeData(string name)
   {
      if (name == "Alex")
         return ("Alexander", "Subbotin", 196);

      return (string.Empty, string.Empty, 0);
   }
}