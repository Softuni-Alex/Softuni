import java.util.Arrays;
import java.util.Scanner;

public class Problem01_FilterArray {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();
        String[] lines = input.split(" ");

        Arrays.stream(lines).filter(a -> a.length() > 3).forEach(a -> System.out.print(a + " "));
    }
}