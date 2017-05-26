import java.util.Scanner;

public class Problem02_AddingAngles {
    public static void main(String[] args) {

        Scanner str = new Scanner(System.in);
        int n = Integer.parseInt(str.nextLine());
        int[] angles = new int[n];
        for (int i = 0; i < angles.length; i++) {
            angles[i] = str.nextInt();
        }

        int value = 0;

        for (int i = 0; i < angles.length; i++) {
            for (int j = i + 1; j < angles.length; j++) {
                for (int k = j + 1; k < angles.length; k++) {
                    int a = angles[i];
                    int b = angles[j];
                    int c = angles[k];
                    int sum = a + b + c;
                    if (sum % 360 == 0) {
                        System.out.printf("%d + %d + %d = %d degrees\n",
                                a, b, c, sum);
                        value++;
                    }
                }
            }
        }
        if (value == 0) {
            System.out.println("No");
        }
    }
}