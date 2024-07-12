using System.Reflection.PortableExecutable;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;

namespace BaseConvertor
{
    public class BaseConvertorApp
    {
        public void Run()
        {
            bool proceed = true;

            while (proceed)
            {
               
                Console.Write("Zadej číslo: ");
                string number = Console.ReadLine();
                Console.Write("Zadej číselnou soustavu: ");
                double numberBase = SafelyConvertToInt(Console.ReadLine());
                Console.Write("Zadej výslednou soustavu: ");
                double toBase = SafelyConvertToInt(Console.ReadLine());

                ConvertBase(number, numberBase, toBase);
            }
        }
        public void ConvertBase(string number, double numberBase, double toBase)
        {
            string[] digits = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            double sumInBase = 0;

            for (int i = 0; i <= number.Length-1; i++)
            {
                string digitInNumber = number[number.Length - (i+1)].ToString();
                int valueOfDigit = Array.IndexOf(digits, digitInNumber);
                sumInBase += valueOfDigit * Math.Pow(numberBase, i);
            }
            Console.WriteLine(sumInBase);

            double j = 0;
            while (true)
            {
                if (sumInBase / Math.Pow(toBase, j) < 1)
                {
                    j--;
                    break;
                }
                else
                {
                    j++;
                }
            }

            int remainder = Convert.ToInt32(sumInBase);

            for (int i = Convert.ToInt32(j); i >= 0; i--) {

                int result = remainder / Convert.ToInt32(Math.Pow(toBase, i));

                remainder = remainder % Convert.ToInt32(Math.Pow(toBase, i));

                Console.Write(digits[result]);
            }

            Console.WriteLine("");
        }
        public double SafelyConvertToInt(string s)
        {
            if (double.TryParse(s, out double result))
            {
                return result;
            }
            return 0;
        }
    }
}
