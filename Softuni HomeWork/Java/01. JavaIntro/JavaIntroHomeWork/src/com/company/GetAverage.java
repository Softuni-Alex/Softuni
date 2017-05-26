package com.company;

import java.util.Scanner;

public class GetAverage {
    public static void main(String[] args) {

        Scanner console = new Scanner(System.in);

        double a = console.nextDouble();
        double b = console.nextDouble();
        double c = console.nextDouble();

        getAverage(a,b,c);
    }

    public static void getAverage(double a, double b, double c) {

        double average = (a + b + c) / 3;
        System.out.println(average);
    }
}
