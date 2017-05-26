import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Scanner;

public class _17ReverseString {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String input = scan.nextLine();

        //first way
        //for (int i = input.length() - 1; i >= 0; i--) {
        //  System.out.print(input.charAt(i));
        //}


        //second way
        List<Character> test = new ArrayList<Character>();
        for (int i = 0; i < input.length(); i++) {
            test.add(input.charAt(i));
        }

        Collections.reverse(test);

        for (char one : test) {
            System.out.print(one);
        }
    }
}