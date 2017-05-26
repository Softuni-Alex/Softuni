import java.util.Scanner;

public class Problem02_CountSubstringOccurrences {
    public static void main(String[] args) {
        //Input
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine().toLowerCase();
        String searchedWord = scan.nextLine().toLowerCase();
        int count = 0;

        //Logic
        for (int i = 0; i < text.length() - searchedWord.length(); i++) {
            if (searchedWord.equals(text.substring(i, searchedWord.length() + i))) {
                count++;
            }
        }

        //Input
        System.out.println(count);
    }
}