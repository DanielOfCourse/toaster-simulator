using FoodModel;

public class Bagel : Food
{
    public Bagel()
    {
        this.name = "Bagel";
        this.isBurnt = false;
        this.isCooked = false;
        this.timeToCook = 90;
        this.timeToBurn = 180;
    }
}