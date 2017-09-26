using System;
using System.Globalization;

namespace Calculator
{
    internal abstract class CParser<T>
    {
        public abstract T Parse(string s);
    }

    internal class CIntParser : CParser<int>
    {
        public override int Parse(string s)
        {
            return int.Parse(s);
        }
    }

    internal class CFloatParser : CParser<float>
    {
        public override float Parse(string s)
        {
            return float.Parse(s);
        }
    }

    public enum TOperationMode
    {
        Add = '+',
        Subtract = '-',
        Multiply = '*',
        Divide = '/',
        Undefined = ' '
    }


    public enum TCheckMode
    {
        Default = '#',
        Checked = 'c',
        Unhecked = 'u',
    }

    internal class Calculator<T> where T : struct
    {
        private static readonly CMathProvider<T> Math;
        private static readonly CMathProvider<T> CheckMath;

        private static readonly CMathProvider<T> UncheckMath;
        private static readonly CParser<T> Parser;

        static Calculator()
        {
            if (typeof(T) == typeof(float))
            {
                Math = new CFloatMathProvider() as CMathProvider<T>;
                CheckMath = Math;
                UncheckMath = Math;
                Parser = new CFloatParser() as CParser<T>;
            }
            else if (typeof(T) == typeof(int))
            {
                Math = new CIntMathProvider() as CMathProvider<T>;
                CheckMath = new CCheckIntMathProvider() as CMathProvider<T>;
                UncheckMath = new CUncheckIntMathProvider() as CMathProvider<T>;
                Parser = new CIntParser() as CParser<T>;
            }
        }


        public Calculator()
        {
            _operationMode = TOperationMode.Undefined;
            _checkMode = TCheckMode.Default;
        }


        public TOperationMode OperationMode
        {
            set => _operationMode = value;
        }

        public TCheckMode CheckMode
        {
            set => _checkMode = value;
        }

        public T? AddNumber(string s)
        {
            T number = Parser.Parse(s);
            if (_first == null)
            {
                _first = number;
                return null;
            }
            else
            {
                number = Calculate((T) _first, number);
                _first = null;
                return number;
            }
        }

        public void Clear()
        {
            _first = null;
        }

        private T Calculate(T first, T second)
        {
            switch (_checkMode)
            {
                case TCheckMode.Default:
                    return Calculate(Math, first, second);
                case TCheckMode.Checked:
                    return Calculate(CheckMath, first, second);
                case TCheckMode.Unhecked:
                    return Calculate(UncheckMath, first, second);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private TOperationMode _operationMode;

        private TCheckMode _checkMode;
        private T? _first;


        private T Calculate(CMathProvider<T> math, T first, T second)
        {
            switch (_operationMode)
            {
                case TOperationMode.Add:
                    return math.Add(first, second);
                case TOperationMode.Subtract:
                    return math.Subtract(first, second);
                case TOperationMode.Multiply:
                    return math.Multiply(first, second);
                case TOperationMode.Divide:
                    return math.Divide(first, second);
                case TOperationMode.Undefined:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var floatCalculator = new Calculator<float>();
            var intCalculator = new Calculator<int>();
            bool isIntMode = true;
            string line;

            while ((line = Console.ReadLine()).Length > 0)
            {
                if (line.Length == 1)
                {
                    var isParsed = true;
                    switch (line[0])
                    {
                        case 'i':
                            isIntMode = true;
                            intCalculator.Clear();
                            floatCalculator.Clear();
                            break;
                        case 'f':
                            isIntMode = false;
                            intCalculator.Clear();
                            floatCalculator.Clear();
                            break;
                        case '#':
                            intCalculator.CheckMode = floatCalculator.CheckMode = TCheckMode.Default;
                            break;
                        case 'c':
                            intCalculator.CheckMode = floatCalculator.CheckMode = TCheckMode.Checked;
                            break;
                        case 'u':
                            intCalculator.CheckMode = floatCalculator.CheckMode = TCheckMode.Unhecked;
                            break;
                        case '+':
                            intCalculator.OperationMode = floatCalculator.OperationMode = TOperationMode.Add;
                            break;
                        case '-':
                            intCalculator.OperationMode = floatCalculator.OperationMode = TOperationMode.Subtract;
                            break;
                        case '*':
                            intCalculator.OperationMode = floatCalculator.OperationMode = TOperationMode.Multiply;
                            break;
                        case '/':
                            intCalculator.OperationMode = floatCalculator.OperationMode = TOperationMode.Divide;
                            break;
                        default:
                            isParsed = false;
                            break;
                    }
                    if (isParsed)
                        continue;
                }
                switch (line[0])
                {
                    case 'c':
                        intCalculator.CheckMode = floatCalculator.CheckMode = TCheckMode.Checked;
                        break;
                    case 'u':
                        intCalculator.CheckMode = floatCalculator.CheckMode = TCheckMode.Unhecked;
                        break;
                    default:
                        if (isIntMode)
                        {
                            int? result = null;
                            try
                            {
                                result = intCalculator.AddNumber(line);
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Overflow");
                                intCalculator.Clear();
                            }
                            if (result != null)
                                Console.WriteLine(result.ToString());
                        }
                        else
                        {
                            float? result = null;
                            try
                            {
                                result = floatCalculator.AddNumber(line);
                            }
                            catch (OverflowException)
                            {
                                Console.WriteLine("Overflow");
                                floatCalculator.Clear();
                            }
                            if (result != null)
                                Console.WriteLine(result.ToString());
                        }
                        break;
                }
            }
        }
    }
}