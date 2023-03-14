using System;
using System.Linq;

namespace HomeHeatingCalc
{
    public class Program
    {
        // Define variable constant
        private const decimal WinterCoefficient = 0.12m;
        private const decimal ConversionCoefficient = 293m / 1000000m;
        private const int SmallHomeSize = 1500;
        private const int LargeHomeSize = 2500;
        private const int SmallHomeCost = 5000000;
        private const int LargeHomeCost = 8000000;

        static void Main(string[] args)
        {
            Console.WriteLine("Home Heating Cost Calculator...");
            Console.WriteLine("How many square feet is your home ({0} or {1})?", SmallHomeSize, LargeHomeSize);
            int size = int.Parse(Console.ReadLine());
            Console.WriteLine("How severe are your winters (Mild, moDerate, Severe)?");
            // Define variable as severity
            string severity = Console.ReadLine();

            // Define severity variable
            decimal cost = CalculateCost(size, severity);

            Console.WriteLine("Cost: ${0}", cost);
            Console.ReadLine();
        }

        // Calculate Cost Method
        private static decimal CalculateCost(int size, string severity)
        {
            decimal cost = 0;

            if (severity.Contains("M"))
            {
                cost = CalculateMildWinterCost(size);
            }
            else if (severity.Contains("D"))
            {
                cost = CalculateModerateWinterCost(size);
            }
            else if (severity.Contains("S"))
            {
                cost = CalculateSevereWinterCost(size);
            }

            return Math.Round(cost, 2);
        }

        // Calculate Mild Winter Cost Method
        private static decimal CalculateMildWinterCost(int size)
        {
            return (decimal)size * 1000 * WinterCoefficient * ConversionCoefficient;
        }

        // Calculate Mild Winter Cost Method
        private static decimal CalculateModerateWinterCost(int size)
        {
            return (decimal)size * 2000 * WinterCoefficient * ConversionCoefficient;
        }

        // Calculate Mild Winter Cost Method
        private static decimal CalculateSevereWinterCost(int size)
        {
            decimal cost = 0;

            if (size == SmallHomeSize)
            {
                cost = (decimal)SmallHomeCost * WinterCoefficient * ConversionCoefficient;
            }
            else if (size == LargeHomeSize)
            {
                cost = (decimal)LargeHomeCost * WinterCoefficient * ConversionCoefficient;
            }

            return cost;
        }
    }
}