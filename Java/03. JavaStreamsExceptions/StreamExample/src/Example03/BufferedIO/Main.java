package Example03.BufferedIO;

import java.io.*;

public class Main {
    public static void main(String[] args) {
//        readBufferedBytes();
//        readBufferedChars();
    }

    private static void readBufferedBytes() {
        try (
                BufferedInputStream bfis =
                        new BufferedInputStream(new FileInputStream("resources/binary_streams/java.jpg"));
                BufferedOutputStream bfos =
                        new BufferedOutputStream(new FileOutputStream("resources/binary_streams/java_out.jpg"))
        ){
            int i;
            while ((i = bfis.read()) != -1) {
                bfos.write((char)i);
            }
        }
        catch (IOException ioe) {
            System.out.println(ioe.toString());
        }
    }

    private static void readBufferedChars() {
        try (
                BufferedReader bfr =
                        new BufferedReader(new FileReader("resources/character_streams/input"));
                BufferedWriter bfw =
                        new BufferedWriter(new FileWriter("resources/character_streams/output"))
        ){
            String s;
            while ((s = bfr.readLine()) != null) {
                bfw.write(s);
            }
        }
        catch (IOException ioe) {
            System.out.println(ioe.toString());
        }
    }
}
