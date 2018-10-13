using System;

namespace BoringVector.Tests {

        /// <summary>
        /// Класс, хранящий точность, с которой надо сравнивать вещественные числа.
        /// </summary>
        internal static class Precision {
        
            /// <summary>
            /// Степень, с которой надо сравнивать вещественные числа.
            /// </summary>
            internal static readonly int Value = (int) Math.Ceiling(-Math.Log10(Vector.Epsilon));
        }
}
