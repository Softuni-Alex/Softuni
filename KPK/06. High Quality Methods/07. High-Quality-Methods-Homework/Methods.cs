namespace Methods
{
    using System;

    public class Methods
    {
        /// <summary>
        /// Calculates the triangle area.
        /// </summary>
        /// <param name="firstSide">The first side.</param>
        /// <param name="secondSide">The second side.</param>
        /// <param name="thirdSide">The third side.</param>
        /// <returns>System.Double.</returns>
        public static double CalcTriangleArea(double firstSide, double secondSide, double thirdSide)
        {
            if (firstSide <= 0 || secondSide <= 0 || thirdSide <= 0)
            {
                Console.Error.WriteLine("Sides should be positive.");
            }

            double perimeter = (firstSide + secondSide + thirdSide) / 2;
            //Heron's theorem
            double area = Math.Sqrt(perimeter * (perimeter - firstSide) *
                                    (perimeter - secondSide * (perimeter - thirdSide)));
            return area;
        }

        static string NumberToDigit(int number)
        {
            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    return "Invalid number!";
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                return 0;
            }

            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > elements[0])
                {
                    elements[0] = elements[i];
                }
            }
            return elements[0];
        }

        static void PrintAsNumber(object number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
        }


        static double CalcDistance(double x1, double x2, double y1, double y2,
                                   out bool isHorizontal, out bool isVertical)
        {
            isHorizontal = (y1 == y2);
            isVertical = (x1 == x2);

            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));

            Console.WriteLine(NumberToDigit(5));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            bool horizontal, vertical;
            Console.WriteLine(CalcDistance(3, -1, 3, 2.5, out horizontal, out vertical));
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student Alex = new Student() { FirstName = "Alex", LastName = "Den" };
            Alex.OtherInfo = "From Sofia, born at 7.12.1996";

            Student Ler = new Student() { FirstName = "Ler", LastName = "Mater" };
            Ler.OtherInfo = "From Burgas, coder, high results, born at 10.11.1996";

            Console.WriteLine("{0} older than {1} -> {2}",
                Alex.FirstName, Ler.FirstName, Alex.IsOlderThan(Ler));
        }
    }
}
