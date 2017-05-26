import java.util.LinkedHashMap;
import java.util.Scanner;

public class _22PhoneBook {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String line = scan.nextLine();
        LinkedHashMap<String, String> phonebook = new LinkedHashMap<String,String>();

        while (!line.equals("END")) {
            String[] tokens = line.split(" ");

            switch (tokens[0]) {
                case "A":
                    phonebook.put(tokens[1], tokens[2]);
                    break;

                case "S":
                    if (phonebook.containsKey(tokens[1])) {
                        System.out.printf("%s -> %s\n", tokens[1], phonebook.get(tokens[1]));
                    } else {
                        System.out.printf("Contact %s does not exist.\n", tokens[1]);
                    }
                    break;
            }
            line = scan.nextLine();
        }
    }
}