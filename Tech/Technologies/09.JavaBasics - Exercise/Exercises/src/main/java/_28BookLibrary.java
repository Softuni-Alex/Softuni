import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;

public class _28BookLibrary {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        TreeMap<String, Double> library = new TreeMap<>();

        int lines = Integer.parseInt(reader.readLine());

        for (int i = 0; i < lines; i++) {
            String[] tokens = reader.readLine().split(" ");

            if (!library.containsKey(tokens[1])) {
                library.put(tokens[1], Double.parseDouble(tokens[5]));
            } else {
                Double oldValue = library.get(tokens[1]);
                library.put(tokens[1], oldValue + Double.parseDouble(tokens[5]));
            }
        }

        library.entrySet().stream()
                .sorted((k1, k2) -> -k1.getValue().compareTo(k2.getValue()))
                .forEach(k -> System.out.printf("%s -> %.2f\n", k.getKey(), k.getValue()));
    }
}