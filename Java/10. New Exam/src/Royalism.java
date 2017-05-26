import java.util.ArrayList;
import java.util.Scanner;

public class Royalism {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        //INPUT
        String[] tokkens = scan.nextLine().split(" ");
        int totalSum = 0;

        ArrayList<String> royalistNames = new ArrayList<>();
        ArrayList<String> nonRoyalistNames = new ArrayList<>();

        //LOGIC
        for (int i = 0; i < tokkens.length; i++) {
            String currentString = tokkens[i];
            int currentSum = 0;
            for (int j = 0; j < currentString.length(); j++) {
                currentSum += currentString.charAt(j);

                while (currentSum >= 26) {
                    currentSum -= 26;
                }

                totalSum = currentSum;
            }
            if (totalSum == 18) {
                royalistNames.add(currentString);
            } else {
                nonRoyalistNames.add(currentString);
            }
        }

        //OUTPUT
        if (royalistNames.size() >= 0) {
            if (royalistNames.size() >= nonRoyalistNames.size()) {
                System.out.printf("Royalists - %d", royalistNames.size());
                System.out.println();
                for (String royalistName : royalistNames) {
                    System.out.println(royalistName);
                }
                System.out.println("All hail Royal!");
            }
            if (royalistNames.size() < nonRoyalistNames.size()) {
                for (String nonRoyalistName : nonRoyalistNames) {
                    System.out.println(nonRoyalistName);
                }
                System.out.println("Royalism, Declined!");
            }
        }
    }
}