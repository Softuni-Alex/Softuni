package com.company;

import java.util.Locale;
import java.util.Scanner;

public class CharacterMultiplier {
    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        String firstString = scan.next();
        String secondString = scan.next();

        System.out.println(multiplication(firstString, secondString));
    }

    private static int multiplication(String firstString, String secondString) {

        int totalSum = 0;

        if (firstString.length() == secondString.length()) {
            for (int i = 0; i < firstString.length(); i++) {
                totalSum += firstString.charAt(i) * secondString.charAt(i);
            }
        } else if (firstString.length() > secondString.length()) {
            for (int i = 0; i < firstString.length(); i++) {
                for (int j = 0; j < secondString.length(); j++) {
                    totalSum += firstString.charAt(i) * secondString.charAt(j);
                }
            }
        } else {
            for (int i = 0; i < firstString.length(); i++) {
                totalSum+= firstString.charAt(i) * secondString.charAt(i);
                for (int j = firstString.length(); j < secondString.length(); j++) {
                    totalSum +=  secondString.charAt(j);
                }
            }
        }
        return totalSum;
    }
}