using FoodModel;

public class Bread : Food
{
    public Bread()
    {
        this.name = "Bread";
        this.isBurnt = false;
        this.isCooked = false;
        this.timeToCook = 60;
        this.timeToBurn = 120;
    }
}