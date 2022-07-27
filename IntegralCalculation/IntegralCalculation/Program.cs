using System;
using IntegralCalculation;

namespace IntegralCalculation
{
    class Program
    {
        /// <summary>
        /// Вызываем Test1 в методе Main
        /// </summary>
        static void Main(string[] args)
        {
            Test1();
        }

        /// <summary>
        /// глобально объявляем делегат
        /// </summary>
        public delegate double Function(double x);

        /// <summary>
        /// Функция  трапециевидного метода для интеграла
        /// </summary>
        /// <param name="f">Делегат функции</param>
        /// <param name="a">Нижний предел</param>
        /// <param name="b">Верхний предел</param>
        /// <param name="n">количество</param>
        /// <returns>Сумму</returns>
        public static double Trapezoidal(Function f, double a, double b, int n)
        {
            double sum = 0.0;
            double h = (b - a) / n;
            for (int i = 0; i < n; i++)
            {
                sum += 0.5 * h * (f(a + i * h) + f(a + (i + 1) * h));
            }
            return sum;
        }

        /// <summary>
        /// Функция с использованием массива данных
        /// </summary>
        /// <param name="y">Массив данных</param>
        /// <param name="a">Нижний предел</param>
        /// <param name="b">Верхний предел</param>
        /// <param name="n">Количество</param>
        /// <returns>Сумма</returns>
        public static double Trapezoidal(double[] y, double a, double b, int n)
        {
            double sum = 0.0;
            double h = (b - a) / (n - 1);
            for (int i = 0; i < (n - 1); i++)
            {
                sum += 0.5 * h * (y[i] + y[i + 1]);
            }
            return sum;
        }

        /// <summary>
        /// Функция вычисления косинуса при помощи класса Math
        /// </summary>
        /// <param name="x">Переменная X</param>
        /// <returns>Результат вычисления</returns>
        static double df(double x)
        {
            return Math.Cos(x);
        }

        /// <summary>
        /// Функция вычисления синуса при помощи класса Math
        /// </summary>
        /// <param name="x">Переменная X</param>
        /// <returns>Результат вычисления</returns>
        static double f(double x)
        {
            return Math.Sin(x);
        }

        /// <summary>
        /// Тесты
        /// </summary>
        static void Test1()
        {
            int eps = 1000;
            double a = 0.0;
            double b = 2.0;
            double result;

            Console.WriteLine("\nИспытание трапециевидного метода для интеграла(df(x)) = f(x) где");
            Console.WriteLine("f(x) = sin(x), df(x) = cos(x) и a=0 до b=2.\n");

            result = f(b) - f(a);
            Console.WriteLine("Анализируем результат = " + result.ToString()+ "\n");

            result = Trapezoidal(df, a, b, eps);
            Console.WriteLine("Результат использованной функции = " + result.ToString() + "\n");

            double[] y = new double[eps];
            double h = (b - a) / (eps - 1);
            for (int i = 0; i < eps; i++)
            {
                double x = i * h;
                y[i] = df(x);
            }
            result = Trapezoidal(y, a, b, eps);
            Console.WriteLine("Результат с использованием массива данных = " + result.ToString());
            Console.ReadKey();
        }

        static void Test2()
        {
            int n = 1000;
            double a = 0.0;
            double b = 2.0;
            double result;

            Console.WriteLine("\nИспытание трапециевидного метода для интеграла(df(x)) = f(x) где");
            Console.WriteLine("f(x) = sin(x), df(x) = cos(x) и a=0 до b=1.\n");

            result = f(b) - f(a);
            Console.WriteLine("Анализируем результат = " + result.ToString() + "\n");

            result = Trapezoidal(df, a, b, n);
            Console.WriteLine("Результат использованной функции = " + result.ToString() + "\n");

            double[] y = new double[n];
            double h = (b - a) / (n - 1);
            for (int i = 0; i < n; i++)
            {
                double x = i * h;
                y[i] = df(x);
            }
            result = Trapezoidal(y, a, b, n);
            Console.WriteLine("Результат с использованием массива данных = " + result.ToString());
            Console.ReadKey();
        }

    }
}
