import java.util.Scanner;

public class Crossfire {
    public static void main(String args[]) {
        Scanner scan = new Scanner(System.in);
        String[] dimensions = scan.nextLine().split(" ");
        String snake = scan.nextLine();
        String[] shotParameters = scan.nextLine().split("");

        int numberOfRows = Integer.parseInt(dimensions[0]);
        int numberOfColumns = Integer.parseInt(dimensions[1]);

        int impactRow = Integer.parseInt(shotParameters[0]);
        int impactCol = Integer.parseInt(shotParameters[1]);
        int shotRadius = Integer.parseInt(shotParameters[2]);

        char[][] matrix = new char[numberOfRows][];

        FillMatrix(snake, matrix, numberOfColumns);

        FireAShot(matrix, impactRow, impactCol, shotRadius);

        PrintMatrix(matrix);
    }

    private static void FillMatrix(String snake, char[][] matrix, int matrixWidth) {
        for (int i = 0; i < matrix.length; i++) {
            matrix[i] = new char[matrixWidth];
        }

        boolean isMovingLeft = true;
        int currentSymbolIndex = 0;

        for (int row = matrix.length - 1; row >= 0; row--) {
            int col = isMovingLeft ? matrixWidth - 1 : 0;
            int colUpdate = isMovingLeft ? -1 : 1;

            while (0 <= col && col < matrixWidth) {
                if (currentSymbolIndex >= snake.length()) {
                    currentSymbolIndex = 0;
                }

                matrix[row][col] = snake.charAt(currentSymbolIndex);

                currentSymbolIndex++;
                col += colUpdate;
            }

            isMovingLeft = !isMovingLeft;
        }
    }

    private static void FireAShot(char[][] matrix, int impactRow, int impactCol, int shotRadius) {
        int matrixWidth = matrix[0].length;

        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrixWidth; col++) {
                if (IsInsideRadius(row, col, impactRow, impactCol, shotRadius)) {
                    matrix[row][col] = ' ';
                }
            }
        }
    }

    private static boolean IsInsideRadius(int checkRow, int checkCol, int impactRow, int impactCol, int shotRadius) {
        int deltaRow = checkRow - impactRow;
        int deltaCol = checkCol - impactCol;

        boolean isInRadius = deltaRow * deltaRow + deltaCol * deltaCol <= shotRadius * shotRadius;

        return isInRadius;
    }

    private static void PrintMatrix(char[][] matrix) {
        int matrixWidth = matrix[0].length;

        for (int row = 0; row < matrix.length; row++) {
            for (int col = 0; col < matrixWidth; col++) {
                System.out.println(matrix[row][col]);
            }

            System.out.println();
        }
    }
}
