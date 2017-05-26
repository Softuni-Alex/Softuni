import java.util.Scanner;

public class _11EqualSums {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] numbers= scan.nextLine().split(" ");
        int[] newNumbers = new int[numbers.length];
        for (int i = 0; i < numbers.length; i++) {
            newNumbers[i] = Integer.parseInt(numbers[i]);
        }

        boolean isFound = false;

        for (int currentElement = 0; currentElement < newNumbers.length; currentElement++)
        {
            int sumLeft = 0;
            int sumRight = 0;

            for (int i = currentElement + 1; i < newNumbers.length; i++)
            {
                sumRight += newNumbers[i];
            }
            for (int i = 0; i < currentElement; i++)
            {
                sumLeft += newNumbers[i];
            }
            if (sumRight == sumLeft)
            {
                System.out.println(currentElement);
                isFound = true;
                break;
            }
        }
        if (!isFound)
        {
            System.out.println("no");
        }
    }
}