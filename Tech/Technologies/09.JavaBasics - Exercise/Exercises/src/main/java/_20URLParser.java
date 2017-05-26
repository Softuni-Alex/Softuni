import java.util.Scanner;

public class _20URLParser {
    public static void main(String[] args) {
        Scanner in = new Scanner(System.in);
        String url = in.nextLine();
        String protocol = "";
        String server = "";
        String resource = "";

        if (url.split("://").length > 1) {
            protocol = url.split("://")[0];
            url = url.split("://")[1];
        }
        server = url.split("/")[0];
        if (url.split("/").length > 1) {
            resource = url.substring(url.indexOf("/") + 1);
        }
        System.out.println("[protocol] = \"" + protocol + "\"");
        System.out.println("[server] = \"" + server + "\"");
        System.out.println("[resource] = \"" + resource + "\"");

    }
}