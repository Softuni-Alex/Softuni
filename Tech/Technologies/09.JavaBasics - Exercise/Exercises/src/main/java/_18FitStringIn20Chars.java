import java.util.Scanner;

public class _18FitStringIn20Chars {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();

        if (input.length() < 20) {
            input = pad(input, 20, '*');
        }
        if (input.length() > 20) {
            input = input.substring(0, 20);
        }
        System.out.println(input);
    }

    public static String pad(String str, int size, char padChar) {
        StringBuffer padded = new StringBuffer(str);
        while (padded.length() < size) {
            padded.append(padChar);
        }
        return padded.toString();
    }
}