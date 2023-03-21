namespace FoodModel
{
    public abstract class Food
    {
        public string name;
        public double timeToCook;
        public double timeToBurn;
        public bool isCooked;
        public bool isBurnt;

        public Food(string name, double timeToCook, double timeToBurn)
        {
            this.name = name;
            this.timeToCook = timeToCook;
            this.timeToBurn = timeToBurn;
            this.isCooked = false;
            this.isBurnt = false;
        }

        public Food(Food food)
        {
            this.name = food.name;
            this.timeToCook = food.timeToCook;
            this.timeToBurn = food.timeToBurn;
            this.isCooked = food.isCooked;
            this.isBurnt = food.isBurnt;
        }

        public Food()
        {
            this.name = "";
            this.timeToCook = 0;
            this.timeToBurn = 0;
            this.isCooked = false;
            this.isBurnt = false;
        }
    }
}

