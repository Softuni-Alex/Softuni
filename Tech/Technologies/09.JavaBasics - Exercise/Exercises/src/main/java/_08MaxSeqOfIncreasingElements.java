import java.util.Scanner;

public class _08MaxSeqOfIncreasingElements {
        public static void main(String[] args) {
            Scanner scan = new Scanner(System.in);

            String input = scan.nextLine();
            String[] lines = input.split(" ");

            int largestSequence = 1;
            int maxSequence = -1;
            int startIndex = 0;

            int[] numbers = new int[lines.length];

            for (int i = 0; i < numbers.length; i++) {
                numbers[i] = Integer.parseInt(lines[i]);
            }


            for (int i = 1; i < lines.length; i++) {
                if (numbers[i] > (numbers[i - 1])) {
                    largestSequence++;
                    if (largestSequence > maxSequence) {
                        maxSequence = largestSequence;
                        startIndex = i - maxSequence + 1;
                    }
                } else {
                    largestSequence = 1;
                }
            }

            if (maxSequence < 0) {
                System.out.println(lines[0]);
            }

            for (int i = startIndex; i < maxSequence + startIndex; i++) {
                System.out.print(lines[i] + " ");
            }
        }
    }