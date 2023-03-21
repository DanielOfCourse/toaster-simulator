using FoodModel;

public class Slot 
{
    public int id;

    public Food? currentFood;

    public bool isCooking;

    public double startingTime;

    public double cookingTime;

    public Slot(int id)
    {
        this.id = id;
        this.currentFood = null;
        this.isCooking = false;
        this.startingTime = 0;
        this.cookingTime = 0;
    }

    public bool hasFood()
    {
        return currentFood != null;
    }

    public void startToasting(double cookTime, bool toastOneSide)
    {
        this.cookingTime = cookTime;
        // Source: Stack Overflow
        this.startingTime = DateTimeOffset.Now.ToUnixTimeSeconds();
        this.isCooking = true;
    }

    public Food? cancelToasting()
    {
        if (this.currentFood == null)
        {
            return null;
        }

        Food returningFood = this.currentFood;
        double currentTime = DateTimeOffset.Now.ToUnixTimeSeconds();
        if (returningFood == null)
        {
            // There's no food in the slot? Return the non-food.
            return null;
        }
        else
        {
            if (currentTime - (returningFood.timeToCook) > this.startingTime)
            {
                if (oneSidedCook)
                {
                    // something else
                }
                returningFood.isCooked = true;
            }
            if (currentTime - (returningFood.timeToBurn) > this.startingTime)
            {
                returningFood.isBurnt = true;
                // Should burnt food also be "cooked"? hm...
            }
            // Cleanup
            this.isCooking = false;
            this.currentFood = null;

            return returningFood;
        }
    }
}