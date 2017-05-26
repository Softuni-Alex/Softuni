package com.company;

import java.io.*;

public class Main {

    public static void main(String[] args) throws IOException {

        final String filePath = "users.txt";
        String savePath = "savedFile.txt";

        BufferedReader reader = new BufferedReader(new FileReader(filePath));
        BufferedWriter output = new BufferedWriter(new FileWriter(savePath));
        String line = reader.readLine();

        while (line != null) {
            String[] columns = line.split(" ");
            String name = columns[0];
            int minutes = 0;
            int keptMinutes = 0;

            for (int i = 1; i < columns.length; i++) {
                String[] loggedTime = columns[i].split(":");
                int hours = Integer.parseInt(loggedTime[0]);
                int mins = Integer.parseInt(loggedTime[1]);

                int totalMinutes = mins + (hours * 60);

                minutes += totalMinutes;
                keptMinutes += totalMinutes;
            }

            int minsInDay = 1440;
            int days = minutes / minsInDay;
            minutes %= minsInDay;
            int hours = minutes / 60;
            minutes %= 60;

            String outputFormat = String.format("%s %d (%d days, %d hours, %d minutes\r\n", name, keptMinutes, days, hours, minutes);
            output.write(outputFormat);
            line = reader.readLine();
        }
        output.close();
        reader.close();
    }
}
