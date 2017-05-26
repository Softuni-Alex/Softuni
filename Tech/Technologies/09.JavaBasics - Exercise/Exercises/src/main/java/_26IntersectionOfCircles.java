import java.util.Scanner;

public class _26IntersectionOfCircles {
    public static void main(String[] args) {
        Scanner scan = new Scanner(System.in);
        String[] inputOne = scan.nextLine().split(" ");
        String[] inputTwo = scan.nextLine().split(" ");

        Double[] first = new Double[inputOne.length];

        for (int i = 0; i < inputOne.length; i++) {
            first[i] = Double.parseDouble(inputOne[i]);
        }

        Double[] second = new Double[inputTwo.length];

        for (int i = 0; i < inputTwo.length; i++) {
            second[i] = Double.parseDouble(inputTwo[i]);
        }

        Point centerA = new Point(first[0], first[1]);
        Point centerB = new Point(second[0], second[1]);

        Circle circleA = new Circle(first[2], centerA);
        Circle circleB = new Circle(second[2], centerB);

        if (intersect(circleA,circleB)){
            System.out.println("Yes");
        }
        else {
            System.out.println("No");
        }
    }

    public static boolean intersect(Circle first, Circle second) {
        double distance = CalculateDistance(first.getCenter(), second.getCenter());
        double sumOfRadiuses = first.getRadius() + second.getRadius();
        if (distance > sumOfRadiuses) {
            return false;
        } else {
            return true;
        }
    }

    public static double CalculateDistance(Point a, Point b) {
        double deltaX = b.getX() - a.getX();
        double deltaY = b.getY() - a.getY();

        double distance = Math.sqrt(deltaX * deltaX + deltaY * deltaY);

        return distance;
    }
}

class Circle {
    private double radius;
    private Point center;

    public Circle(double radius, Point center) {
        this.radius = radius;
        this.center = center;
    }

    public double getRadius() {
        return radius;
    }

    public Point getCenter() {
        return center;
    }

    public double distanceBetweenCircleCenters(Point first, Point second) {
        double deltaX = second.getX() - first.getX();
        double deltaY = second.getY() - first.getY();

        double distance = Math.sqrt(deltaX * deltaX + deltaY * deltaY);

        return distance;
    }
}

class Point {
    private double x;
    private double y;

    public Point(double x, double y) {
        this.x = x;
        this.y = y;
    }

    public double getX() {
        return x;
    }

    public double getY() {
        return y;
    }
}