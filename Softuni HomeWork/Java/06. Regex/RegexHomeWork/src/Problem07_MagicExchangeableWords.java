import java.util.HashMap;
import java.util.Scanner;

public class Problem07_MagicExchangeableWords {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] line = scan.nextLine().split(" ");
        String first = line[0];
        String second = line[1];

        System.out.println(exchangeWords(first, second));

    }

    private static boolean exchangeWords(String first, String second) {
        boolean areExchangeable = true;
        HashMap<Character, Character> words = new HashMap<>();

        if (first.length() == second.length()) {
            for (int i = 0; i < first.length(); i++) {
                char firstChar = first.charAt(i);
                char secondChar = second.charAt(i);
                if (!words.containsKey(firstChar)) {
                    words.put(firstChar, secondChar);
                }
                if (!words.containsValue(secondChar)) {
                    areExchangeable = false;
                }
            }
        } else {
            areExchangeable = false;
        }
        return areExchangeable;
    }
}