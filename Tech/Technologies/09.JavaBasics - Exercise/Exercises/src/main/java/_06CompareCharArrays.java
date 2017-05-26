import java.util.Scanner;

public class _06CompareCharArrays {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String first = scan.nextLine().replaceAll(" ","");
        String second = scan.nextLine().replaceAll(" ","");

        int smallerArray = Math.min(first.length(),second.length());
        boolean areEqual = false;

        for (int i = 0; i < smallerArray; i++) {
            if (first.charAt(i) == second.charAt(i)){
                continue;
            }
            else {
                if (first.charAt(i) < second.charAt(i)){
                    System.out.println(first);
                    System.out.println(second);
                }
                else {
                    System.out.println(second);
                    System.out.println(first);
                }
                areEqual = true;
                break;
            }
        }
        if (!areEqual){
            if (first.length() <= second.length()){
                System.out.println(first);
                System.out.println(second);
            }
            else {
                System.out.println(second);
                System.out.println(first);
            }
        }
    }
}