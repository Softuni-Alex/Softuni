import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem01_ExtractEmails {

    public static void main(String[] args) {
        //Input
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();

        //Logic
        String pattern = "([a-z.-_\\d]+)@([a-z]+).([a-z]+)(\\.[a-z-]+)+";
        Pattern emailPattern = Pattern.compile(pattern);
        Matcher match = emailPattern.matcher(input);

        //Output
        while (match.find()) {
            System.out.println(match.group());
        }
    }
}