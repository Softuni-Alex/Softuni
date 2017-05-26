import java.util.Scanner;

public class _04VowelOrDigit {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String givenThing = scan.nextLine();

        switch (givenThing){
            case "a":
            case "e":
            case "i":
            case "o":
            case "u":
                System.out.println("vowel");
                break;
            case "1":
            case "2":
            case "3":
            case "4":
            case "5":
            case "6":
            case "7":
            case "8":
            case "9":
            case "0":
                System.out.println("digit");
                break;
                default:
                    System.out.println("other");
                    break;
        }
    }
}