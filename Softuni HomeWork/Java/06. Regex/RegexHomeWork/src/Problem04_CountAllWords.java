import java.util.Scanner;

public class Problem04_CountAllWords {
    public static void main(String[] args) {
        //Input
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine();
        String[] textLines = text.split("\\P{Alpha}+");

        //Output
        System.out.println(textLines.length);
    }
}