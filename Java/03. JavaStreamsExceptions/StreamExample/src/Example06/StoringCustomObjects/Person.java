package Example06.StoringCustomObjects;

import java.io.Serializable;

public class Person implements Serializable{
    private String name;
    private int age;

    public Person(String name, int age) {
        this.setName(name);
        this.setAge(age);
    }

    public String getName() {

        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public int getAge() {
        return age;
    }

    public void setAge(int age) {
        this.age = age;
    }

    @Override
    public String toString() {
        return "{Name: " + this.getName() + ", Age: " + this.getAge() + "}";
    }
}
