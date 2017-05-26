import java.util.Scanner;

public class _10IndexofLetters {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        char[] alphabet = new char[26];

        for (char i = 'a';i <= 'z';  i++) {
            alphabet[i-'a'] = i;
        }

        String input = scan.nextLine().toLowerCase();

        for (int i = 0; i < input.length(); i++) {
            for (int j = 0; j < alphabet.length; j++) {
                if (input.charAt(i) == alphabet[j])
                {
                    System.out.printf("%s -> %d",input.charAt(i),j);
                }
            }
            System.out.println();
        }
    }
}