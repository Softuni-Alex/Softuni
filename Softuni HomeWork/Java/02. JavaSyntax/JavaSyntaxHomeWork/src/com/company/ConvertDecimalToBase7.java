package com.company;

import java.util.Scanner;

public class ConvertDecimalToBase7 {
    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        int number = Integer.parseInt(scan.next());

        System.out.println(Integer.toString(number,7));
    }
}
