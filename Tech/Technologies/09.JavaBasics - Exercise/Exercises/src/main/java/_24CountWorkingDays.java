import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.*;

public class _24CountWorkingDays{
    public static void main(String[] args) throws Exception {
        Scanner scan = new Scanner(System.in);
        DateFormat format = new SimpleDateFormat("dd-MM-yyyy");
        DateFormat holidayFormater = new SimpleDateFormat("dd-MM");
        Date startDate = format.parse(scan.nextLine());
        Date endDate = format.parse(scan.nextLine());
        Calendar startCal = Calendar.getInstance();
        startCal.setTime(startDate);
        Calendar endCal = Calendar.getInstance();
        endCal.setTime(endDate);

        List<Date> holidays = new ArrayList<Date>(){{
            add(format.parse(String.format("01-01-%d", startCal.get(Calendar.YEAR))));
            add(format.parse(String.format("03-03-%d", startCal.get(Calendar.YEAR))));
            add(format.parse(String.format("01-05-%d", startCal.get(Calendar.YEAR))));
            add(format.parse(String.format("06-05-%d", startCal.get(Calendar.YEAR))));
            add(format.parse(String.format("24-05-%d", startCal.get(Calendar.YEAR))));
            add(format.parse(String.format("06-09-%d", startCal.get(Calendar.YEAR))));
            add(format.parse(String.format("22-09-%d", startCal.get(Calendar.YEAR))));
            add(format.parse(String.format("01-11-%d", startCal.get(Calendar.YEAR))));
            add(format.parse(String.format("24-12-%d", startCal.get(Calendar.YEAR))));
            add(format.parse(String.format("25-12-%d", startCal.get(Calendar.YEAR))));
            add(format.parse(String.format("26-12-%d", startCal.get(Calendar.YEAR))));
        }};

        int workingDays = 0;
        int year = startCal.get(Calendar.YEAR);
        for (Calendar current = startCal; current.getTimeInMillis() <= endCal.getTimeInMillis(); current.add(Calendar.DAY_OF_MONTH, 1)) {
            if (year != current.get(Calendar.YEAR)) {
                holidays = createNewHolidays(holidays, current.get(Calendar.YEAR), format);
                year = current.get(Calendar.YEAR);
            }
            if (current.get(Calendar.DAY_OF_WEEK) != Calendar.SATURDAY
                    && current.get(Calendar.DAY_OF_WEEK) != Calendar.SUNDAY
                    && !holidays.contains(current.getTime())) {
                workingDays++;
            }
        }

        System.out.println(workingDays);
    }

    private static List<Date> createNewHolidays(List<Date> holidays, int year, DateFormat format) throws Exception {
        holidays = new ArrayList<Date>(){{
            add(format.parse(String.format("01-01-%d", year)));
            add(format.parse(String.format("03-03-%d", year)));
            add(format.parse(String.format("01-05-%d", year)));
            add(format.parse(String.format("06-05-%d", year)));
            add(format.parse(String.format("24-05-%d", year)));
            add(format.parse(String.format("06-09-%d", year)));
            add(format.parse(String.format("22-09-%d", year)));
            add(format.parse(String.format("01-11-%d", year)));
            add(format.parse(String.format("24-12-%d", year)));
            add(format.parse(String.format("25-12-%d", year)));
            add(format.parse(String.format("26-12-%d", year)));
        }};

        return holidays;
    }
}