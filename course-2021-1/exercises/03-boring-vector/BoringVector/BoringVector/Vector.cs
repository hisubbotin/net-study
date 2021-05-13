using System;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.CompilerServices;

namespace BoringVector
{
    #region 1. Структура Vector

    /*
        Реализуй структуру Vector - см. комментарии внутри нее.
    */

    internal struct Vector
    {
        /*
            Vector задается парой вещественных координат X и Y.
        */


        /*
            На месте заглушек добавь реализацию базовых методов вектора:
                - квадрат длины
                - сумма векторов
                - умножение на коэффициент
                - скалярное произведение
                - векторное произведение (= площадь параллелограмма)
        */

        /// <summary>
        /// Constructor based on two <see cref="double"/> coordinates for the <see cref="Vector"/> struct.
        /// </summary>
        /// <param name="x"> <see cref="double"/> X coordinate. </param>
        /// <param name="y"> <see cref="double"/> Y coordinate. </param>
        public Vector(double x, double y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Returns Square Length of the <see cref="Vector"/> of type <see cref="double"/>.
        /// </summary>
        /// <returns> Square Length of the <see cref="Vector"/> of type <see cref="double"/>. </returns>
        public double SquareLength()
        {
            return X * X + Y * Y;
        }

        /// <summary>
        /// Adds the <see cref="Vector"/> parameter to the <see cref="Vector"/>.
        /// </summary>
        /// <param name="v"> The <see cref="Vector"/> that will be added to this <see cref="Vector"/>. </param>
        /// <returns> Sum of this <see cref="Vector"/> and the parameter. </returns>
        public Vector Add(Vector v)
        {
            double newX = X + v.X;
            double newY = Y + v.Y;
            return new Vector(newX, newY);
        }

        /// <summary>
        /// Scales the <see cref="Vector"/> linearly by multiplying components.
        /// </summary>
        /// <param name="k"> Scaling <see cref="double"/> coefficient. </param>
        /// <returns> Scaled <see cref="Vector"/>. </returns>
        public Vector Scale(double k)
        {
            double newX = X * k;
            double newY = Y * k;
            return new Vector(newX, newY);
        }

        /// <summary>
        /// Calculates the dot product of two object of <see cref="Vector"/> type.
        /// </summary>
        /// <param name="v"> The second <see cref="Vector"/> in dot product. </param>
        /// <returns> <see cref="double"/> result of the dot product. </returns>
        public double DotProduct(Vector v)
        {
            return X * v.X + Y * v.Y;
        }

        /// <summary>
        /// Calculates the absolute of the cross product of two object of <see cref="Vector"/> type.
        /// </summary>
        /// <param name="v"> The second <see cref="Vector"/> in cross product. </param>
        /// <returns> Absolute <see cref="double"/> result of the cross product. </returns>
        public double CrossProduct(Vector v)
        {
            return X * v.Y - Y * v.X;
        }

        // Coordinates of the vector
        private readonly double _y;
        private readonly double _x;
        public double X => _x;
        public double Y => _y; // Readonly

        /*
            Переопредели ниже метод ToString - пусть выводит (X; Y)
        */

        /// <summary>
        /// Returns the <see cref="String"/> representation of the <see cref="Vector"/>.
        /// </summary>
        /// <returns> <see cref="String"/> representation of the <see cref="Vector"/>. </returns>
        public override string ToString()
        {
            return $"({X.ToString()}; {Y.ToString()})";
        }

        #region operators

        /*
            Реализуй также следущие операторы (Vector v, u и double k):
                - v + u, v - u
                - k * v, v * k, v / k
                - +v, -v
        */

        /// <summary>
        /// Unary plus operator.
        /// </summary>
        /// <param name="v"> <see cref="Vector"/> to return with the same sign. </param>
        /// <returns> <see cref="Vector"/> of the same sign. </returns>
        public static Vector operator +(Vector v)
        {
            return v;
        }

        /// <summary>
        /// Unary minus operator.
        /// </summary>
        /// <param name="v"> <see cref="Vector"/> to return with the opposite sign. </param>
        /// <returns> <see cref="Vector"/> of the opposite sign. </returns>
        public static Vector operator -(Vector v)
        {
            return v.Scale(-1d);
        }

        /// <summary>
        /// Binary plus operator.
        /// </summary>
        /// <param name="v"> First <see cref="Vector"/> in the sum. </param>
        /// <param name="u"> Second <see cref="Vector"/> in the sum. </param>
        /// <returns> The sum of two objects of <see cref="Vector"/> type. </returns>
        public static Vector operator +(Vector v, Vector u)
        {
            return v.Add(u);
        }

        /// <summary>
        /// Binary minus operator.
        /// </summary>
        /// <param name="v"> First <see cref="Vector"/> in the subtraction. </param>
        /// <param name="u"> Second <see cref="Vector"/> in the subtraction. </param>
        /// <returns> The subtraction of two objects of <see cref="Vector"/> type. </returns>
        public static Vector operator -(Vector v, Vector u)
        {
            return v.Add(-u);
        }

        /// <summary>
        /// Scalar multiplication operator of <see cref="Vector"/> and <see cref="double"/>.
        /// </summary>
        /// <param name="v"> <see cref="Vector"/> to multiply by the scalar. </param>
        /// <param name="k"> <see cref="double"/> scalar to multiply <see cref="Vector"/> by. </param>
        /// <returns> The <see cref="Vector"/> result of the multiplication of <see cref="Vector"/> and <see cref="double"/>. </returns>
        public static Vector operator *(Vector v, double k)
        {
            return v.Scale(k);
        }

        /// <summary>
        /// Scalar multiplication operator of <see cref="double"/> and <see cref="Vector"/>.
        /// </summary>
        /// <param name="v"> <see cref="Vector"/> to multiply by the scalar. </param>
        /// <param name="k"> <see cref="double"/> scalar to multiply <see cref="Vector"/> by. </param>
        /// <returns> The <see cref="Vector"/> result of the multiplication of <see cref="Vector"/> and <see cref="double"/>. </returns>
        public static Vector operator *(double k, Vector v)
        {
            return v.Scale(k);
        }

        /// <summary>
        /// Division operator of <see cref="Vector"/> and <see cref="double"/>.
        /// </summary>
        /// <param name="v"> <see cref="Vector"/> to divide by the scalar. </param>
        /// <param name="k"> <see cref="double"/> scalar to divide <see cref="Vector"/> by. </param>
        /// <returns> The <see cref="Vector"/> result of the division of <see cref="Vector"/> and <see cref="double"/>. </returns>
        public static Vector operator /(Vector v, double k)
        {
            if (k == 0)
                throw new DivideByZeroException("Scaling coefficient can not be zero!");
            return v.Scale(1/k);
        }


        #endregion
    }

