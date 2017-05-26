import java.util.Scanner;

public class CalculateNFactorial {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int number = scan.nextInt();
        System.out.println(calculateFactorial(number));
    }

    private static int calculateFactorial(int number) {
        if (number == 0 || number == 1) {
            return 1;
        } else {
            return calculateFactorial(number - 1) * number;
        }
    }
}