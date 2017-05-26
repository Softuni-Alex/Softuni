package GameObjects;

import java.util.List;

public class Dragon {
    private final int AGE_DEATH = 6;
    private final int AGE_LAY_EGGS_START = 3;
    private final int AGE_LAY_EGGS_END = 4;

    private String name;
    private int age;

    private List<Egg> eggs;
    private List<Dragon> childs;
    private boolean isAlive = false;

    public Dragon(String name, int age) {
        this.name = name;
        this.age = age;
    }

    public boolean isAlive() {
        return isAlive;
    }

    public void lay() {
        if (this.age >= AGE_LAY_EGGS_START && this.age <= AGE_LAY_EGGS_END) {
            Egg egg = new Egg(-1, this);
            this.eggs.add(egg);
        }
    }

    public void age() {
        //TODO: isAlive might be true
        if (this.isAlive) {
            this.age++;
        }
        if (this.age == AGE_DEATH) {
            this.isAlive = false;
        }
    }

    public void increaseOffspring(Dragon baby) {
        this.childs.add(baby);
    }

    public Iterable<Egg> getEggs() {
        return this.eggs;
    }

    public Iterable<Dragon> getChildren() {
        return this.childs;
    }
}