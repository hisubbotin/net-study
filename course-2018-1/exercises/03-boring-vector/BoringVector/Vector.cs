using System;

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

        public readonly double X;
        public readonly double Y;

        public Vector(double x, double y)
        {
            X = x;
            Y = y;
        }

        /*
            На месте заглушек добавь реализацию базовых методов вектора:
                - квадрат длины
                - сумма векторов
                - умножение на коэффициент
                - скалярное произведение
                - векторное произведение (= площадь параллелограмма)
        */

        /// <summary>
        /// Returns square length of the vector.
        /// </summary>
        /// <returns>Square length of the vector.</returns>
        public double SquareLength()
        {
            return X * X + Y * Y;
        }
        
        /// <summary>
        /// Adds given vector to this particular one.
        /// </summary>
        /// <param name="v">Given vector.</param>
        /// <returns>New vector, which equals to the sum of two.</returns>
        public Vector Add(Vector v)
        {
            return new Vector(X + v.X, Y + v.Y);
        }
        
        /// <summary>
        /// Scales this particular vector in k times.
        /// </summary>
        /// <param name="k">Scale factor.</param>
        /// <returns>New vector, which equals to the scaled first one.</returns>
        public Vector Scale(double k)
        {
            return new Vector(k * X, k * Y);
        }
        
        /// <summary>
        /// Computes dot product of given vector and this particular one.
        /// </summary>
        /// <param name="v">Given vector.</param>
        /// <returns>Dot product of two vectors.</returns>
        public double DotProduct(Vector v)
        {
            return X * v.X + Y * v.Y;
        }
        
        /// <summary>
        /// Computes cross product of given vector and this particular one.
        /// </summary>
        /// <param name="v">Given vector.</param>
        /// <returns>Cross product of two vectors.</returns>
        public double CrossProduct(Vector v)
        {
            return X * v.Y - Y * v.X;
        }

        /*
            Переопредели ниже метод ToString - пусть выводит (X; Y)
        */

        /// <summary>
        /// Returns string representation of this particular vector.
        /// </summary>
        /// <returns>String representation of vector.</returns>
        public override string ToString()
        {
            return $"({X}, {Y})";
        }

        #region operators

        /*
            Реализуй также следущие операторы (Vector v, u и double k):
                - v + u, v - u
                - k * v, v * k, v / k
                - +v, -v
        */

        /// <summary>
        /// Computes sum of two given vectors.
        /// </summary>
        /// <param name="v">First vector.</param>
        /// <param name="u">Second vector.</param>
        /// <returns>New vector, that is a sum of given two.</returns>
        public static Vector operator +(Vector v, Vector u)
        {
            return new Vector(v.X + u.X, v.Y + u.Y);
        }
        
        /// <summary>
        /// Computes difference of two given vectors.
        /// </summary>
        /// <param name="v">First vector.</param>
        /// <param name="u">Second vector.</param>
        /// <returns>New vector, that is a difference of given two.</returns>
        public static Vector operator -(Vector v, Vector u)
        {
            return new Vector(v.X - u.X, v.Y - u.Y);
        }
        
        /// <summary>
        /// Scales given vector in k times.
        /// </summary>
        /// <param name="v">Given vector.</param>
        /// <param name="k">Scale factor.</param>
        /// <returns>New vector, which equals to the scaled first one.</returns>
        public static Vector operator *(Vector v, double k)
        {
            return new Vector(k * v.X, k * v.Y);
        }
        
        /// <summary>
        /// Scales given vector in k times.
        /// </summary>
        /// <param name="k">Scale factor.</param>
        /// <param name="v">Given vector.</param>
        /// <returns>New vector, which equals to the scaled first one.</returns>
        public static Vector operator *(double k, Vector v)
        {
            return new Vector(k * v.X, k * v.Y);
        }
        
        /// <summary>
        /// Perform action opposite to scale.
        /// </summary>
        /// <param name="v">Given vector.</param>
        /// <param name="k">Scale factor.</param>
        /// <returns>New vector, which length is decreased in k times.</returns>
        public static Vector operator /(Vector v, double k)
        {
            return new Vector(v.X / k, v.Y / k);
        }
        
        /// <summary>
        /// Returns given vector back.
        /// </summary>
        /// <param name="v">Given vector.</param>
        /// <returns>Given vector.</returns>
        public static Vector operator +(Vector v)
        {
            return new Vector(v.X, v.Y);
        }
        
        /// <summary>
        /// Creates new vector, which points to the opposite direction.
        /// </summary>
        /// <param name="v">Given vector.</param>
        /// <returns>New vector, which is opposite to the given one.</returns>
        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y);
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
