namespace FoodShortage.Models.Interfaces
{
    interface IBuyer
    {
        public int Food { get; }

        int BuyFood();
    }
}
