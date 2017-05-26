import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem06_StartsAndEndsWithCapitalLetter {
    public static void main(String[] args) {
        //Input
        Scanner scan = new Scanner(System.in);
        String words = scan.nextLine();
        String regex = "\\b[A-Z][a-zA-Z]*[A-Z]\\b";

        //Logic
        Pattern pattern = Pattern.compile(regex);
        Matcher matcher = pattern.matcher(words);

        //Logic
        while (matcher.find()) {
            System.out.print(matcher.group() + " ");
        }
    }
}