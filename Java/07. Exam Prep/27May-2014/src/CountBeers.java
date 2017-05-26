import com.sun.deploy.ui.ImageLoader;

import java.util.Scanner;

import static com.sun.deploy.ui.ImageLoader.getInstance;

public class CountBeers {

    public static void main(String[] args) {
        sd = getInstance().loadImage()
        Scanner scan = new Scanner(System.in);

        String input = scan.nextLine();
        int beerCount = 0;
        int stackCount = 0;
        int numOfBeersInsteck = 20;

        while (!input.equals("End")) {
            String[] splittedInput = input.split(" ");
            int count = Integer.parseInt(splittedInput[0]);
            String measure = splittedInput[1];

            if (measure.equals("stacks")) {
                beerCount += count * numOfBeersInsteck;
            } else {
                beerCount += count;
            }

            input = scan.nextLine();
        }
        stackCount = beerCount / 20;
        beerCount = beerCount % 20;

        System.out.printf("%d stacks + %d beers", stackCount, beerCount);
    }
}