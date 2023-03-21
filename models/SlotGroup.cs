using FoodModel;

public class SlotGroup
{
    public int id;

    public int slotCount;

    public Slot[] slots;

    public double cookTime;

    public double startingTime;

    public bool isToasting;

    public SlotGroup(int id, int slotCount, double cookTime)
    {
        this.id = id;
        this.slotCount = slotCount;
        this.slots = new Slot[slotCount];
        for (int i = 0; i < slotCount; i++)
        {
            this.slots[i] = new Slot(i);
        }
        
        this.cookTime = cookTime;
        this.startingTime = 0;
        this.isToasting = false;
    }

    // Attempts to insert a food item into the first available slot.
    // If available slot, return true; else return false
    public bool insertFood(Food food) {
        bool foodPlaced = false;
        for (int i = 0; i < slotCount; i++)
        {
            if (!slots[i].hasFood() && !foodPlaced)
            {
                slots[i].currentFood = food;
                foodPlaced = true;
            }
        }
        // No available slots to take your food, sorry!
        return foodPlaced;
    }

    // Signals to each slot to begin toasting, if toasting cannot
    // begin due to already being started, return false; else,
    // return true
    // TODO: Rework to return toasting task or similar, allow client/simulator
    // to be able to start toasting task that returns when completed.
    public bool toast() {
        if (this.isToasting)
        {
            return false;
        }
        for (int i = 0; i < slotCount; i++)
        {
            this.slots[i].startToasting(this.cookTime, false);
        }
        this.isToasting = true;
        return true;
    }

    // Ends the toasting process
    public Food?[] endToasting() {
        Food?[] returnedFoodArray = new Food?[this.slotCount];
        for (int i = 0; i < slotCount; i++)
        {
            Food? returnedFood = this.slots[i].cancelToasting();
            returnedFoodArray[i] = returnedFood;
        }
        return returnedFoodArray;
    }
}