import java.util.LinkedHashMap;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Orders {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int number = Integer.parseInt(scan.nextLine());

        Map<String, TreeMap<String, Integer>> allOrders = new LinkedHashMap<>();
        for (int i = 0; i < number; i++) {
            String[] orders = scan.nextLine().split(" ");
            String customer = orders[0];
            String amount = orders[1];
            String product = orders[2];

            if (!allOrders.containsKey(product)) {
                allOrders.put(product, new TreeMap<String, Integer>());
            }
            if (!allOrders.get(product).containsKey(customer)) {
                allOrders.get(product).put(customer, 0);
            }
            allOrders.get(product).put(customer, allOrders.get(product).get(customer) + Integer.parseInt(amount));
        }

        for (Map.Entry<String, TreeMap<String, Integer>> entry : allOrders.entrySet()) {
            System.out.print(entry.getKey() + ": ");

            System.out.println(String.join(", ", entry.getValue().entrySet().toString().substring(1, entry.getValue().entrySet().toString().length() - 1)).replace('=', ' '));
        }
    }
}