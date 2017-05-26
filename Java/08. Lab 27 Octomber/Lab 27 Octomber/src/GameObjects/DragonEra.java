package GameObjects;

import java.util.ArrayList;
import java.util.List;
import java.util.Scanner;

public class DragonEra {

    public static int dragonsCount = 0;

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int numberOfDragons = Integer.parseInt(scan.nextLine());
        List<Dragon> dragons = new ArrayList<>();

        for (int i = 1; i <= numberOfDragons; i++) {
            Dragon dragon = new Dragon("Dragon_" + i, 0);
            int numberOfEggs = Integer.parseInt(scan.nextLine());
            for (int eggCount = 0; eggCount < numberOfEggs; eggCount++) {
                Egg egg = new Egg(0, dragon);
                dragon.lay();
            }

            dragons.add(dragon);
        }
        dragonsCount = numberOfDragons + 1;

        int years = Integer.parseInt(scan.nextLine());

        for (int year = 1; year <= years; year++) {
            String yearType = scan.nextLine();
            YearType yearFactor = YearType.valueOf(yearType);

            for (Dragon dragon : dragons) {
                dragon.age();
                dragon.lay();

                for (Egg egg : dragon.getEggs()) {
                    egg.setYearFactor(yearFactor);
                    egg.age();
                    egg.hatch();
                }
            }
        }
    }

    public static void passAge(Dragon dragon, YearType factor) {
        dragon.age();
        dragon.lay();
        if (dragon.isAlive()) {
            for (Egg egg : dragon.getEggs()) {
                egg.setYearFactor(factor);

                egg.age();
                egg.hatch();
            }
        }

        for (Dragon child : dragon.getChildren()) {
            passAge(child, factor);
        }
    }

    public void printRecursively(Dragon dragon) {
        dragon.getClass().getName();
        System.out.println("  ");
        dragon.getChildren().getClass().getName();
        printRecursively(dragon);
    }

}