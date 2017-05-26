import java.util.Scanner;

public class Lab {
    public static void main(String[] args) {
            symmetricNumbers();
    }

    public static void sumTwoNumbers() {
        Scanner scan = new Scanner(System.in);

        double a = Double.parseDouble(scan.nextLine());
        double b = Double.parseDouble(scan.nextLine());

        double sum = a + b;

        System.out.println(sum);
    }

    public static void sumNIntegers() {
        Scanner scan = new Scanner(System.in);

        long number = Long.parseLong(scan.nextLine());

        long n = 0;
        long sum = 0;
        for (int i = 0; i < number; i++) {
            n = Long.parseLong(scan.nextLine());
            sum += n;
        }
        System.out.println(sum);
    }

    public static void symmetricNumbers() {
        Scanner scan = new Scanner(System.in);
        int n = scan.nextInt();
        for (int i = 1; i <= n; i++)
            if (isSymmetric("" + i))
                System.out.print(i + " ");
    }

    static boolean isSymmetric(String str) {
        for (int i = 0; i < str.length() / 2; i++)
            if (str.charAt(i) != str.charAt(str.length() - i - 1))
                return false;
        return true;
    }

    public static void threeIntegersSum() {
        Scanner scan = new Scanner(System.in);
        int num1 = scan.nextInt();
        int num2 = scan.nextInt();
        int num3 = scan.nextInt();
        if (!checkThreeIntegers(num1, num2, num3) &&
                !checkThreeIntegers(num3, num1, num2) &&
                !checkThreeIntegers(num2, num3, num1))
            System.out.println("No");
    }

    static boolean checkThreeIntegers(
            int num1, int num2, int sum) {
        if (num1 + num2 != sum)
            return false;
        if (num1 <= num2)
            System.out.printf("%d + %d = %d\n", num1, num2, sum);
        else
            System.out.printf("%d + %d = %d\n", num2, num1, sum);
        return true;
    }


    public static void expression() {
        double val = (30 + 21) * 1 / 2.0 * (35 - 12 - 1 / 2.0);
        double valSquare = val * val;
        System.out.println(valSquare);
    }
}