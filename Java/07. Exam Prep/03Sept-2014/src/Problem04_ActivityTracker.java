import java.util.Iterator;
import java.util.Map;
import java.util.Scanner;
import java.util.TreeMap;

public class Problem04_ActivityTracker {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        int lines = Integer.parseInt(scan.nextLine());

        TreeMap<Integer, TreeMap<String, Integer>> tracker = new TreeMap<>();

        for (int i = 0; i < lines; i++) {
            String[] input = scan.nextLine().split(" ");
            String[] date = input[0].split("/");
            int month = Integer.parseInt(date[1]);
            String user = input[1];
            int distance = Integer.parseInt(input[2]);
//check if the month is already present or not and act accordingly
            if (!tracker.containsKey(month)) {
                TreeMap<String, Integer> users = new TreeMap<>();
                users.put(user, distance);
                tracker.put(month, users);
            }
            //check if the user is already present or not and act accordingly
            else {
                TreeMap<String, Integer> users = tracker.get(month);
                if (!users.containsKey(user)) {
                    users.put(user, distance);
                } else {
                    int tempDistance = users.get(user);
                    tempDistance += distance;
                    users.put(user, tempDistance);
                }
                tracker.put(month, users);
            }

        }

        for (Iterator it = tracker.entrySet().iterator(); it.hasNext(); ) {
            Map.Entry month = (Map.Entry) it.next();

            String outputLine = month.getKey() + ": ";

            TreeMap users = (TreeMap) month.getValue();
            for (Iterator it2 = users.entrySet().iterator(); it2.hasNext(); ) {
                Map.Entry user = (Map.Entry) it2.next();

                outputLine += user.getKey() + "(" + user.getValue() + "), ";
            }

            outputLine = outputLine.substring(0, outputLine.length() - 2);
            System.out.println(outputLine);
        }
    }
}