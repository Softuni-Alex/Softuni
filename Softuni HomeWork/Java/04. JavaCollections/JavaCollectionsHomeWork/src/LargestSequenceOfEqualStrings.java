import java.util.Scanner;

public class LargestSequenceOfEqualStrings {
    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        String input = scan.nextLine();
        String[] lines = input.split(" ");

        int largestSequence = 1;
        int maxSequence = -1;
        int startIndex = 0;

        for (int i = 1; i < lines.length; i++) {
            if (lines[i].equals(lines[i - 1])) {
                largestSequence++;
                if (largestSequence > maxSequence) {
                    maxSequence = largestSequence;
                    startIndex = i - maxSequence + 1;
                }
            } else {
                largestSequence = 1;
            }
        }

        for (int i = startIndex; i < maxSequence + startIndex; i++) {
            System.out.println(lines[i] + " ");
        }
    }
}