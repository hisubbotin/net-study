# Exercises

## Цель заданий

Первые 10 заданий предполагаются достаточно простыми и направлены на то, чтобы максимально полно покрыть базовые части фреймворка. Мы старательно избегаем задач на алгоритмы и прочие зубодробительные штуки, чтобы вы полностью сконцентрировались на самом языке, фреймворке и их возможностях.

Последнее задание предполагает некую имитацию серьезного проекта, где вам придется столкнуться с задачами, с которыми разработчик имеет дело ежедневно.

## Code of conduct

> Так, дети, списывать плохо, мкей?

Мы против бездумной копипасты чужого кода. Кооперироваться, общаться и решать задачи сообща - это нормально, но только если каждый из участников "кружка кооперации" делает полный объем работы - гуглит, думает, пишет код, исследует.

## 1. May the primitive types be with you

Tags: primitive types, operations, checked/unchecked arithmetics, number formatting and parsing, console.

В данном задании вы познакомитесь с:

- примитивными числовыми типами данных
- простейшими операциями над ними,
- режимами контроля переполнения,
- чтением чисел из строки и форматированием их обратно в строку,
- работой с консолью.

### 1.1 The numbers strikes back

Открываете солюшен `Numbers/Numbers.sln`, в проекте Numbers находите файл Program.cs и дальше следуете комментариям в нем.

TODO: дописать

### 1.2 Return of the Calculator

Необходимо написать консольное приложение-калькулятор, которое поддерживает следующие входные данные (по одному на строку):

- `i` или `f` - задает режим работы калькулятора:
  - `i`nteger - режим работы с целыми числами (по умолчанию),
  - `f`loat - режим работы с вещественными числами
- `+`, `-`, `*`, `/` - задает режим текущей операции. Режим по умолчанию - сложение.
- `#`, `ch`, `unch` - задает режим контроля переполнения:
  - `ch` - режим явного контроля переполнения,
  - `unch` - режим явного разрешения переполнения,
  - `#` - режим "игнорирования проблемы переполнеия" - режим "по умолчанию",когда явно не задан ни один из вышеперечисленных режимов.
- целочисленное или вещественнозначное число в зависимости от текущего режима.

## 2. What time is it? Adventure Time!

Tags: datetime, datetime.kind, utc, timezone, timespan, datetimeoffset, time formatting and parsing.

## 3. Go home, Fibonacci, you're drunk

Collections, Enumerables, lambdas.

## 4. 2-dimensional vector

Structs, operator overloading, extension methods, unit-testing.

## 5. Here's my `T` value so call me `Maybe<T>`

Generics, extension methods.

## 6. Enum.HasFlag benchmark

Enums, flag enums, boxing overhead.

## 7. The beginning of Broken Telephone

String modifiers, unicode categories.

## 8. String building benchmark

String.Join, string.+=, StringBuilder.

## 9. Broken Telephone. Dark knight

Complex task using #3, #5, #7 exercises, file/archive I/O, async, high-order functions

## 10. Reflection

Reflection, attributes.

## 11. Web api

Final mega-exercise.