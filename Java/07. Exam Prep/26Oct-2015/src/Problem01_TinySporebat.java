import java.util.Scanner;

public class Problem01_TinySporebat {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        int health = 5800;
        int sporeCost = 30;
        long totalGlowcaps = 0;

        String line = scan.nextLine();

        while (!line.equals("Sporeggar")) {
            int glowcaps = line.charAt(line.length() - 1)- '0';

            char[] enemies = line.substring(0, line.length() - 1).toCharArray();
            for (char enemy : enemies) {
                if (enemy != 'L') {
                    health -= enemy;
                    if (health <= 0) {
                        System.out.println("Died. Glowcaps: " + totalGlowcaps);
                        return;
                    }
                } else {
                    health += 200;
                }
            }
            totalGlowcaps += glowcaps;
            line = scan.nextLine();
        }
        System.out.println("Health left: " + health);

        if (totalGlowcaps >= sporeCost) {
            System.out.println("Bought the sporebat. Glowcaps left: " + (totalGlowcaps - sporeCost));
        } else {
            System.out.printf("Safe in Sporeggar, but another %d Glowcaps needed.", (sporeCost - totalGlowcaps));
        }
    }
}