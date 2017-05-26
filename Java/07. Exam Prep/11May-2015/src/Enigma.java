import java.util.Scanner;

public class Enigma {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int numberOfLines = Integer.parseInt(scan.nextLine());

        String[] lines = new String[numberOfLines];
        for (int i = 0; i < lines.length; i++) {
            lines[i] = scan.nextLine();
        }

        for (int i = 0; i < lines.length; i++) {
            String line = lines[i];
            String withoutWhitespacesAndNumbers = line.replaceAll("\\s*\\d*","");
            int length = withoutWhitespacesAndNumbers.length() / 2;

            for (int j = 0; j < line.length(); j++) {
                if (Character.isDigit(line.charAt(j))) {
                    System.out.print(line.charAt(j));
                }

                else if (line.charAt(j) == ' ') {
                    System.out.print(" ");
                }

                else {
                    int ascii = (int) line.charAt(j);
                    System.out.print((char) (ascii + length));
                }
            }

            System.out.println();
        }
    }
}