package com.company;

import java.util.Scanner;

public class PrintACharacterTriangle {

    public static void main(String[] args) {

        Scanner scanner = new Scanner(System.in);

        int lenght = Integer.parseInt((scanner.next()));

        for (int count = 0; count <= lenght; count++) {
            char character = 'a';
            for (int counter = 0; counter < count; character++, counter++) {
                System.out.printf(character + " ");
            }
            System.out.println();
        }

        for (int count = lenght - 1; count >= 0; count--) {
            char character = 'a';
            for (int counter = count - 1; counter >= 0; character++, counter--) {
                System.out.printf(character + " ");

            }
            System.out.println();

        }
    }
}