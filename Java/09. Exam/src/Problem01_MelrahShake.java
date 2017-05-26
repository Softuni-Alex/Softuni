import java.util.Scanner;

public class Problem01_MelrahShake {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String input = scan.nextLine();
        String pattern = scan.nextLine();

        boolean matched = false;

        for (int i = 0; i < input.length(); i++) {
            if (input.contains(pattern)) {
                matched = true;
                for (int j = input.length(); j < 0; j--) {

                }
            }
        }
    }
}


//
//if (input.contains(pattern)) {
//        matched = true;
//        if (matched) {
//        System.out.println("Shaked it.");
//        //    pattern = pattern.charAt(i).
//        }
//        input = input.replaceAll(pattern, "");
//        System.out.println(input);
//        }
//        else {
//
//        }