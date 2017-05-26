import java.util.Scanner;

public class Problem01_DozenEggs {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int eggs = 0;
        int dozens = 0;

        for (int i = 0; i < 7; i++) {
            String[] input = scan.nextLine().split(" ");

            int count = Integer.parseInt(input[0]);
            String measure = input[1];

            switch (measure) {
                case "eggs":
                    eggs += count;
                    break;
                case "dozens":
                    eggs += (count * 12);
                    break;
            }
        }
        dozens = eggs/12;
        eggs = eggs % 12;
        System.out.printf("%d dozens + %d eggs",dozens,eggs);
    }
}