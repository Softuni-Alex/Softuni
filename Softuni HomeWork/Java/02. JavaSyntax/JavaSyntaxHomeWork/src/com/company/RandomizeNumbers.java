package com.company;

import java.util.LinkedHashSet;
import java.util.Random;
import java.util.Scanner;
import java.util.Set;

public class RandomizeNumbers {
    public static void main(String[] args) {
          Scanner console = new Scanner(System.in);
        Random random = new Random();
        int firstNumber = console.nextInt();
        int secondNumber = console.nextInt();
        int min = Math.min(firstNumber, secondNumber);
        int max = Math.max(firstNumber, secondNumber);

        for (int i = min; i <= max ; i++) {
            int randNumber = random.nextInt((max - min) + 1) + min;
            System.out.print(randNumber + " ");
        }
    }
}