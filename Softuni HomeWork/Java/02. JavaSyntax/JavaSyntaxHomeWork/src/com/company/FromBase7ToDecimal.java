package com.company;

import java.util.Scanner;

public class FromBase7ToDecimal {
    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        String number = scan.next();

        System.out.println(Integer.valueOf(number,7));
    }
}