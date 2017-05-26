package com.company;

import java.util.Scanner;
import java.util.StringJoiner;

public class OddEvenPairs {
    public static void main(String[] args) {

        Scanner Scan = new Scanner(System.in);

        String[] input = Scan.nextLine().split(" ");

        for (int i = 0; i < input.length; i += 2) {
            int first = Integer.parseInt(input[i]);
            int second = Integer.parseInt(input[i + 1]);

            if (input.length % 2 != 0) {
                System.out.print("Invalid input");
                break;
            }
            if ((first % 2 == 0) && (second % 2 == 0)) {
                System.out.printf("%d, %d -> even", first, second);
                System.out.println();
                continue;
            }
            if ((first % 2 == 1) && (second % 2 == 1)) {
                System.out.printf("%d, %d -> odd", first, second);
                System.out.println();
                continue;
            } else {
                System.out.printf("%d, %d -> different", first, second);
            }
        }
    }
}
