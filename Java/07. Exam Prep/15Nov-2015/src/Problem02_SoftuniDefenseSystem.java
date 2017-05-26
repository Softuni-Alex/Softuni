import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem02_SoftuniDefenseSystem {
    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine();

        String regex = "([A-Z][a-z]+).*?([A-Z][a-z]*[A-Z]).*?(\\d+)L";
        Pattern pattern = Pattern.compile(regex);
        int liters = 0;

        while (!input.equals("OK KoftiShans")) {
            Matcher match = pattern.matcher(input);
            while (match.find()) {
                String guest = match.group(1);
                String alcohol = match.group(2).toLowerCase();
                int value = Integer.parseInt(match.group(3));

                System.out.printf("%s brought %d liters of %s!\n", guest, value, alcohol);
                liters += value;
            }
            input = scan.nextLine();
        }
        System.out.printf("%.3f softuni liters", liters / 1000.0);
    }
}