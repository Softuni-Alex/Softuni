import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class MostFrequentWord {
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        String[] text = sc.nextLine().toLowerCase().split("\\W+");

        TreeMap<String, Integer> wordsCount = new TreeMap<>();

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
            if (entry.getValue() == maxCount) {
                System.out.printf("%s -> %d\n",entry.getKey(),entry.getValue());
            }
        }
    }
}