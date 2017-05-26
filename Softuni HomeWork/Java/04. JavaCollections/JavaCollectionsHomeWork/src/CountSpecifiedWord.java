import java.util.Scanner;

public class CountSpecifiedWord {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine().toLowerCase();
        String[] splittedInput = input.split("\\P{Alpha}+");
        String targetWord = scan.nextLine().toLowerCase();
        int counter = 0;

        for (int i = 0; i < splittedInput.length; i++) {
            if (targetWord.equals(splittedInput[i])) {
                counter++;
            }
        }
        System.out.println(counter);
    }
}