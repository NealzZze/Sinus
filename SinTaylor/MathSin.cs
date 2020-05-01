using System;

namespace SinTaylor
{
    public class MathSin
    {
        public static double Sin(double x, double epsilon ,out int count)
        {
            var s = x;
            double sum = 0;
            var n = 0;
            do
            {
                sum += s;
                s *= -Math.Pow(x, 2) / ((2 * n + 2) * (2 * n + 3));
                n++;
            } while (Math.Abs(s) >= epsilon);
            count = n;
            return sum;
        }
    }
}