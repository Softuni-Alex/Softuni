import java.util.Arrays;
import java.util.Scanner;

public class SortArrayOfNumbers {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int number = Integer.parseInt(scan.nextLine());

        int[] numbers = new int[number];

        for (int i = 0; i < number; i++) {
            numbers[i] = scan.nextInt();
        }

        Arrays.sort(numbers);

        for (Integer num : numbers) {
            System.out.println(num);
        }
    }
}