    import java.util.Scanner;

    public class _05IntegerToHexAndBinary {
        public static void main(String[] args) {
            Scanner scan = new Scanner(System.in);

            long number = Long.parseLong(scan.nextLine());

            String hexa = Long.toHexString(number).toUpperCase();
            String binary = Long.toBinaryString(number);

            System.out.println(hexa);
            System.out.println(binary);
        }
    }