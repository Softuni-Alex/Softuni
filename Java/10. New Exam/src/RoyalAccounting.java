import java.math.BigDecimal;
import java.math.BigInteger;
import java.util.ArrayList;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

class Team {
    ArrayList<Employee> employees = new ArrayList<>();
    private String name;

    public Team() {
        this.employees = new ArrayList<Employee>();
    }

    public String getName() {
        return this.name;
    }
}

class Employee {
    private String name;
    private BigInteger hours;
    private BigDecimal payment;

    public String getName() {
        return this.name;
    }

    public BigInteger getHours() {
        return this.hours;
    }

    public BigDecimal getPayment() {
        return this.payment;
    }
}

public class RoyalAccounting {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String regex = "([A-Za-z]+);([\\d]+);([-+]?[0-9]*\\.?[0-9]+);([\\w]+)";
        Pattern pattern = Pattern.compile(regex);

        String commands = scan.nextLine();

        while (!commands.equals("Pishi kuf i da si hodim")) {

            Matcher matcher = pattern.matcher(commands);

            if (matcher.find()) {
                String name = matcher.group(1);
                int workHours = Integer.parseInt(matcher.group(2));
                double payment = Double.parseDouble(matcher.group(3));
                String team = matcher.group(4);
            }
            commands = scan.nextLine();
        }
    }
}