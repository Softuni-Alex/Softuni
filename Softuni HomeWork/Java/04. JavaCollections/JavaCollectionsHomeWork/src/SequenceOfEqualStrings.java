import java.util.Scanner;

public class SequenceOfEqualStrings {
    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        String input = scan.nextLine();
        String[] lines = input.split(" ");

        System.out.print(lines[0]);

        for (int i = 1; i < lines.length; i++) {
            if (lines[i].equals(lines[i-1])){
                System.out.print(" " + lines[i]);
            }
            else{
                System.out.println();
                System.out.print(lines[i]);
            }
        }
    }
}