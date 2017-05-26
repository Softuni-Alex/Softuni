import java.util.Scanner;

public class _12MatrixOfPalindromes {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] input = scan.nextLine().split(" ");
        int rows = Integer.parseInt(input[0]);
        int cols = Integer.parseInt(input[1]);
        char sideLetter = 'a';

        for (int row = 0; row < rows; row++) {
            char middleLetter = sideLetter;
            for (int col = 0; col < cols; col++) {
                System.out.print("" + sideLetter + middleLetter + sideLetter + " ");
                middleLetter++;
            }
            sideLetter++;
            System.out.println();
        }
    }
}