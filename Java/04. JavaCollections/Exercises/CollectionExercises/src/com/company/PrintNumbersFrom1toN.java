package com.company;

import java.util.Scanner;

public class PrintNumbersFrom1toN {

    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);
        int number = Integer.parseInt(scan.nextLine());

        printRecursive(number);
    }

    private static void printRecursive(int number) {

        if (number < 1) {
            return;
        }

        printRecursive(number - 1);
        System.out.println(number);
    }
}