<Query Kind="Program" />

public class Example
{
   public static void Main()
   {
        SampleClass obj = new SampleClass();
        //obj.Paint();  // Compiler error.
        IControl c = (IControl)obj;
        c.Paint();  // Calls IControl.Paint on SampleClass.
        ISurface s = (ISurface)obj;
        s.Paint(); // Calls ISurface.Paint on SampleClass.
   }

    interface IControl { void Paint(); }
    interface ISurface { void Paint(); }
    
    class SampleClass : IControl, ISurface
    {
        void IControl.Paint() => System.Console.WriteLine("IControl.Paint");
        void ISurface.Paint() => System.Console.WriteLine("ISurface.Paint");
    }
}