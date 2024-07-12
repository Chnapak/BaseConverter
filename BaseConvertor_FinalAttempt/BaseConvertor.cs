namespace BaseConvertor_FinalAttempt
{
    internal class BaseConvertor
    {
        public void Run()
        {
            // This program converts numbers from one base to another using common math notation.

            /* Program runs forever, I could probably think of an input that would exit the user out,
               but I find that idea to be too complex. */
            while (true)
            {

                // Translation: Input number
                Console.Write("Zadej číslo: ");
                string number = Console.ReadLine()!;

                // Translation: Of what base is this number?
                Console.WriteLine("Jaka je soustava tohoto cisla?");
                Console.Write($"({number})"); // e.g. (number)base
                int base_input = SafelyConvertToInt(Console.ReadLine()!);

                // Translation: Of what base should the output be?
                Console.WriteLine("Jaká má být výsledná soustava?");
                Console.Write($"({number}){base_input} = (x)");     // e.g. (number)base = (x)base
                int base_output = SafelyConvertToInt(Console.ReadLine()!);

                // Horizontal rule that divides each base conversion.
                Console.WriteLine("---------------------------");

                // I limited the bases to be between 2 and 62, lack of possible digits and base 1 not impleted?
                if (base_input > 1 && base_output > 1 && base_input < 63 && base_output < 63)
                {

                    // Converts each digit into a value in base 10
                    int[] values = GetValues(number);
                    // Digits must be in-line with the base it is supposed to be in.
                    bool valid = ValidInput(values, base_input);
                    if (valid)
                    {
                        int inBase10 = InBase10(values, base_input);
                        string output = FinalBase(inBase10, base_output);
                        Console.WriteLine($"({number}){base_input} = ({output}){base_output}");
                    }
                    else
                    {
                        // Error message
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        // Translation: INPUT IS INVALID
                        Console.WriteLine("VSTUP JE NEPLATNY");
                        // Translation: TRY ONCEMORE
                        Console.WriteLine("ZKUSTE TO JESTE JEDNOU");
                        Console.ResetColor();
                        Console.WriteLine("---------------------------");
                    }
                }
                else
                {
                    // Error message
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    // Translation: THIS PROGRAM ONLY WORKS WITH NATURAL NUMBERS GREATER THAN ONE AND LESS THAN SIXTY-TWO
                    Console.WriteLine("TENTO PROGRAM PRACUJE POUZE S PRIROZENYMI CISLY VETSI JAK JEDNA A MÍŇ JAK ŠEDESÁT DVA");
                    // Translation: TRY ONCEMORE
                    Console.WriteLine("ZKUSTE TO JESTE JEDNOU");
                    Console.ResetColor();
                    Console.WriteLine("---------------------------");
                }
            }
        }

        // Checks if any of the digits has a greater value than the value of its base
        public bool ValidInput(int[] values, int base_input)
        {
            bool valid = true;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] >= base_input)
                {
                    valid = false;
                }
            }
            return valid;
        }

        // Converts digits into values
        public int[] GetValues(string number)
        {
            int[] values = new int[number.Length];
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };


            for (int i = 0; i < number.Length; i++)
            {
                if (Array.IndexOf(letters, number[i]) != -1)
                {
                    values[i] = 10 + Array.IndexOf(letters, number[i]);
                    continue;
                }

                values[i] = SafelyConvertToInt(number[i].ToString());
            }

            return values;
        }

        // Converts values of a number into base 10
        public int InBase10(int[] values, int base_input)
        {
            int power = 1;
            int sum = 0;

            for (int i = values.Length - 1; i >= 0; i--)
            {
                sum += values[i] * power;
                power = power * base_input;
            }

            return sum;
        }

        // Converts the base 10 output into the intended base output.
        public string FinalBase(int inBase10, int base_output)
        {
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
            int remainder = inBase10;
            int power = 0;
            int times = 1;
            string output = string.Empty;

            while (times*base_output <= inBase10)
            {
                times = times * base_output;
                power++;
            }

            for (int i = power; i >= 0; i--)
            {
                if (remainder / times > 9)
                {
                    output += letters[remainder / times - 10];
                }
                else
                {
                    output += remainder / times;
                }

                remainder = remainder % times;
                times = times / base_output;
            }

            return output;
        }
        public int SafelyConvertToInt(string s)
        {
            if (int.TryParse(s, out int result))
            {
                return result;
            }
            return 0;
        }
    }
}
