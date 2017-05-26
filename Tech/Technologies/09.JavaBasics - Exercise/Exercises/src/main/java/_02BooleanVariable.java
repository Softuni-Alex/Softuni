import java.util.Scanner;

public class _02BooleanVariable {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String str = scan.nextLine();

        boolean parsed = Boolean.parseBoolean(str);

        if (parsed == true){
            System.out.println("Yes");
        }
        else {
            System.out.println("No");
        }
    }
}