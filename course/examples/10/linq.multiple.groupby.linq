<Query Kind="Program">
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Linq</Namespace>
</Query>

void Main()
{
    var elementList = new List<Element>{ new Element { Key = "1", Type = "test", Value = 33 }};
    
    var consolidated =
    from x in elementList
    group x by new
    {
        x.Type,
        x.Key,
        x.Value,
    } into gcs
    select new
    {
        Type = gcs.Key.Type,
        Key = gcs.Key.Key,
        Value = gcs.Key.Value,
        List = gcs.ToList(),
    };
    
    foreach (var item in consolidated)
    {
        Console.WriteLine($"{item.Type}, {item.Key}, {item.Value}, {item.List.Count}");
    }
}

internal class Element
{
    public string Key { get; set; }
    public string Type { get; set; }
    public int Value { get; set; }
}
