namespace Calculator
{
    internal abstract class CMathProvider<T>
    {
        public abstract T Divide(T a, T b);
        public abstract T Multiply(T a, T b);
        public abstract T Add(T a, T b);
        public abstract T Subtract(T a, T b);
    }

    
}