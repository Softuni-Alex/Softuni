import java.util.Scanner;

public class _01VarInHexFormat {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String number = scan.nextLine();

        int result = Integer.parseInt(number,16);

        System.out.println(result);
    }
}
