package com.company;

import java.io.*;

class Course implements Serializable {

    private String name;
    private int numberOfStudents;

    public Course(String name, int numberOfStudents) {
        this.name = name;
        this.numberOfStudents = numberOfStudents;
    }

    public Course() {

    }

    @Override
    public String toString() {
        return String.format("Cource -> %s, number of students: %d", name, numberOfStudents);
    }
}

public class _06SaveCustomObjectInAFile {
    private static final File FILE = new File("resources/course.save");

    public static void main(String[] args) {

        Course course = new Course("Softuni Course", 19);
        Course courseFromFile = new Course();

        try (ObjectOutputStream oos = new ObjectOutputStream(
                new FileOutputStream(FILE))) {
            oos.writeObject(course);

        } catch (FileNotFoundException e) {
            System.out.println("File not found or cannot be opened!");
        } catch (IOException e) {
            e.printStackTrace();
        }

        try (ObjectInputStream ois = new ObjectInputStream(
                new FileInputStream(FILE))) {
            courseFromFile = (Course) ois.readObject();

        } catch (FileNotFoundException e) {
            System.out.println("File not found or cannot be opened!");
        } catch (IOException e) {
            e.printStackTrace();
        } catch (ClassNotFoundException e) {
            e.printStackTrace();
        }

        System.out.println(course);
        System.out.println(courseFromFile);
    }
}