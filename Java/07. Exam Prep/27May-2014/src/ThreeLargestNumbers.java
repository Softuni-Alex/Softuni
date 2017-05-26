import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;

public class ThreeLargestNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int number = Integer.parseInt(scan.nextLine());

        BigDecimal largest;
        BigDecimal secondLargest;
        BigDecimal thirdLargest;

        List<BigDecimal> numbers = new ArrayList<>();
        for (int i = 0; i < number; i++) {
            String input = scan.nextLine();
            BigDecimal a = new BigDecimal(input);
            numbers.add(a);
        }

        Collections.sort(numbers);
        Collections.reverse(numbers);

        if (numbers.size() > 3) {
            for (int i = 0; i < 3; i++) {
                System.out.println(numbers.get(i));
            }
        } else {
            for (BigDecimal bigDecimal : numbers) {
                System.out.println(bigDecimal.toPlainString());
            }
        }
    }
}