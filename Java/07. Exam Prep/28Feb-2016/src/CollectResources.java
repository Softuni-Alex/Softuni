import java.util.ArrayList;
import java.util.Collections;
import java.util.Scanner;

public class CollectResources {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] inputResources = scan.nextLine().split(" ");
        int numberOfPaths = Integer.parseInt(scan.nextLine());
        ArrayList<Integer> quantities = new ArrayList<>();

        int sum = 0;

        for (int i = 0; i < numberOfPaths; i++) {
            String[] tokens = scan.nextLine().split(" ");
            int startIndex = Integer.parseInt(tokens[0]);
            int step = Integer.parseInt(tokens[1]);
            String[] currentResource = inputResources.clone();

            for (int j = startIndex; true; j = (j + step) % currentResource.length) {
                String[] resource = currentResource[j].split("_");
                if (resource[0].contains("@")) {
                    break;
                }

                if (resource[0].equals("wood") || resource[0].equals("gold") || resource[0].equals("stone") || resource[0].equals("food")) {
                    if (resource.length < 2) {
                        currentResource[j] = "@" + currentResource[j];
                        sum += 1;
                    } else {
                        currentResource[j] = "@" + currentResource[j];
                        sum += Integer.parseInt(resource[1]);
                    }
                }
            }
            quantities.add(sum);
            sum = 0;
        }
        System.out.println(Collections.max(quantities));
    }
}