package com.company;

import java.util.Arrays;
import java.util.List;
import java.util.Scanner;
import java.util.stream.Collector;
import java.util.stream.Collectors;

public class Main {

    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);

        String[] strings = scan.nextLine().split(" ");

        Arrays.stream(strings).filter(Main::isANumber).map(Integer::parseInt);

        List<Integer> numbers = Arrays.stream(strings).filter(Main::isANumber).map(Integer::parseInt).collect(Collectors.toList());

        int sum = numbers.stream().mapToInt(Integer::intValue).sum();

        System.out.println(sum);

    }

    private static boolean isANumber(String str) {
        for (char ch : str.toCharArray()) {
            if (!Character.isDigit(ch)) {
                return false;
            }
        }
        return true;
    }
}