package com.company;

import java.io.*;

public class _03CountCharacterTypes {

    private static final File INPUT_FILE = new File("resources/words.txt");
    private static final File OUTPUT_FILE = new File("resources/count-chars.txt");
    private static int vowels = 0;
    private static int consonants = 0;
    private static int punctuation = 0;

    public static void main(String[] args) {

        String text = readTextFromFile();
        countCharTypes(text);
        saveResult();
    }

    private static void saveResult() {

        try (BufferedWriter bw = new BufferedWriter(new FileWriter(OUTPUT_FILE))) {
            bw.write("Vowels: " + vowels + System.lineSeparator());
            bw.write("Consonants: " + consonants + System.lineSeparator());
            bw.write("Punctuation: " + punctuation + System.lineSeparator());

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private static String readTextFromFile() {
        StringBuilder sb = new StringBuilder();

        try (BufferedReader br = new BufferedReader(new FileReader(INPUT_FILE))) {
            String line;
            while ((line = br.readLine()) != null) {
                sb.append(line);
            }

        } catch (FileNotFoundException e) {
            System.out.println("File not found or cannot be opened!");
        } catch (IOException e) {
            e.printStackTrace();
        }

        return sb.toString();
    }

    private static void countCharTypes(String text) {
        for (int i = 0; i < text.length(); i++) {
            char c = text.charAt(i);

            if (Character.isLetter(c)) {
                if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u') {
                    vowels++;
                } else {
                    consonants++;
                }
            }

            if (c == '!' || c == ',' || c == '.' || c == '?') {
                punctuation++;
            }
        }
    }

}