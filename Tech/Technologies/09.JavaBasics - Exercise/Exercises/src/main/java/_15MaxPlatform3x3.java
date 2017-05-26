import java.util.Scanner;

public class _15MaxPlatform3x3 {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] lines = scan.nextLine().split(" ");
        int[] dimentions = new int[lines.length];
        for (int i = 0; i < lines.length; i++) {
            dimentions[i] = Integer.parseInt(lines[i]);
        }

        int rows = dimentions[0];
        int cols = dimentions[1];

        int[][] matrix = new int[rows][];

        for (int row = 0; row < rows; row++) {
            String[] smth = scan.nextLine().split(" ");
            int[] newOnew = new int[smth.length];
            for (int i = 0; i < smth.length; i++) {
                newOnew[i] = Integer.parseInt(smth[i]);
            }
            matrix[row] = newOnew;
        }

        long maxSum = Long.MIN_VALUE;
        int bestRow = 0;
        int bestCol = 0;

        for (int row = 0; row < rows - 2; row++) {
            for (int col = 0; col < cols - 2; col++) {
                long sum = (long) matrix[row][col] + matrix[row][col + 1] + matrix[row][col + 2] +
                        matrix[row + 1][col] + matrix[row + 1][col + 1] + matrix[row + 1][col + 2] +
                        matrix[row + 2][col] + matrix[row + 2][col + 1] + matrix[row + 2][col + 2];

                if (sum > maxSum) {
                    maxSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        System.out.println(maxSum);

        for (int row = bestRow; row < bestRow + 3; row++) {
            for (int col = bestCol; col < bestCol + 3; col++) {
                System.out.print(matrix[row][col] + " ");
            }
            System.out.println();
        }
    }
}