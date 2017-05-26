import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class _27AverageGrades {
    public static void main(String[] args) throws Exception {

        BufferedReader reader = new BufferedReader(new InputStreamReader(System.in));
        List<Student> students = new ArrayList<>();

        int numberOfStudents = Integer.parseInt(reader.readLine());

        for (int i = 0; i < numberOfStudents; i++) {
            String[] tokens = reader.readLine().split(" ");

            String name = tokens[0];

            List<Double> grades = Arrays.stream(tokens).skip(1).limit(tokens.length - 1).map(Double::parseDouble).collect(Collectors.toList());

            Student student = new Student();
            student.setName(name);
            student.setGrades(grades);

            students.add(student);
        }

        students.stream()
                .filter(s -> s.getAverageGrade() >= 5)
                .sorted((s1, s2) -> s2.getAverageGrade().compareTo(s1.getAverageGrade()))
                .sorted((s1, s2) -> s1.getName().compareTo(s2.getName()))
                .forEach(s -> System.out.printf("%s -> %.2f\n", s.getName(), s.getAverageGrade()));
    }
}

class Student {

    private String name;
    private List<Double> grades;
    private Double averageGrade;

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public List<Double> getGrades() {
        return grades;
    }

    public void setGrades(List<Double> grades) {
        this.grades = grades;
    }

    public Double getAverageGrade() {
        double sum = 0;
        for (Double grade :
                this.grades) {
            sum+= grade;
        }

        return sum / this.grades.size();
    }
}