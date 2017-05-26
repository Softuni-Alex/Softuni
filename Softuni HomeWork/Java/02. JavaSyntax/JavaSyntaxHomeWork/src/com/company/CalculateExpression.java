package com.company;

import java.util.Scanner;

public class CalculateExpression {
    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        double a = Float.parseFloat(scanner.nextLine());
        double b = Float.parseFloat(scanner.nextLine());
        double c = Float.parseFloat(scanner.nextLine());


        double number = (a * a + b * b) / (a * a - b * b);
        double power = (a + b + c) / Math.sqrt(c);
        double result1 = Math.pow(number, power);


        number = a * a + b * b - c * c * c;
        power = a - b;
        double result2 = Math.pow(number, power);

        double diff = Math.abs((a + b + c) / 3 - (result1 + result2) / 2);

        System.out.printf("F1 result: %.2f; F2 result: %.2f; Diff: %.2f", result1, result2, diff);

    }
}
