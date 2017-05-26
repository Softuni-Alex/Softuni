package com.company;

import java.util.Scanner;

public class RectangleArea {

    public static void main(String[] args) {

        Scanner console = new Scanner(System.in);

        int a = console.nextInt();
        int b = console.nextInt();

        long area = a * b;

        System.out.printf("Rectangle area with given a: %d and b: %d is: %d", a, b, area);
    }
}