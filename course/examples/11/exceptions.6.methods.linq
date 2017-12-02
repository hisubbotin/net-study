<Query Kind="Program" />

internal static Result MyMethod(SomeParams p)
{
    if (1==1)
        throw new MyException();
    return new Result {};
}

internal static Result MyMethod2(SomeParams p, out ErrorData error)
{
    error = null;
    return new Result {};
}

internal static Tuple<Result, ErrorData> MyMethod3(SomeParams p)
{
    return new Tuple<Result, ErrorData>(new Result{}, null);
}

internal class Result {}
internal class SomeParams {}
internal class ErrorData {}
internal class MyException: Exception {}

static void Main(string[] args)
{
}

