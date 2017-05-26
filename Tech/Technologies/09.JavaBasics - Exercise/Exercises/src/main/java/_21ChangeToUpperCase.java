import java.util.Scanner;

public class _21ChangeToUpperCase {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String text = scan.nextLine();
        String modified = "";
        for (int i = 0; i < text.length(); i++) {
            String openTag = "<upcase>";
            String closeTag = "</upcase>";

            int indexOpen = text.indexOf(openTag, i);
            int indexClose = text.indexOf(closeTag, i);
            if (i == indexOpen) {
                if (indexOpen != -1 && indexClose != -1) {
                    for (int j = indexOpen + openTag.length(); j < indexClose; j++) {
                        modified += Character.toUpperCase(text.charAt(j));
                    }
                    i += indexClose - indexOpen + closeTag.length();
                }
            }
            if (i < text.length()) {
                modified += text.charAt(i);
            }
        }
        System.out.println(modified);
    }
}