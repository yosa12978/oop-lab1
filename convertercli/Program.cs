using System;
using System.Runtime.CompilerServices;


///<summary>
/// https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/builtin-types/numeric-conversions#implicit-numeric-conversions
/// Неявные числовые преобразования
/// Исходный тип 	Кому
/// sbyte           short, int, long, float, double, decimal или nint
/// byte 	        short, ushort, int, uint, long, ulong, float, double, decimal, nint или nuint
/// short 	        int, long, float, double или decimal либо nint
/// ushort 	        int, uint, long, ulong, float, double или decimal, nint или nuint
/// int 	        long, float, double или decimal, nint
/// uint 	        long, ulong, float, double или decimal либо nuint
/// long 	        float, doubleили decimal
/// ulong 	        float, doubleили decimal
/// float 	        double
/// nint 	        long, float, double или decimal
/// nuint 	        ulong, float, double или decimal
///</summary>


///<summary>
/// https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/builtin-types/numeric-conversions#explicit-numeric-conversions
/// Явные числовые преобразования
/// Исходный тип 	Кому
/// sbyte 	        byte, ushort, uint, ulong или nuint
/// byte 	        sbyte
/// short           sbyte, byte, ushort, uint, ulong или nuint
/// ushort          sbyte, byteили short
/// int             sbyte, byte, short, ushort, uint, ulong или nuint
/// uint            sbyte, byte, short, ushort, int или nint
/// long            sbyte, byte, short, ushort, int, uint, ulong, nint или nuint
/// ulong           sbyte, byte, short, ushort, int, uint, long, nint или nuint
/// float           sbyte, byte, short, ushort, int, uint, long, ulong, decimal, nint или nuint
/// double          sbyte, byte, short, ushort, int, uint, long, ulong, float, decimal, nint или nuint
/// decimal         sbyte, byte, short, ushort, int, uint, long, ulong, float, double, nint или nuint
/// nint            sbyte, byte, short, ushort, int, uint, ulong или nuint
/// nuint           sbyte, byte, short, ushort, int, uint, long или nint
///</summary>

namespace Converterapp
{
    public static class DynamicConverter
    {
        public static T? Convert<T>(dynamic a)
        {
            try
            {
                return (T)a;
            }catch (Exception e)
            {
                return default(T);
            }
        }
    }
    public class Fraction
    {
        // Числитель
        public int n { get; private set; }
        // Знаменатель
        public int m { get; private set; }

        // Конструктор класса
        public Fraction(int n, int m)
        {
            if (m == 0)
                throw new DivideByZeroException();
            this.n = n;
            this.m = m;
        }


        // Оператор неявного преобразования в double
        public static implicit operator double(Fraction f) => (double)f.n/ (double)f.m;
        // Оператор неявного преобразования в int
        public static implicit operator int(Fraction f) => f.n / f.m;

        // Оператор явного преобразования из double
        public static explicit operator Fraction(double d)
        {
            int gcd = GCD((int)(d*100), 100);
            return new Fraction((int)(d * 100)/gcd, 100/gcd);
        }
        // Оператор явного преобразования из int
        public static explicit operator Fraction(int d) =>
            new Fraction(d, 1);

        // Функция для представления в виде строки
        public override string ToString() => $"{n}/{m}";

        // Функция нахождения нод двух чисел
        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int remainder = a % b;
                a = b;
                b = remainder;
            }
            return a;
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            // Неявные преобразования между ссылочными типами
            // Можно неявно преобразовать объект производного класса к базовому классу или интерфейсу
            object obj = "Hello"; // string наследует от object
            IComparable comp = "World"; // string реализует интерфейс IComparable

            Console.WriteLine($"obj = {obj}, comp = {comp}");
            // obj = Hello, comp = World

            // Явные преобразования между числовыми типами
            // Требуются, если возможна потеря данных или выход за диапазон значений
            double x = 123.456; // 64 бита с плавающей точкой
            int n = (int)x; // 32 бита без знака, требуется явное преобразование из double

            Console.WriteLine($"x = {x}, n = {n}");

            // Явные преобразования между ссылочными типами
            // Требуются, если нужно преобразовать объект базового класса к производному классу или другому интерфейсу
            object obj2 = new Fraction(1, 2); // Fraction наследует от object
            Fraction frac1 = (Fraction)obj2; // Требуется явное преобразование из object в Fraction

            Console.WriteLine($"frac1 is Fraction = {frac1 is Fraction}");


            // Пользовательское преобразование типов Implicit, Explicit
            // Можно определить для своих классов с помощью ключевых слов implicit и explicit
            Fraction f = new Fraction(5, 4);

            // Неявное преобразование дроби в double с помощью оператора implicit, определенного в классе Fraction
            double m = f;
            Console.WriteLine(m.ToString());

            // Неявное преобразование дроби в int с помощью оператора implicit, определенного в классе Fraction
            int k = f;
            Console.WriteLine(k.ToString());

            // Явное преобразование double в Fraction с помощью оператора explicit, определенного в классе Fraction
            Console.WriteLine(((Fraction)1.25).ToString());
            // Явное преобразование double в Fraction с помощью оператора explicit, определенного в классе Fraction
            Console.WriteLine(((Fraction)3.44).ToString());


            // Явные преобразования между числовыми типами
            // Требуются, если возможна потеря данных или выход за диапазон значений
            double x1 = 123.456; // 64 бита с плавающей точкой
            int n1= (int)x1; // 32 бита без знака, требуется явное преобразование из double

            Console.WriteLine($"x = {x1}, n = {n1}");

            // Вызов и обработка исключения преобразования типов
            // Может возникнуть, если преобразование невозможно или некорректно
            try
            {
                object obj3 = "test"; // Строка
                Fraction frac3 = (Fraction)obj3; // Попытка преобразовать строку в Fraction
                Console.WriteLine($"frac3 = {frac3}");
            }
            catch (InvalidCastException ex) // Перехват исключения неверного преобразования типов
            {
                Console.WriteLine(ex.Message); // Вывод сообщения об ошибке
            }

            // Безопасное приведение ссылочных типов с помощью операторов as и is
            // Оператор as возвращает null, если преобразование невозможно
            object obj4 = "test"; // Строка
            Fraction? frac4 = obj4 as Fraction; // Попытка преобразовать строку в Fraction с помощью as
            if (frac4 == null) // Проверка на null
            {
                Console.WriteLine("Преобразование не удалось"); // Вывод сообщения
            }

            // Оператор is возвращает true, если преобразование возможно, и false в противном случае
            object obj5 = new Fraction(5, 6); // Дробь
            if (obj5 is Fraction) // Проверка с помощью is
            {
                Fraction frac5 = (Fraction)obj5; // Преобразование возможно
                Console.WriteLine($"frac5 = {frac5}"); // Вывод значения
            }


            // Преобразование с помощью класса Convert и преобразование строки в число с помощью методов Parse, TryParse класса System.Int32
            string s1 = "123"; // Строка, содержащая число
            int n2 = Convert.ToInt32(s1); // Преобразование строки в int с помощью класса Convert
            Console.WriteLine($"s1 = {s1}, n1 = {n2}");

            string s2 = "456"; // Строка, содержащая число
            int n3;
            // Попытка преобразовать строку в int с помощью метода TryParse класса Int32
            if (Int32.TryParse(s2, out n3)) // Если преобразование успешно
                Console.WriteLine($"s2 = {s2}, n2 = {n3}");


            int num = DynamicConverter.Convert<int>(2.5);
            Console.WriteLine($"num = {num}");

        }
    }
}