package GameObjects;

public class Egg {
    private final int AGE_HATCH = 2;

    private int age;
    private Dragon parent;
    private YearType yearFactor;

    public Egg(int age, Dragon parent) {
        this.age = age;
        this.parent = parent;
    }

    public void age() {
        this.age++;
    }

    public void hatch() {
        if (this.age == AGE_HATCH) {
            int yearFactor = this.yearFactor.ordinal();
            for (int i = 0; i < yearFactor; i++) {
                Dragon baby = new Dragon(this.parent.getClass().getName() + "/" + "Dragon_" + DragonEra.dragonsCount, -1);
                this.parent.increaseOffspring(baby);
                DragonEra.dragonsCount++;
            }
        }
    }

    public void setYearFactor(YearType yearFactor) {
        this.yearFactor = yearFactor;
    }
}