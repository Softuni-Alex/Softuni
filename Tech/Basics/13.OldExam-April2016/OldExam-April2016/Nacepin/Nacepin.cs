using System;

namespace Nacepin
{
    class Nacepin
    {
        static void Main(string[] args)
        {
            decimal storeUS = decimal.Parse(Console.ReadLine());
            long boxWeightUS = long.Parse(Console.ReadLine());
            decimal storeUK = decimal.Parse(Console.ReadLine());
            long boxWeightUK = long.Parse(Console.ReadLine());
            decimal storeCH = decimal.Parse(Console.ReadLine());
            long boxWeightCH = long.Parse(Console.ReadLine());

            decimal usToLevaKilograms = storeUS / 0.58m;
            decimal ukToLevaKilograms = storeUK / 0.41m;
            decimal chToLevaKilograms = storeCH * 0.27m;

            decimal lowestKGPriceUS = usToLevaKilograms / boxWeightUS;
            decimal lowestKGPriceUK = ukToLevaKilograms / boxWeightUK;
            decimal lowestKGPriceCH = chToLevaKilograms / boxWeightCH;

            if (lowestKGPriceUS < lowestKGPriceUK && lowestKGPriceUS < lowestKGPriceCH)
            {
                if (lowestKGPriceUK > lowestKGPriceCH)
                {
                    Console.WriteLine("US store. {0:f2} lv/kg", lowestKGPriceUS);
                    Console.WriteLine("Difference {0:f2} lv/kg", lowestKGPriceUK - lowestKGPriceUS);
                }
                else
                {
                    Console.WriteLine("US store. {0:f2} lv/kg", lowestKGPriceUS);
                    Console.WriteLine("Difference {0:f2} lv/kg", lowestKGPriceCH - lowestKGPriceUS);
                }
            }

            if (lowestKGPriceUK < lowestKGPriceUS && lowestKGPriceUK < lowestKGPriceCH)
            {
                if (lowestKGPriceUS > lowestKGPriceCH)
                {
                    Console.WriteLine("UK store. {0:f2} lv/kg", lowestKGPriceUK);
                    Console.WriteLine("Difference {0:f2} lv/kg", lowestKGPriceUS - lowestKGPriceCH);
                }
                else
                {
                    Console.WriteLine("UK store. {0:f2} lv/kg", lowestKGPriceUK);
                    Console.WriteLine("Difference {0:f2} lv/kg", lowestKGPriceCH - lowestKGPriceUK);
                }
            }

            if (lowestKGPriceCH < lowestKGPriceUK && lowestKGPriceCH < lowestKGPriceUS)
            {
                if (lowestKGPriceUK > lowestKGPriceUS)
                {
                    Console.WriteLine("Chinese store. {0:f2} lv/kg", lowestKGPriceCH);
                    Console.WriteLine("Difference {0:f2} lv/kg", lowestKGPriceUK - lowestKGPriceCH);
                }
                else
                {
                    Console.WriteLine("Chinese store. {0:f2} lv/kg", lowestKGPriceCH);
                    Console.WriteLine("Difference {0:f2} lv/kg", lowestKGPriceUS - lowestKGPriceCH);
                }
            }
        }
    }
}