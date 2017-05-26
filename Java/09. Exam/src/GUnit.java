import java.util.Scanner;
import java.util.TreeMap;

public class GUnit {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

       // String command = scan.nextLine();

        TreeMap<String, TreeMap<String, String>> database = new TreeMap<>();
        while (true) {
            String[] input = scan.nextLine().split(" | ");
            String classes = input[0];
            String methods = input[1];
            String tests = input[2];

            boolean areClassesUpper = Character.isUpperCase(classes.charAt(0));
            boolean areMethodsUpper = Character.isUpperCase(methods.charAt(0));
            boolean areTestsUpper = Character.isUpperCase(tests.charAt(0));

            if (areClassesUpper && areMethodsUpper && areTestsUpper) {
                if (isAlpha(classes) && isAlpha(methods) && isAlpha(tests)) {
                    if (classes.length() >= 2 && methods.length() >= 2 && tests.length() >= 2) {
                        if (!database.containsKey(classes)) {
                            TreeMap<String, String> methodTests = new TreeMap<>();
                            methodTests.put(methods, tests);
                            database.put(classes, methodTests);
                        } else {
                            TreeMap<String, String> methodTests = database.get(classes);
                            if (!methodTests.containsKey(methods)) {
                                methodTests.put(methods, tests);
                            } else {
                                methodTests.put(methods, tests);
                            }
                            database.put(classes, methodTests);
                        }
                    }
                }
            }
            if (input.equals("It's testing time!")){
                break;
            }
         //   command = scan.nextLine();
        }
            database.entrySet().forEach(a-> System.out.println(a.getKey()));
    }

    public static boolean isAlpha(String name) {
        return name.matches("[a-zA-Z0-9]+");
    }
}