package Example04.DataStreams;

import java.io.*;

public class Main {
    private static int age = 24;
    private static double money = 24.56;
    private static String name = "Yordan";

    public static void main(String[] args) {
//        saveData();
//        loadData();
    }

    private static void saveData() {
        try (DataOutputStream dos = new DataOutputStream(
                new BufferedOutputStream(
                        new FileOutputStream("resources/data_streams/data.save")))) {
            dos.writeInt(age);
            dos.writeDouble(money);
            dos.writeUTF(name);
        }
        catch (IOException ioe) {
            System.out.println(ioe.toString());
        }
    }

    private static void loadData() {
        try (DataInputStream dis = new DataInputStream(
                new BufferedInputStream(
                        new FileInputStream("resources/data_streams/data.save")))) {
            System.out.println("Age: "  + dis.readInt());
            System.out.println("Money: " + dis.readDouble());
            System.out.println("Name: " + dis.readUTF());
        }
        catch (IOException ioe) {
            System.out.println(ioe.toString());
        }
    }
}