    #endregion

    /*
        Время отправиться в VectorExtensions.cs за новой порцией квестов, герой!
        Как закончишь, возвращайся за щедрым вознаграждением!
    */


    #region 3. Комментарии

    /*
        Прости, я соврал. К сожалению, пока ты делал(-а) вторую часть, человек, который понимал, о чем идет речь в первой части,
        успел съездить в путешествие под названием "во все тяжкие" и теперь проходит курс реабилитации. А те, кто был хотя бы примерно в теме,
        внезапно лишились рассудка.
        Тут еще из будущего сообщили, что тебе дали задачу поинтереснее, и ты наотрез отказался(-ась) сотрудничать в передаче знаний.
        Ну а вместо тебя на эту задачу взяли пушистого котика, который отказывается разбираться в коде и уж тем более его писать - говорит у него лапки.

        В такой ситуации единственно возможное решение задачи - оставить после себя комментарии. Такие, чтобы даже котику было понятно!
        В общем, впереди неприятная для многих часть - необходимо добавить комментарии ко всем введенным типам, методам и свойствам :)


        _Хозяйке на заметку_

        Для многих это действительно довольно неприятная и скучнейшая часть - писать комментарии к коду. Проблема в том,
        что это еще и не так просто как кажется на первый взгляд. Очень желательно выдерживать единый стиль, писать по существу,
        писать не "для текущего разобравшегося в проблеме и предметной области себя", а для "того парня", "себя через год". Ну или пушистого котика.

        Есть и хорошее в этом деле. Комментирование кода очень похоже на написание автотестов - оно позволяет взглянуть
        на задачу и ее решение немного с другой стороны. Например, если слова не вяжутся, и не получается написать простое и короткое
        описание к методу или типу - это хороший сигнал, что он "с душком", и его стоит переделать/отрефакторить. 
        Я лично чаще пишу комментарии ближе к концу работы над задачей. Это позволяет мне еще раз просмотреть весь написанный код под
        слегка иным углом обзора и самому сделать первичный code review.


        Ты мог(-ла) заметить, что в предыдущих заданиях для комментариев я использовал немного необычный синтаксис:
    
            /// <summary>
            /// Возвращает объект <see cref="DateTime"/> с заданными временем и значением <see cref="DateTime.Kind"/>.
            /// </summary>
            /// <param name="dt">Объект <see cref="DateTime"/>, задающий время.</param>
            /// <param name="kind">Значение <see cref="DateTime.Kind"/>, задающий соответствующее свойство возвращаемого объекта.</param>
            /// <returns>Объект <see cref="DateTime"/> с заданными временем и значением <see cref="DateTime.Kind"/>.</returns>

        Такой блок является комментарием, т.к. каждая строка начинается с //, но имеет свою внутреннюю структуру и синтаксис.
        Это так называемые Xml documentation comments. Их поддерживает сам компилятор. Они позволяют писать чуть более умные и продвинутые комментарии к сущностям,
        а потом, например, автоматически генерировать по ним красивую документацию.
        Правилом хорошего тона считается писать комментарии к методам, классам и другим сущностям, используя данный синтаксис - так ты и комментируешь их, и документируешь.
        Внутри методов он не поддерживается, поэтому там только обычные (// или /*).

        Ниже приведены примеры простейших комментариев. Если наведете мышкой на название метода DoNothing, увидишь,
        что студия отображает комментарий в подписи (в других IDE из коробки без плагинов это вряд ли будет работать).
        Если навести на аргумент метода DoNothing - something, увидишь комментарий к нему.
        Наведи теперь на NotImplementedException() - комментарий во всплывашке сделан с помощью такого же синтаксиса.
        Код .Net Framework задокументирован именно таким синтаксисом.

        Чтобы создать такой комментарий, не нужно писать разметку целиком самому. Если ввести ///, студия сама создаст нужные блоки.

        Плюсы Xml documentation comments:
            - блок комментариев имеет четкую предзаданную структуру, что дает возможность воспользоваться различными инструментариями
                автогенерации документации (и создавать, например, документацию вроде MSDN).
                В последней лабе мы, надеюсь, научимся генерировать для web api страничку с документацией к нашему апи и увидим, что генератор в том числе
                может для каждого метода апи создавать формочку для его проверки и ручного тестирования.
            - IDE может показывать ее в чуть более удобном виде, нежели если бы ты писал(-а) их обычным способом.
                Например, показывать во всплывающей подсказке только самое необходимое короткое описание, а длинное с пояснениями и примерами кода не показывать.
            - все названия типов, методов и свойств можно задавать в виде ссылки, например, <see cref=Vector.DotProduct"/>, и это
                будет строгая, проверяемая компилятором, ссылка. Ты, думаю, помнишь, что компилятор как сервис в частности предоставляет разные возможности рефакторинга,
                например, переименование. Так вот, если воспользоваться им и переименовать метод DotProduct у структуры Vector, то
                переименуется и текст в ссылке. Если же ссылка указывает на невалидную сущность, то студия явно даст понять: "Cannot resolve symbol 'blah-blah-blah'".
                Я лично не проверял, но по идее можно даже сделать так, чтобы в таком случае была ошибка компиляции. В генерируемой же документации эти ссылки будут
                заменены на реальные ссылки на страницы описания соответствующей сущности, что довольно удобно для навигации по ней.

    */

