import java.util.Random;
import java.util.Scanner;

public class _25AdvertisementMessage {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] phrases = new String[]
                {
                        "Excellent product",
                        "Such a great product",
                        "I always use that product",
                        "Best product of its category"
                };

        String[] events = new String[]
                {
                        "Now I feel good.",
                        "I have succeeded the change.",
                        "That makes miracles.",
                        "I cannot believe but now I feel awesome",
                        "Try it yourself, I am very satisfied"
                };

        String[] authors = new String[]
                {
                        "Diana",
                        "Petya",
                        "Stella",
                        "Elena",
                        "Katya",
                        "Iva",
                        "Annie",
                        "Misha"
                };

        String[] cities = new String[]
                {
                        "Burgas",
                        "Sofia",
                        "Plovdiv",
                        "Varna",
                        "Ruse"
                };

        int numberOfMessages = Integer.parseInt(scan.nextLine());

        Random randomGenerator = new Random();

        for (int i = 0; i < numberOfMessages; i++) {
            int phraseIndex = randomGenerator.nextInt(phrases.length);
            int eventIndex = randomGenerator.nextInt(events.length);
            int authorIndex = randomGenerator.nextInt(authors.length);
            int cityIndex = randomGenerator.nextInt(cities.length);

            System.out.printf("%s %s %s - %s", phrases[phraseIndex], events[eventIndex], authors[authorIndex], cities[cityIndex]);
        }
    }
}