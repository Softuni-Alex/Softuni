import java.util.Scanner;

public class Problem01_PalatkaConf {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int peoples = Integer.parseInt(scan.nextLine());
        int lines = Integer.parseInt(scan.nextLine());

        int availableBeds = 0;
        int availableMeals = 0;

        for (int i = 0; i < lines; i++) {
            String[] input = scan.nextLine().split(" ");
            String object = input[0];
            int value = Integer.parseInt(input[1]);
            String type = input[2];

            switch (object) {
                case "tents":
                    if (type.equals("normal")) {
                        availableBeds += value * 2;
                    }
                    if (type.equals("firstClass")) {
                        availableBeds += value * 3;
                    }
                    break;
                case "rooms":
                    if (type.equals("single")) {
                        availableBeds += value;
                    }
                    if (type.equals("double")) {
                        availableBeds += value * 2;
                    }
                    if (type.equals("triple")) {
                        availableBeds += value * 3;
                    }
                    break;
                case "food":
                    if (type.equals("musaka")) {
                        availableMeals += value * 2;
                    }
                    break;
            }
        }

        if (availableBeds >= peoples) {
            System.out.printf("Everyone is happy and sleeping well. Beds left: %d", availableBeds - peoples);
        } else {
            System.out.printf("Some people are freezing cold. Beds needed: %d", peoples - availableBeds);
        }
        System.out.println();
        if (availableMeals >= peoples) {
            System.out.printf("Nobody left hungry. Meals left: %d", availableMeals - peoples);
        } else {
            System.out.printf("People are starving. Meals needed: %d", peoples - availableMeals);
        }
    }
}