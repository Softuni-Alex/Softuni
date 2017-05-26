package Example05.StoringObjects;

import java.io.*;
import java.util.HashMap;

public class Main {
    private static HashMap<String, Double> grades;

    public static void main(String[] args) {
        grades = new HashMap<>();
        grades.put("Pesho", 5.5);
        grades.put("Gosho", 3.2);
        grades.put("Penka", 4.75);


//        saveObject();
//        loadObject();
    }

    private static void saveObject() {
        try (ObjectOutputStream oos = new ObjectOutputStream(
                new BufferedOutputStream(
                        new FileOutputStream("resources/object_streams/object.save")))) {
            oos.writeObject(grades);
        }
        catch (IOException ioe) {
            System.out.println(ioe.toString());
        }
    }

    private static void loadObject() {
        try (ObjectInputStream ois = new ObjectInputStream(
                new BufferedInputStream(
                        new FileInputStream("resources/object_streams/object.save")))) {
            System.out.println("Grades: "  + ois.readObject());
        }
        catch (ClassNotFoundException | IOException cnne) {
            System.out.println(cnne.toString());
        }
    }
}
