namespace Calculator
{
    internal class CIntMathProvider : CMathProvider<int>
    {
        public override int Divide(int a, int b)
        {
            return a / b;
        }

        public override int Multiply(int a, int b)
        {
            return a * b;
        }

        public override int Add(int a, int b)
        {
            return a + b;
        }

        public override int Subtract(int a, int b)
        {
            return a - b;
        }
    }

    internal class CUncheckIntMathProvider : CMathProvider<int>
    {
        public override int Divide(int a, int b)
        {
            return a / b;
        }

        public override int Multiply(int a, int b)
        {
            return unchecked(a * b);
        }

        public override int Add(int a, int b)
        {
            return unchecked(a + b);
        }

        public override int Subtract(int a, int b)
        {
            return unchecked(a - b);
        }
    }

    internal class CCheckIntMathProvider : CMathProvider<int>
    {
        public override int Divide(int a, int b)
        {
            return a / b;
        }

        public override int Multiply(int a, int b)
        {
            return checked(a * b);
        }

        public override int Add(int a, int b)
        {
            return checked(a + b);
        }

        public override int Subtract(int a, int b)
        {
            return checked(a - b);
        }
    }
}