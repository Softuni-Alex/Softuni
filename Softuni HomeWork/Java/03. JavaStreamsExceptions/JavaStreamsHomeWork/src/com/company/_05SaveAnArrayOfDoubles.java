package com.company;

import java.io.*;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

public class _05SaveAnArrayOfDoubles {
    private static final File FILE = new File("resources/doubles.list");

    public static void main(String[] args) {

        List<Double> listOfDoubles = new ArrayList<>(Arrays.asList(3.5, 1.9, 7.1));
        List<Double> listFromFile = new ArrayList<>();
        int count = listOfDoubles.size();

        saveList(listOfDoubles);
        loadList(listFromFile, count);

        System.out.println(listOfDoubles);
        System.out.println(listFromFile);
    }

    private static void loadList(List<Double> listFromFile, int count) {
        try (ObjectInputStream ois = new ObjectInputStream(
                new FileInputStream(FILE))) {
            for (int i = 0; i < count; i++) {
                listFromFile.add(ois.readDouble());
            }

        } catch (FileNotFoundException e) {
            System.out.println("File not found or cannot be opened!");
        } catch (IOException e) {
            e.printStackTrace();
        }

    }

    private static void saveList(List<Double> listOfDoubles) {
        try (ObjectOutputStream oos = new ObjectOutputStream(
                new FileOutputStream(FILE))) {
            for (Double element : listOfDoubles) {
                oos.writeDouble(element);
            }

        } catch (FileNotFoundException e) {
            System.out.println("File not found or cannot be opened!");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }

}