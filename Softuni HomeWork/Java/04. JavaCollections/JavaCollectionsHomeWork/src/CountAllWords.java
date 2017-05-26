import java.util.Scanner;

public class CountAllWords {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String sentence = scan.nextLine();
        String[] splittedSentence = sentence.split("\\P{Alpha}+");

        System.out.println(splittedSentence.length);
    }
}