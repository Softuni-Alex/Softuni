import java.util.Scanner;

public class RoyalFlush {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int lines = Integer.parseInt(scan.nextLine());
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < lines; i++) {
            String output = scan.nextLine();
            sb.append(output);
        }

        String output = sb.toString().replace("J", "11").replace("Q", "12").replace("K", "13").replace("A", "14");
    }
}