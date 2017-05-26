package com.company;

import java.io.*;
import java.util.zip.ZipEntry;
import java.util.zip.ZipOutputStream;

public class _07CreateZIPArchive {

    private static final File[] INPUT_FILES = {
            new File("resources/words.txt"),
            new File("resources/count-chars.txt"),
            new File("resources/lines.txt")
    };
    private static final File ZIP_FILE = new File("resources/filesArchive.zip");

    public static void main(String[] args) {
        try (ZipOutputStream zos = new ZipOutputStream(new FileOutputStream(ZIP_FILE))) {

            for (File file : INPUT_FILES) {
                try (FileInputStream fis = new FileInputStream(file)) {
                    zos.putNextEntry(new ZipEntry(file.getName()));

                    byte[] buffer = new byte[4096];
                    int returnedBytes;

                    while ((returnedBytes = fis.read(buffer, 0, buffer.length)) != -1) {
                        zos.write(buffer, 0, returnedBytes);
                    }
                }
            }

        } catch (FileNotFoundException e) {
            System.out.println("File not found or cannot be opened!");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}