import java.util.Scanner;

public class Problem03_CountSpecifiedWord {
    public static void main(String[] args) {
        //Input
        Scanner scan = new Scanner(System.in);
        String text = scan.nextLine().toLowerCase();
        String targetWord = scan.nextLine().toLowerCase();
        String[] textLines = text.split("\\P{Alpha}+");
        int counter = 0;

        //Logic
        for (int i = 0; i < textLines.length; i++) {
            if (targetWord.equals(textLines[i])) {
                counter++;
            }
        }

        //Output
        System.out.println(counter);
    }
}