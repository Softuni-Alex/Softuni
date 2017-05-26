package com.company;

import java.util.Scanner;

public class HitTheTarget {
    public static void main(String[] args) {

        Scanner scan = new Scanner(System.in);

        int target = Integer.parseInt(scan.next());

        int maxLength = 20;

        for (int i = 0; i <= maxLength; i++) {
            for (int j = 0; j <= maxLength; j++) {
                if (i-j == target){
                    System.out.printf("%d - %d = %d",i,j,target);
                    System.out.println();
                }
                if (i+j == target){
                    System.out.printf("%d + %d = %d",i,j,target);
                    System.out.println();

                }
            }
        }
    }
}
