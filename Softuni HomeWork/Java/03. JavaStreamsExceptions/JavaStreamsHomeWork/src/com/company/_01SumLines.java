package com.company;

import java.io.*;
import java.util.ArrayList;
import java.util.List;

public class _01SumLines {

    public static void main(String[] args) {
        File file = new File("resources/lines.txt");
        List<Integer> sum = new ArrayList<>();

        try (BufferedReader br = new BufferedReader(new FileReader(file))) {
            String line;

            while ((line = br.readLine()) != null) {
                int currSum = 0;

                for (int i = 0; i < line.length(); i++) {
                    currSum += line.charAt(i);
                }

                sum.add(currSum);
            }
        } catch (FileNotFoundException fnfex) {
            System.out.println("File not found or cannot be opened!");
        } catch (IOException ioex) {
            ioex.printStackTrace();
        }

        for (Integer charSymbols : sum) {
            System.out.println(charSymbols);
        }
    }
}