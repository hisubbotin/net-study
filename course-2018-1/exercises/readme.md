# Exercises

<!-- TOC -->

- [Exercises](#exercises)
  - [Target](#target)
  - [Code of conduct](#code-of-conduct)
  - [Git + GitHub workflow](#git--github-workflow)
  - [01. May the primitive types be with you](#01-may-the-primitive-types-be-with-you)
  - [02. What time is it? Adventure Time!](#02-what-time-is-it-adventure-time)
  - [03. Boring vector](#03-boring-vector)
  - [04. Garbage Cleaning](#04-garbage-cleaning)
  - [05. Wubba Lubba Dub Dub](#05-wubba-lubba-dub-dub)
  - [06. Go home, Fibonacci, you're drunk](#06-go-home-fibonacci-youre-drunk)
  - [07. Here's my `T` value so call me `Maybe<T>`](#07-heres-my-t-value-so-call-me-maybet)

<!-- /TOC -->

## Target

Первые задания предполагаются простыми и направлеными на то, чтобы максимально полно покрыть базовые части фреймворка. Мы старательно избегаем задач на алгоритмы и прочие зубодробительные штуки, чтобы вы полностью сконцентрировались на самом языке, фреймворке и их возможностях.

Последнее задание предполагает некую имитацию серьезного проекта, где вам придется столкнуться с задачами, с которыми разработчик имеет дело ежедневно.

## Code of conduct

> Списывать плохо, мкей. Вы не должны списывать. Если вы это делаете, то вы плохо поступаете, потому что списывать плохо, мкей. Списывать - плохая привычка, поэтому не будьте плохим, списывая. Иначе вы поступаете плохо, потому что списывать плохо, мкей.

Мы против бездумной копипасты чужого кода. Кооперироваться, общаться и решать задачи сообща - это нормально, но только если каждый из участников "кружка кооперации" делает полный объем работы - гуглит, думает, пишет код, исследует.

## Git + GitHub workflow

Гайд по тому, как и где делать задания, лежит [здесь](git-help.md).

## 01. May the primitive types be with you

Tags: primitive types, numbers, operations, checked/unchecked arithmetics, number formatting and parsing, console.

В данном задании вы познакомитесь с:

- примитивными числовыми типами данных
- простейшими операциями над ними,
- режимами контроля переполнения,
- чтением чисел из строки и форматированием их обратно в строку,
- работой с консолью.

Инструкция лежит в [01-primitive-types/readme.md](01-primitive-types/readme.md).

## 02. What time is it? Adventure Time!

Tags: datetime, datetime.kind, utc, timezone, timezoneinfo, timespan, datetimeoffset, noda time, time formatting and parsing.

В данном задании вы познакомитесь с:

- типами данных для базовой работы со временем,
- операциями над ними,
- чтением дат и отрезков времени из строки и форматированием их обратно в строку,
- проблемами, связанными со временем.

Инструкция лежит в [02-adventure-time/readme.md](02-adventure-time/readme.md).

## 03. Boring vector

Tags: struct, operator overloading, extension methods, xml documentation comments, unit-testing.

В данном задании вы познакомитесь с:

- созданием пользовательских структур,
- перегрузкой операторов и методами-расширениями,
- документированием кода с использованием стандартного формата комментариев,
- юнит-тестированием.

Инструкция лежит в [03-boring-vector/readme.md](03-boring-vector/readme.md).

## 04. Garbage Cleaning

Задание в свободной форме:

- Экспериментальным путем найти с какого размера объектов (string, массив int/double) clr помещает объекты в LOH
- Оценить время сборки мусора в разных поколениях

## 05. Wubba Lubba Dub Dub

Tags: string, char, unicode, regex, unicode categories.

В данном задании вы поиграетесь с текстами и познакомитесь с:

- предикатами для определения категорий Юникода
- поддержкой регулярных выражений в .Net.

Инструкция лежит в [05-wubba-lubba-dub-dub/readme.md](05-wubba-lubba-dub-dub/readme.md)

## 06. Go home, Fibonacci, you're drunk

Tags: generics, linq, collections, enumerables, lambdas, random.

В данном задании вы познакомитесь с:

- обобщенными коллекциями и перечисляемыми последовательностями,
- операциями фильтрации, группировки, проекции и агрегации над ними.

Инструкция лежит в [06-drunk-fibonacci/readme.md](06-drunk-fibonacci/readme.md).

## 07. Here's my `T` value so call me `Maybe<T>`

Tags: generics, extension methods, lambdas, LINQ-query syntax, maybe monad.

В данном задании вы познакомитесь с:

- обобщенными типами-контейнерами на примере реализации монады _maybe_,
- обобщенными методами-расширениями с ограничениями на применяемые типы,
- анонимными-функциями (aka лямбды) и типами, в т.ч. обобщенными,
- техникой добавления поддержки синтаксиса LINQ-запросов.

Инструкция лежит в [07-call-me-maybe/readme.md](07-call-me-maybe/readme.md).