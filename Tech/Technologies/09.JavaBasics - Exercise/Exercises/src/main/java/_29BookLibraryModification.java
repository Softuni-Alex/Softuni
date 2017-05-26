import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.*;

public class _29BookLibraryModification {
    private static DateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");

    public static void main(String[] args) throws Exception {
        BufferedReader scan = new BufferedReader(new InputStreamReader(System.in));
        LinkedHashMap<String, Date> modification = new LinkedHashMap<>();

        int numOfBooks = Integer.parseInt(scan.readLine());
        for (int i = 0; i < numOfBooks; i++) {
            String[] bookTokens = scan.readLine().split(" ");
            String title = bookTokens[0];
            Date releaseDate = dateFormat.parse(bookTokens[3]);

            modification.put(title, releaseDate);
        }

        Date date = dateFormat.parse(scan.readLine());

        modification.entrySet().stream()
                .filter(x -> x.getValue().compareTo(date) > 0)
                .sorted((x, y) -> x.getKey().compareTo(y.getKey()))
                .sorted((x, y) -> x.getValue().compareTo(y.getValue()))
                .forEach(p -> System.out.println(p.getKey() + " -> " + dateFormat.format(p.getValue())));
    }
}