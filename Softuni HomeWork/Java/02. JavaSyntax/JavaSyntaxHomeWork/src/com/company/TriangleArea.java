package com.company;


import java.util.Scanner;

public class TriangleArea {
    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);
        double aX = Double.parseDouble(scan.next());
        double aY = Double.parseDouble(scan.next());
        double bX = Double.parseDouble(scan.next());
        double bY = Double.parseDouble(scan.next());
        double cX = Double.parseDouble(scan.next());
        double cY = Double.parseDouble(scan.next());

        double area = (aX * (bY - cY) + bX * (cY - aY) + cX * (aY - bY)) / 2;

        if (area <= 0) {
            area = area * -1;
        }

        System.out.println((int) area);

    }
}