<Query Kind="Program" />

public enum Status
{
    New = 2,
    Commited = 3,
    Deleted = 4
}

public static void Main()
{
    string[] test = new []
    {
        "New",  // New | 2 | True
        "new",  // Exception: Requested value 'new' was not found.
        "3",    // Commited | 3 | True
        "0",    // 0 | 0 | False
        "",     // Exception: Must specify valid information...
        "-1",   // -1 | -1 | False
        "New, Commited" // Commited | 3 | True      ~WTF~LUL~
    };

    foreach (string s in test)
    {
        try
        {
            Status value = (Status) Enum.Parse(typeof(Status), s);
            int intValue = (int)value;
            bool isDefined = Enum.IsDefined(typeof(Status), value);

            Console.WriteLine($"`{s}`: {value} | {intValue} | {isDefined}");
        }
        catch(Exception e)
        {
            Console.WriteLine($"`{s}`, Exception: {e.Message}");
        }
    }

    Enum.IsDefined(typeof(Status), "New, Commited"); // false
}