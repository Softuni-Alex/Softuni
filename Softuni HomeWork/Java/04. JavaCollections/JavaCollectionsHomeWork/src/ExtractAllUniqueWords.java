import java.util.Scanner;
import java.util.Set;
import java.util.TreeSet;

public class ExtractAllUniqueWords {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String input = scan.nextLine().toLowerCase();
        String[] lines = input.split("\\P{Alpha}+");

        Set<String> wordCollector = new TreeSet<>();

        for (int i = 0; i < lines.length; i++) {
            wordCollector.add(lines[i]);
        }

        for (String word : wordCollector) {
            System.out.println(word + " ");
        }
    }
}