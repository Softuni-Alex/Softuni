package com.company;

import java.util.ArrayList;
import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Problem04_LogParser {
    public static void main(String[] args) {
        LinkedHashMap<String, LinkedHashMap<String, ArrayList<String>>> projects = new LinkedHashMap<>();
        Pattern pat = Pattern.compile("\"Project\":\\s+\\[\"(.*?)\"\\],\\s+\"Type\":\\s+\\[\"(.*?)\"\\],\\s+\"Message\":\\s+\\[\"(.*?)\"\\]");

        String line;
        Scanner scn = new Scanner(System.in);
        while (!(line = scn.nextLine()).equals("END")) {
            Matcher match = pat.matcher(line);
            match.find();
            String project = match.group(1);
            String type = match.group(2);
            String message = match.group(3);

            if (!projects.containsKey(project)) {
                projects.put(project, new LinkedHashMap<>());
                projects.get(project).put("Critical", new ArrayList<>());
                projects.get(project).put("Warnings", new ArrayList<>());
            }

            if (type.equals("Critical")) {
                projects.get(project).get("Critical").add(message);
            } else {
                projects.get(project).get("Warnings").add(message);
            }
        }

        projects.entrySet().stream()
                .sorted((e1,e2) -> {
                    int total2 = (e2.getValue().get("Critical").size() + e2.getValue().get("Warnings").size());
                    int total1 = (e1.getValue().get("Critical").size() + e1.getValue().get("Warnings").size());

                    if (total1 != total2) {
                        return Integer.compare(total2, total1);
                    }
                    return e1.getKey().compareTo(e2.getKey());
                })
                .forEach(pair -> {
                    System.out.println(pair.getKey() + ":");
                    ArrayList<String> critical = pair.getValue().get("Critical");
                    ArrayList<String> warnings = pair.getValue().get("Warnings");
                    System.out.println("Total Errors: " + (critical.size() + warnings.size()));
                    System.out.println("Critical: " + critical.size());
                    System.out.println("Warnings: " + warnings.size());

                    System.out.println("Critical Messages:");
                    printList(critical);
                    System.out.println("Warning Messages:");
                    printList(warnings);
                    System.out.println();
                });
    }

    private static void printList(ArrayList<String> list) {
        if (list.size() < 1) {
            System.out.println("--->None");
            return;
        }

        list.stream().sorted((e1,e2) -> {
            if (e1.length() != e2.length()) {
                return Integer.compare(e1.length(), e2.length());
            }
            return e1.compareTo(e2);
        }).forEach(e1 -> {
            System.out.println("--->" + e1);
        });
    }
}