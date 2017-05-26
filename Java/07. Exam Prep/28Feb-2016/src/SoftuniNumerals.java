import java.math.BigInteger;
import java.util.Scanner;

public class SoftuniNumerals {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        System.out.println(new BigInteger(new BigInteger(scan.nextLine()
                .replace("aba", "1")
                .replace("bcc", "2")
                .replace("aa", "0")
                .replace("cdc", "4")
                .replace("cc", "3"), 5)
                .toString(10)));
    }
}

// static void Main()
//        {
//            string input = Console.ReadLine();
//            var numbers = new StringBuilder();
//            for (int i = 0; i < input.Length; i++)
//            {
//                try
//                {
//                    if ((input[i] == 'a') && (input[i + 1] == 'a'))
//                    {
//                        numbers.Append(0);
//                        i += 1;
//                    }
//                    else if ((input[i] == 'a') && (input[i + 1] == 'b'))
//                    {
//                        numbers.Append(1);
//                        i += 2;
//                    }
//                    else if ((input[i] == 'b') && (input[i + 1] == 'c'))
//                    {
//                        numbers.Append(2);
//                        i += 2;
//                    }
//                    else if ((input[i] == 'c') && (input[i + 1] == 'c'))
//                    {
//                        numbers.Append(3);
//                        i += 1;
//                    }
//                    else if ((input[i] == 'c') && (input[i + 1] == 'd'))
//                    {
//                        numbers.Append(4);
//                        i += 2;
//                    }
//                }
//                catch (IndexOutOfRangeException)
//                {
//                    break;
//                }
//            }
//
//            string number = numbers.ToString();
//            int currentIndex = number.Length - 1;
//            long result = 0;
//            for (long i = 0; i < number.Length; i++)
//            {
//                result += long.Parse(number[currentIndex].ToString()) * (long)Math.Pow(5, i);
//                currentIndex--;
//            }
//            Console.WriteLine(result);
//        }
//    }