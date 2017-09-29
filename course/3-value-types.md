# Value types

## Overview

- Value Types
  - [Struct](#Struct)
  - Nullable
  - Guid
  - DateTime
    - TimeSpan
    - DateTimeOffset
  - Enum

<div style="page-break-after: always;"></div>

## Struct

<div style="page-break-after: always;"></div>

## Nullable

<div style="page-break-after: always;"></div>

## GUID

<div style="page-break-after: always;"></div>

## Datetime

<div style="page-break-after: always;"></div>

### TimeSpan

<div style="page-break-after: always;"></div>

### DateTimeOffset

<div style="page-break-after: always;"></div>

## Enum

Перечисление

```cs
public enum Color
{
    Red = 1,
    Green = 2,
    Blue = 3
}

Console.WriteLine(Color.Red);
Console.WriteLine((int)Color.Red);
```