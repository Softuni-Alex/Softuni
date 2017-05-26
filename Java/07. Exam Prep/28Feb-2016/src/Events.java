import java.util.Arrays;
import java.util.Map.Entry;
import java.util.Scanner;
import java.util.TreeMap;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Events {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        String regexPattern = "^#([a-zA-Z]+):[\\s]*@([a-zA-Z]+)[\\s]*([\\d]{2}:[\\d]{2})$";
        Pattern pattern = Pattern.compile(regexPattern);

        Integer eventsCount = Integer.parseInt(scanner.nextLine());

        TreeMap<String, TreeMap<String, String>> eventsByLocation = new TreeMap<String, TreeMap<String, String>>();

        for (int i = 0; i < eventsCount; i++) {
            String event = scanner.nextLine();
            Matcher m = pattern.matcher(event);

            if(m.find()){
                String person = m.group(1);
                String location = m.group(2);
                String fullHour = m.group(3);

                int hour = Integer.parseInt(fullHour.split(":")[0]);
                int minutes = Integer.parseInt(fullHour.split(":")[1]);

                if(hour < 0 || hour > 23 || minutes < 0 || minutes > 59){
                    continue;
                }

                if(eventsByLocation.containsKey(location)){
                    TreeMap<String, String> people = eventsByLocation.get(location);
                    if(people.containsKey(person)){
                        people.replace(person, people.get(person), fullHour + ", " + people.get(person));
                    }
                    else{
                        people.put(person, fullHour);
                    }
                }
                else{
                    TreeMap<String, String> people = new TreeMap<String, String>();
                    people.put(person, fullHour);
                    eventsByLocation.put(location, people);
                }
            }
        }

        String[] cities = scanner.nextLine().split(",");

        Arrays.sort(cities);

        for(String city : cities){
            if(eventsByLocation.containsKey(city)){
                System.out.println(String.format("%s:", city));
                TreeMap<String, String> peopleFromCity = eventsByLocation.get(city);

                int count = 1;

                for(Entry<String, String> entry : peopleFromCity.entrySet()){
                    System.out.println(String.format("%d. %s -> %s", count, entry.getKey(), entry.getValue()));
                    count++;
                }
            }
        }
    }
}