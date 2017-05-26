import java.util.Scanner;

public class _14_2x2SquaresinMatrix {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] line = scan.nextLine().split(" ");

        int rows = Integer.parseInt(line[0]);
        int cols = Integer.parseInt(line[1]);

        String[][] matrix = new String[rows][cols];

        for (int row = 0; row < rows; row++) {
            matrix[row] = scan.nextLine().split(" ");
        }

        long count = 0;


        for (int row = 0; row < rows - 1; row++) {
            for (int col = 0; col < cols - 1; col++) {
                String first = matrix[row][col];
                String second = matrix[row][col + 1];
                String third = matrix[row + 1][col];
                String fourth = matrix[row + 1][col + 1];
                if (matrix[row][col].equals(matrix[row][col + 1]) &&
                        matrix[row][col].equals(matrix[row + 1][col]) &&
                        matrix[row][col].equals(matrix[row + 1][col + 1])) {
                    count++;
                }
            }
        }
        System.out.println(count);
    }
}