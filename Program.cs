using FoodModel;

namespace ToasterSimulator
{
    class Program
    {
        static void Main(string[] args){
            SlotGroup slotGroup = new SlotGroup(0, 2, 20);
            Toaster toaster = new Toaster(slotGroup);

            Console.WriteLine("Toaster constructed without failing!");
            Program.RunToastingSimulator(toaster);
        }

        // Starts a toasting simulator given a set up toaster
        // TODO: Add support for changing food options
        static void RunToastingSimulator(Toaster toaster)
        {
            bool firstInsertSuccess = toaster.slotGroups[0].insertFood(new Bagel());
            bool secondInsertSuccess = toaster.slotGroups[0].insertFood(new Bread());
            bool thirdInsertSuccess = toaster.slotGroups[0].insertFood(new Bread());

            if (!firstInsertSuccess || !secondInsertSuccess)
            {
                Console.WriteLine("Error: First or second insert failed.");
                Console.WriteLine(firstInsertSuccess.ToString());
                Console.WriteLine(secondInsertSuccess.ToString());
            }

            if (thirdInsertSuccess)
            {
                Console.WriteLine("Error: Third insert was successful.");
            }

            Console.WriteLine("Toaster accepted food without failing!");

            toaster.slotGroups[0].cookTime = 150.0;
            if (!toaster.slotGroups[0].toast())
            {
                Console.WriteLine("Error: Toasting didn't start successfully.");
            }

            if (toaster.slotGroups[0].toast())
            {
                Console.WriteLine("Error: Toasting started mid-toast.");
            }

            Console.WriteLine("Toasting started without failing!");

            // Let's cancel the food immediately, neither food item should be cooked.
            Food?[] toastedFoods = toaster.slotGroups[0].endToasting();
            foreach(Food? food in toastedFoods)
            {
                Console.WriteLine("Found a " + food.name);
                if (food == null)
                {
                    Console.WriteLine("Error: One of our foods is null?");
                }
                else if (food.isBurnt || food.isCooked)
                {
                    Console.WriteLine("Error: Instantly cancelled food, saying it's cooked/burnt");
                }
            }

            Console.WriteLine("Cancelled without failing!");
        }
    }
}

