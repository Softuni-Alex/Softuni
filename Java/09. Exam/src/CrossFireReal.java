import java.util.Scanner;

public class CrossFireReal {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] dimentions = scan.nextLine().split(" ");
        int rows = Integer.parseInt(dimentions[0]);
        int cols = Integer.parseInt(dimentions[1]);

        int[][] matrix = new int[rows][cols];
    }
}