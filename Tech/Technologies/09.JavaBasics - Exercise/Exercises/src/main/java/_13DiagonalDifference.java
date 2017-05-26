import java.util.Scanner;

public class _13DiagonalDifference {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int size = Integer.parseInt(scan.nextLine());

        int[][] matrix = new int[size][size];

        for (int row = 0; row < size; row++) {
            String[] line = scan.nextLine().split(" ");
            int[] newLine = new int[line.length];

            for (int i = 0; i < line.length; i++) {
                newLine[i] = Integer.parseInt(line[i]);
            }

            for (int col = 0; col < size; col++) {
                matrix[row][col] = newLine[col];
            }
        }

        int primaryDiagonalSum = 0;
        int secondaryDiagonalSUm = 0;

        for (int row = 0; row < size; row++) {
            for (int col = 0; col < size; col++) {
                if (row == col) {
                    primaryDiagonalSum += matrix[row][col];
                }

                if (col == size - 1 - row) {
                    secondaryDiagonalSUm += matrix[row][col];
                }
            }
        }

        int result = Math.abs(primaryDiagonalSum - secondaryDiagonalSUm);
        System.out.println(result);
    }
}