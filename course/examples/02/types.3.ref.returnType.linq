<Query Kind="Program" />

public static void Main()
{
    var array = new int[5];
    ref int value = ref ElementAt(ref array, 3);
    
    value = 5;
    Console.WriteLine(array[3]); // 5
}

public static ref T ElementAt<T>(ref T[] array, int position)
{
    if (array == null)
        throw new ArgumentNullException(nameof(array));

    if (position < 0 || position >= array.Length)
        throw new ArgumentOutOfRangeException(nameof(position));

    return ref array[position];
}