import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collectors;

public class CombineListOfLetters {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        List<Character> firstList = Arrays.stream(scan.nextLine().split(" ")).map(ch -> ch.charAt(0)).collect(Collectors.toList());
        List<Character> secondList = Arrays.stream(scan.nextLine().split(" ")).map(ch -> ch.charAt(0)).collect(Collectors.toList());
        List<Character> result = new ArrayList<>();

        for (int i = 0; i < secondList.size(); i++) {
            if (!firstList.contains(secondList.get(i))) {
                result.add(secondList.get(i));
            }
        }
        firstList.addAll(result);
        for (Character character : firstList) {
            System.out.print(character + " ");
        }
    }
}