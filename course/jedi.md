# Jedi

## October week 4

```cs
/// <summary>
/// Возвращает число в 10 раз большее заданного.
/// </summary>
internal static int TenTimes(int x)
{
    /*
      Реализуй умножение числа на 10 без использования арифметических операций над числами.
      Воспользуйся реализованными выше методами ToString и Parse. И не думай ни о каких переполнениях - задача не на это :)
    */
    return Parse(new StringBuilder(ToString(x)).Append(0).ToString());
}
```