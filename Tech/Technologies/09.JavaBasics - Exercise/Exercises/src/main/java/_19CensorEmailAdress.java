import java.util.Scanner;

public class _19CensorEmailAdress {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] email = scan.nextLine().split("@");
        String text = scan.nextLine();

        String username = email[0];
        String domain = "@" + email[1];

        String whole = username + domain;

        int userLen = username.length();
        String ne = "";

        for (int i = 0; i < userLen; i++) {
            ne = ne + "*";
        }

        String replacement = ne + domain;

        text = text.replace(whole, replacement);

        System.out.println(text);
    }
}