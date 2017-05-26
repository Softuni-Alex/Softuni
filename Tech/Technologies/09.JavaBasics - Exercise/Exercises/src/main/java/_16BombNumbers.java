import java.util.ArrayList;
import java.util.Scanner;

public class _16BombNumbers {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] line = scan.nextLine().split(" ");
        ArrayList<Integer> sequence = new ArrayList<Integer>();

        for (int i = 0; i < line.length; i++) {
            sequence.add(Integer.parseInt(line[i]));
        }

        String[] omg = scan.nextLine().split(" ");
        int[] input = new int[omg.length];
        for (int i = 0; i < omg.length; i++) {
            input[i] = Integer.parseInt(omg[i]);
        }

        int number = input[0];
        int power = input[1];

        for (int i = 0; i < sequence.size(); i++) {
            if (sequence.get(i) == number) {
                int leftIndex = Math.max(i - power, 0);
                int rightIndex = Math.min(i + power, sequence.size() - 1);

                int lenght = rightIndex - leftIndex;

                removeRange(sequence, leftIndex, rightIndex);
                i = 0;
            }
        }
        long sum = 0;
        for (int i = 0; i < sequence.size(); i++) {
            sum += sequence.get(i);
        }
        System.out.println(sum);
    }

    public static void removeRange(ArrayList<Integer> arr, int from, int to) {
        for (int i = from; i <= to; i++) {
            arr.remove(from);
        }
    }
}