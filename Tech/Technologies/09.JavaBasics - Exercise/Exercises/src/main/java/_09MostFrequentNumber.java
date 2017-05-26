import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;

public class _09MostFrequentNumber {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] text = sc.nextLine().toLowerCase().split(" ");

        LinkedHashMap<String, Integer> wordsCount = new LinkedHashMap<String,Integer>();

        for (String word : text) {
            Integer count = wordsCount.get(word);
            if (count == null) {
                count = 0;
            }
            wordsCount.put(word, count+1);
        }

        int maxCount = 0;
        for (Object value : wordsCount.values()) {
            if (maxCount < (Integer)value) {
                maxCount = (Integer)value;
            }
        }

        for (Map.Entry<String, Integer> entry : wordsCount.entrySet()) {
            if (entry.getValue() == maxCount ) {
                System.out.printf("%s",entry.getKey());
                break;
            }
        }
    }
}