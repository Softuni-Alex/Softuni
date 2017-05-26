package com.company;

import com.sun.deploy.util.StringUtils;

import java.util.Scanner;

public class FormattingNumbers {
    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        int a = Integer.parseInt(scan.next());
        float b = Float.parseFloat(scan.next());
        float c = Float.parseFloat(scan.next());

        String binary = Integer.toBinaryString(a);

        System.out.printf("|%-10s |%010d| %10.2f|%-10.3f|",
                Integer.toHexString(a).toUpperCase(),
                Integer.parseInt(binary),
                b,
                c);
    }
}