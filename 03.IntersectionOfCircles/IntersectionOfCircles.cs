using System;

namespace _03.IntersectionOfCircles
{
    class IntersectionOfCircles
    {
        static void Main()
        {
            Circle firstCircle = new Circle(Console.ReadLine().Split(' '));
            Circle secondCircle = new Circle(Console.ReadLine().Split(' '));

            if (Intercection(firstCircle, secondCircle))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }

        static bool Intercection(Circle FirstCircle, Circle SecondCircle)
        {
            double Distance = Math.Sqrt(Math.Pow(Math.Abs(FirstCircle.Center.X - SecondCircle.Center.X), 2) + Math.Pow(Math.Abs(FirstCircle.Center.Y - SecondCircle.Center.Y), 2));
            long RadiusSumm = FirstCircle.Radius + SecondCircle.Radius;

            return Distance <= RadiusSumm;
        }
    }
}