    /// <summary>
    /// Класс, не делающий ничего.
    /// </summary>
    internal class Foo
    {
        /// <summary>
        /// Не делает ничего, как и подобает методам данного класса.
        /// </summary>
        /// <param name="something">Экземпляр <see cref="object"/> чего бы то ни было.</param>
        public static void DoNothing(object something)
        {
            // nothing to do here
        }

        public static void ThrowNotImplementedException()
        {
            throw new NotImplementedException();
        }
    }

    #endregion


    #region 4. Тесты

    /*
        Прости еще раз, но на этом твои мучения еще не кончаются. Проблема в том, что у котика все еще лапки, поэтому очень важно
        покрыть тестами хотя бы базовые методы структуры Vector:
            SquareLength
            Add
            Scale
            DotProduct
            CrossProduct

        Для этого создай в этом же солюшене (если ты не в студии, то можешь и не в солюшене) проект BoringVector.Tests,
        который будет содержать класс с набором тестов. Используй Xunit (в принципе можешь воспользоваться и другим фреймворком для тестирования).

        Особо не заморачивайся с тем, чтобы оттестировать все возможные специальные случаи - в данном задании важно, чтобы
        ты просто разобрался(-ась), как писать автотесты и как их запускать. Это задание НЕ на то, как писать хорошие тесты.

        Примечание: структура Vector описана как internal структура, поэтому по умолчанию сборке BoringVector.Tests она не видна.
        Чтобы она была видна, существует специальная директива компилятору:
            [assembly: InternalsVisibleTo("XXX")]
        , где XXX - название проекта, которому ты хочешь сделать видимыми свои internal'ы.

        Можешь посмотреть, в задании [01-primitive-types] эта директива есть в файле Program.cs проекта Numbers.

        Итак, создай проект с тестами и добейся того, чтобы базовые методы структуры Vector их проходили.
    */

    #endregion


    /*
        На этом все. Время делать пулл реквест и наслаждаться заслуженным отдыхом :)
    */
}
