import java.util.Arrays;
import java.util.Scanner;

public class Problem02_SortArrayWithStreamAPI {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();
        String[] line = input.split(" ");
        String commands = scan.nextLine();

        if (commands.equals("Ascending")) {
            Arrays.stream(line).sorted((a, b) -> a.compareTo(b)).forEach(a -> System.out.print(a + " "));
        }
        if (commands.equals("Descending")) {
            Arrays.stream(line).sorted((a, b) -> b.compareTo(a)).forEach(a -> System.out.print(a + " "));
        }
    }
}