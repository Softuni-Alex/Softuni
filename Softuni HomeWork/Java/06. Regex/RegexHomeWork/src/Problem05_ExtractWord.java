import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem05_ExtractWord {
    public static void main(String[] args) {
        //Input
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine();
        String regex = "([A-Za-z]{2,})";

        //Logic
        Pattern pattern = Pattern.compile(regex);
        Matcher matcher = pattern.matcher(text);

        //Output
        while (matcher.find()) {
            System.out.print(matcher.group() + " ");
        }
    }
}