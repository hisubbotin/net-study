<Query Kind="Program" />

static void WriteSum(int x, int y) => Console.WriteLine("Sum: " + (x + y));
static void WriteMulpiply(int x, int y) => Console.WriteLine("Multiply: " + (x * y));
static int Add(int x, int y) => x + y;

static void Operation(int x, int y, Action<int, int> op) => op(x, y);

static void Main(string[] args) 
{
    Operation(10, 6, WriteSum);
    Operation(3, 3, WriteMulpiply);
    Operation(7, 5, (x,y) => {Console.WriteLine(x - y);});
 
    Action<int, int> op = WriteSum;
    op.Invoke(1, 1);
    
    Func<int, int, int> add = Add;
    int result = add(1,2);
    Console.WriteLine(result);
}