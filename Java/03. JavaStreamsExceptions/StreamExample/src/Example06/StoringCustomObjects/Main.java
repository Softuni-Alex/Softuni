package Example06.StoringCustomObjects;

import java.io.*;

public class Main {
    private static Person[] people;

    public static void main(String[] args) {
        people = new Person[3];
        people[0] = new Person("Pesho", 18);
        people[1] = new Person("Gosho", 26);
        people[2] = new Person("Mariya", 24);


        saveObjects();
        loadObjects();
    }

    private static void saveObjects() {
        try (ObjectOutputStream oos = new ObjectOutputStream(
                new BufferedOutputStream(
                        new FileOutputStream("resources/object_streams/people.save")))) {

            //java.io.NotSerializableException
            //The class should implement Serializable interface
            //so it can be transferred via streams
            for(Person p : people) {
                oos.writeObject(p);
            }
        }
        catch (IOException ioe) {
            System.out.println(ioe.toString());
        }
    }

    private static void loadObjects() {
        try (ObjectInputStream ois = new ObjectInputStream(
                new BufferedInputStream(
                        new FileInputStream("resources/object_streams/people.save")))) {
            Object obj;

            while ((obj = ois.readObject()) != null) {
                System.out.println("Person: "  + obj);
            }
        }
        catch (EOFException eof) {
            System.out.println("END OF FILE!");
        }
        catch (ClassNotFoundException | IOException cnfe) {
            System.out.println(cnfe.toString());
        }
    }
}
