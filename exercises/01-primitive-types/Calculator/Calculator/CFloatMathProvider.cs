namespace Calculator
{
    internal class CFloatMathProvider : CMathProvider<float>
    {
        public override float Divide(float a, float b)
        {
            return a / b;
        }

        public override float Multiply(float a, float b)
        {
            return a * b;
        }

        public override float Add(float a, float b)
        {
            return a + b;
        }

        public override float Subtract(float a, float b)
        {
            return a - b;
        }
    }
}