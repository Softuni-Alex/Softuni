package com.company;

import java.util.Scanner;

public class GetFirstOddOrEvenElement {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] numbersStr = scan.nextLine().split(" ");
        String[] input = scan.nextLine().split(" ");
        int digit = Integer.parseInt(input[1]);
        String oddEven = input[2];

        int[] numbers = new int[numbersStr.length];
        for (int i = 0; i < numbers.length; i++) {
            numbers[i] = Integer.parseInt(numbersStr[i]);
        }
        if (oddEven.equals("odd")) {
            doMagic(numbers, digit, 1);
        } else {
            doMagic(numbers, digit, 0);
        }

    }

    private static void doMagic(int[] numbers, int digit, int evenOdd) {
        for (int i = 0; i < numbers.length; i++) {
            if (digit == 0) {
                break;
            }
            if (numbers[i] % 2 == evenOdd) {
                digit--;
                System.out.print(numbers[i] + " ");
            }
        }
    }
}